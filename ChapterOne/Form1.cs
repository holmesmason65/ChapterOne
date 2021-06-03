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
    }
}
