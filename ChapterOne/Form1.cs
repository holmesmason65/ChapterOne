﻿/*
 * Mason Holmes
 * 6/6/21
 * This program allows users to fill out billing information and times the process.
 * inputs: txtName : string, used to collect user's name
 *         txtAddress : string, used to collect user's address
 *         txtCity : string, used to collect user's city 
 *         txtState : string, used to collect user's state
 *         txtZip : string, used to collect user's zip code
 * outputs: txtElapsedTime : string, displays the time it took to fill out the form
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapterOne
{
    public partial class frmMailingList : Form
    {
        DateTime lastNow;
        TimeSpan elapsedTime; 
        
        public frmMailingList()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start button click
            // Disable start and exit buttons 
            // enabled pause button 
            btnStart.Enabled = false;
            btnExit.Enabled = false;
            btnPause.Enabled = true;
            // Establish start time and start timer control 
            lastNow = DateTime.Now;
            timSeconds.Enabled = true;
            // Enable mailing list frame
            grpMail.Enabled = true;
            txtName.Focus(); 
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            // Pause button clicked 
            // Disable pause button 
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            btnExit.Enabled = true;
            // Stop timer 
            timSeconds.Enabled = false;
            // Disable editing frame
            grpMail.Enabled = false; 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void timSeconds_Tick(object sender, EventArgs e)
        {
            // Compute elapsed time and display
            elapsedTime += DateTime.Now - lastNow;
            txtElapsedTime.Text = Convert.ToString(new TimeSpan(elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds));
            lastNow = DateTime.Now; 
        }
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e) 
        {
            string boxName = ((TextBox)sender).Name;
            // Check for return key  
            if ((int)e.KeyChar == 13) 
            {
                switch (boxName) 
                {
                    case "txtName":
                        txtAddress.Focus();
                        break;
                    case "txtAddress":
                        txtCity.Focus();
                        break;
                    case "txtCity":
                        txtState.Focus();
                        break;
                    case "txtState":
                        txtZip.Focus();
                        break;
                    case "txtZip":
                        btnAccept.Focus();
                        break; 
                }
            }
            // In the zip text box, make sure only numbers or backspace pressed 
            if (boxName.Equals("txtZip")) 
            {
                if((e.KeyChar >= '0' && e.KeyChar <= '9') || (int) e.KeyChar == 8) 
                {
                    e.Handled = false; 
                }
                else 
                {
                    e.Handled = true; 
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string s;
            // Accept button clicked  - form label and output in message box 
            // Make sure the text box has an entry 
            if (txtName.Text.Equals("") || txtAddress.Text.Equals("") || txtCity.Text.Equals("") || txtState.Text.Equals("") || txtZip.Text.Equals("")) 
            {
                MessageBox.Show("Each box must have an entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return; 
            }
            s = txtName.Text + "\r\n" + txtAddress.Text + "\r\n";
            s += txtCity.Text + ", " + txtState.Text + " " + txtZip.Text;
            MessageBox.Show(s, "Mailing Label", MessageBoxButtons.OK);
            btnClear.PerformClick(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtName.Focus(); 
        }
    }
}
