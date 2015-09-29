using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Aspen2eCitation.aspen;
using iyeTek.LEMSFramework.ClientAPI;
using iyeTek.LEMSFramework.ClientAPI.Messages;

namespace Aspen2eCitation.eCitation
{
    class eCitationConverter
    {
        public static void convertAspenData2eCitationData(Inspmain _inspmain)
        {
            FileInfo fileInfo = new FileInfo(Properties.Settings.Default.iyeTekLocation + "\\iyeTek.MessageHook.dll");

            FileInfo fileInfo2 = new FileInfo(Properties.Settings.Default.iyeTekLocation2 + "\\iyeTek.MessageHook.dll");
            
            if (!fileInfo.Exists && !fileInfo2.Exists)
            {
                DialogResult result = MessageBox.Show("Unable to locate iyeTek Software.  Find directory?", 
                    "Required software error", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult fbdResult = fbd.ShowDialog();
                    if (fbdResult == DialogResult.OK) {
                        Properties.Settings.Default.iyeTekLocation = fbd.SelectedPath;
                        MessageBox.Show("Udated iyeTek location to "+ fbd.SelectedPath + "  Please, search again.", "Path");
                    }
                }
            }
            else
            {
                String defaultIyeTekLocation = (fileInfo.Exists ? Properties.Settings.Default.iyeTekLocation : Properties.Settings.Default.iyeTekLocation2);

                Client client = new Client();
                client.ApplicationDirectory = defaultIyeTekLocation;

                FileInfo fi = new FileInfo(@"C:\\Aspen2eCitation\\log.txt");
                DirectoryInfo di = new DirectoryInfo(@"C:\\Aspen2eCitation");
                if (!di.Exists)
                {
                    di.Create();
                }
                if (!fi.Exists)
                {
                    fi.Create().Dispose();
                }
                client.EnableTrace(@"C:\\Aspen2eCitation\\log.txt", true);

                if (!client.IsApplicationRunning)
                {
                    MessageBox.Show("iyeCitation must be running for this program to work."
                        + Environment.NewLine + "Please, open iyeCitation and try again.");
                }
                else
                {
                    client.SendMessage(convertPerson(_inspmain));
                    Form1._Form1.appendStatus("Sent to eCitation");
                    Form1._Form1.appendStatus("----------------------------------------");
                    Form1._Form1.appendStatus("Inspection # - " + _inspmain.rptnum);
                    Form1._Form1.appendStatus(
                        "Driver, " + _inspmain.driverfname + " "
                        + _inspmain.driverlname);
                    client.SendMessage(convertVehicle(_inspmain.vehicle));
                    Form1._Form1.appendStatus(
                        "Vehicle, " + _inspmain.vehicle.unitlicnum);
                    System.Threading.Thread.Sleep(3000);
                }

                client.Close();
            }
        }

        private static LEINLoadResponseVehicleMessage convertVehicle(Aspen2eCitation.aspen.Vehicle _vehicle)
        {
            LEINLoadResponseVehicleMessage vehicleMessage = new LEINLoadResponseVehicleMessage();
            vehicleMessage.Response.Data.PlateNumber = _vehicle.unitlicnum;
            vehicleMessage.Response.Data.PlateState = _vehicle.unitlicstate;
            vehicleMessage.Response.Data.Make = _vehicle.unitmake;
            vehicleMessage.Response.Data.Type = _vehicle.unittype;
            if (!String.IsNullOrWhiteSpace(_vehicle.unityear))
            {
                vehicleMessage.Response.Data.VehicleYear = Convert.ToInt16(_vehicle.unityear); ;
            }
            vehicleMessage.Response.Data.VIN = _vehicle.unitvin;
            vehicleMessage.Response.MessageText = "Vehicle was imported through Aspen2iyeCitation.  "
                + "Please, verify all data is correct before sumbitting.";

            return vehicleMessage;
        }

        private static LEINLoadResponsePersonMessage convertPerson(Inspmain _inspection)
        {
            LEINLoadResponsePersonMessage person = new LEINLoadResponsePersonMessage();

            person.Response.Data.FirstName = _inspection.driverfname;
            person.Response.Data.LastName = _inspection.driverlname;
            //person.Response.Data.DateOfBirth = "12/12/1982";  it's all brokee!
            person.Response.Data.DriverLicense = _inspection.driverlicnum;
            person.Response.Data.DriverLicenseState = _inspection.driverlicstate;
            person.Response.MessageText = "Driver was imported through Aspen2iyeCitation.  "
                + "Please, verify all data is correct before sumbitting.";

            return person;
        }
    }
}
