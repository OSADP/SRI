using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Aspen2eCitation.aspen
{
    class AspenDao
    {

        
        FbConnection conn;
        Inspmain inspmain;
        FbCommand comm;
        FbDataReader reader;
        Boolean isAspenLoaded = false;

        public Inspmain getLatestAspenRecord()
        {
            String defaultAspenDbLocation = Properties.Settings.Default.aspenDbLocation;
            String defaultAspenDbFileLocation = Properties.Settings.Default.aspenDbFileLocation;
            FileInfo fileInfo = new FileInfo(defaultAspenDbFileLocation);
            if (!fileInfo.Exists)
            {
                isAspenLoaded = false;

                DialogResult result = MessageBox.Show("Unable to locate the Aspen 3.0 database."
                    + Environment.NewLine + "Find Aspen database?",
                    "Required software error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    // Set filter options and filter index.
                    ofd.Filter = "Aspen DataBase (ASPEN_DATA.FDB)|ASPEN_DATA.FDB";
                    ofd.FilterIndex = 1; 
                    
                    DialogResult fbdResult = ofd.ShowDialog();
                    if (fbdResult == DialogResult.OK)
                    {
                        Properties.Settings.Default.aspenDbFileLocation = ofd.FileName;
                        MessageBox.Show("Updated Aspen 3.0 database location to " +
                            ofd.FileName + "  Please, search again.", "Path");
                    }
                }
            }
            else
            {
                isAspenLoaded = true;

                String connectionString = 
                    Properties.Settings.Default.connectionString + 
                    Properties.Settings.Default.aspenDbLocation;
                inspmain = null;
                conn = new FbConnection(connectionString);
                try
                {
                    conn.Open();

                    comm = new FbCommand();
                    comm.CommandText =
                        "select first 1 * " +
                        "from inspmain i " +
                        "inner join vehicle v on i.rptnum = v.rptnum";
                    comm.Connection = conn;
                    reader = comm.ExecuteReader();

                    inspmain = AspenMapper.mapInspection(reader);

                    reader.Close();
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.StackTrace);
                    MessageBox.Show(
                        "Unable to find the Aspen 3.0 database." + 
                        Environment.NewLine + 
                        "Aspen 3.0 or later is required for the importer to function.",
                        "Aspen Installation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    MessageBox.Show(x.StackTrace,
                        "Aspen Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    conn.Close();
                }
            }
            return inspmain;
        }

        public Inspmain getAspenRecord(String _usdot)
        {
            String defaultAspenDbLocation = Properties.Settings.Default.aspenDbLocation;
            String defaultAspenDbFileLocation = Properties.Settings.Default.aspenDbFileLocation;
            FileInfo fileInfo = new FileInfo(defaultAspenDbFileLocation);
            if (!fileInfo.Exists)
            {
                DialogResult result = MessageBox.Show("Unable to locate the Aspen 3.0 database."
                    + Environment.NewLine + "Find Aspen database?",
                    "Required software error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult fbdResult = fbd.ShowDialog();
                    if (fbdResult == DialogResult.OK)
                    {
                        Properties.Settings.Default.aspenDbFileLocation = fbd.SelectedPath;
                        MessageBox.Show("Updated Aspen 3.0 database location to " +
                            fbd.SelectedPath + "  Please, search again.", "Path");
                    }
                }
            }
            else
            {
                String connectionString =
                    Properties.Settings.Default.connectionString +
                    Properties.Settings.Default.aspenDbLocation;
                inspmain = null;
                conn = new FbConnection(connectionString);
                try
                {
                    conn.Open();

                    comm = new FbCommand();
                    comm.CommandText =
                        "select * " +
                        "from inspmain i " +
                        "inner join vehicle v on i.rptnum = v.rptnum " +
                        "where i.rptnum = \'" + _usdot + "\'";
                    comm.Connection = conn;
                    reader = comm.ExecuteReader();

                    inspmain = AspenMapper.mapInspection(reader);

                    reader.Close();
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.StackTrace);
                    MessageBox.Show(
                        "Unable to find the Aspen 3.0 database." +
                        Environment.NewLine +
                        "Aspen 3.0 or later is required for the importer to function.",
                        "Aspen Installation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    MessageBox.Show(x.StackTrace,
                        "Aspen Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    conn.Close();
                }
            }
            return inspmain;
        }
    }
}
