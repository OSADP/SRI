using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aspen2eCitation.aspen;
using Aspen2eCitation.eCitation;

namespace Aspen2eCitation
{
    public partial class Form1 : Form
    {
        AspenDao aspenDao = new AspenDao();
        AspenMapper aspenMapper = new AspenMapper();
        public static Form1 _Form1;

        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
        }

        public void appendStatus(string message)
        {
            txtStatus.Text = txtStatus.Text + Environment.NewLine + message;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
            this.Cursor = Cursors.WaitCursor;
            Inspmain inspmain;
            if (String.IsNullOrWhiteSpace(txtUdot.Text))
            {
                inspmain = aspenDao.getLatestAspenRecord();
            }
            else
            {
                inspmain = aspenDao.getAspenRecord(txtUdot.Text);
            }

            if (inspmain != null && inspmain.rptnum != null)
            {
                if (checkBox1.Checked)
                {
                    eCitationConverter.convertAspenData2eCitationData(inspmain);
                }
                else
                {
                    Form1._Form1.appendStatus("Retrieved from Aspen");
                    Form1._Form1.appendStatus("----------------------------------------"); 
                    Form1._Form1.appendStatus("Inspection # - " + inspmain.rptnum);
                    Form1._Form1.appendStatus(
                        "Driver - " + inspmain.driverfname + " "
                        + inspmain.driverlname);
                    Form1._Form1.appendStatus("License Plate # - " + inspmain.vehicle.unitlicnum);
                }
            }
            else
            {
                txtStatus.Text = txtStatus.Text
                    + "No results for Aspen Report Number <"
                    + txtUdot.Text + "> found.  " + Environment.NewLine + Environment.NewLine
                    + "Ensure that the Report Number entered "
                    + "is correct and that the Aspen record has been verified as this "
                    + "action will save it to the Aspen local database.";
            }
            this.Cursor = Cursors.Default;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUdot.Text = "";
            txtStatus.Text = "";
        }
    }
}
