using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LprWindowsXpClient
{
    public partial class Form1 : Form
    {

        String lprWsAddress = "http://sri.leidosweb.com/DashCon/resources/lpr";
        String imageWsAddress = "http://sri.leidosweb.com/DashCon/resources/lpr/saveImage";
        String path = @"c:\ToGatekeeper";
        FileSystemWatcher watcher;
        LicensePlate lp = new LicensePlate()
        {
            fileName = "default.jpg",
            licensePlateNumber = "THX1138",
            sequenceNumber = 999999,
            siteId = 1,
            timestamp = "2015-01-01 12:00:00"
        };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                watcher = new FileSystemWatcher();
                watcher.Path = path;

                // Watch for all changes specified in the NotifyFilters
                //enumeration.
                watcher.NotifyFilter = NotifyFilters.Attributes |
                                        NotifyFilters.CreationTime |
                                        NotifyFilters.DirectoryName |
                                        NotifyFilters.FileName |
                                        NotifyFilters.LastAccess |
                                        NotifyFilters.LastWrite |
                                        NotifyFilters.Security |
                                        NotifyFilters.Size;

                watcher.Filter = "*.*";
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString() + Environment.NewLine);
                Console.WriteLine(ex.StackTrace + Environment.NewLine);

                AppendText(ex.ToString() + Environment.NewLine);
                AppendText(ex.StackTrace + Environment.NewLine);
         
            }
        }

        // This method requires that the jpg file come first.  If not this whole algorithm blows up
        private void OnCreated(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is created.
            Console.WriteLine("{0}, with path {1} has been {2}", e.Name, e.FullPath, e.ChangeType);
            AppendText(e.Name + ", with path " + e.FullPath + " has been " + e.ChangeType + Environment.NewLine);

            if (e.Name.Contains("txt"))
            {

                String textFileFullPath = e.FullPath;

                AppendText("processing file : " + textFileFullPath + Environment.NewLine);

                // Wait if text file is still open
                FileInfo textFileInfo = new FileInfo(textFileFullPath);
                Console.WriteLine("Text File Info");
                AppendText("Text File Info" + Environment.NewLine);
                Console.WriteLine("IsFileLocked(fileInfo) -> " + IsFileLocked(textFileInfo) + Environment.NewLine);
                AppendText("IsFileLocked(fileInfo) -> " + IsFileLocked(textFileInfo) + Environment.NewLine);
                while (IsFileLocked(textFileInfo))
                {
                    Thread.Sleep(500);
                }
                
                processTextFile(e);

                // Wait if image file is still open
                String imageFileFullPath = e.FullPath.Replace("txt", "jpg");
                FileInfo imageFileInfo = new FileInfo(imageFileFullPath);
                Console.WriteLine("Image File Info");
                AppendText("Image File Info" + Environment.NewLine);
                Console.WriteLine("IsFileLocked(fileInfo) -> " + IsFileLocked(imageFileInfo) + Environment.NewLine);
                AppendText("IsFileLocked(fileInfo) -> " + IsFileLocked(imageFileInfo) + Environment.NewLine);
                while (IsFileLocked(imageFileInfo))
                {
                    Thread.Sleep(500);
                }

                FileStream fs = new FileStream(imageFileFullPath, FileMode.Open, FileAccess.Read);
                processImageFile(fs);

                AppendText(Environment.NewLine);
            }
        }

        private void processTextFile(FileSystemEventArgs e)
        {
            AppendText("Start processing text file." + Environment.NewLine);
            Console.WriteLine("Start processing text file." + Environment.NewLine);

            string txt;

            // the image file came in first so use the name of the image file to find the text file
            Boolean isImageFile = e.Name.ToUpper().Contains(".JPG");

            txt = File.ReadAllText(e.FullPath);
            string[] items = txt.Split(',');

            lp = new LicensePlate();
            lp.licensePlateNumber = items[0];
            lp.siteId = 2;
            lp.fileName = e.Name;
            lp.timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            String json = JsonConvert.SerializeObject(lp);
            AppendText(json + Environment.NewLine);
            Console.WriteLine(json + Environment.NewLine);

            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String resp = client.UploadString(lprWsAddress, json);
            AppendText("resp -> " + resp + Environment.NewLine);
            Console.WriteLine("resp -> " + resp + Environment.NewLine);

            var licensePlate = JsonConvert.DeserializeObject<LicensePlate>(resp);
            lp.id = licensePlate.id;

            AppendText("End processing text file." + Environment.NewLine);
            Console.WriteLine("End processing text file." + Environment.NewLine);

        }

        private void processImageFile(FileStream _fs)
        {
            try {
                AppendText("Start processing image file." + Environment.NewLine);
                Console.WriteLine("Start processing image file." + Environment.NewLine);

                 // Read file data
                byte[] data = new byte[_fs.Length];
                _fs.Read(data, 0, data.Length);
                AppendText(_fs.Name + Environment.NewLine);
                Console.WriteLine(_fs.Name + Environment.NewLine);
                _fs.Close();

                // Generate post objects
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("imageId", lp.id);
                postParameters.Add("file", new FormUpload.FileParameter(data, "foo.jpg", "image/jpg"));

                // Create request and receive response
                HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(imageWsAddress, "Someone", postParameters);

                // Process response
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string fullResponse = responseReader.ReadToEnd();
                webResponse.Close();
                AppendText("Full Response -> " + fullResponse + Environment.NewLine);
                AppendText("End processing image file." + Environment.NewLine);

                Console.WriteLine("Full Response -> " + fullResponse + Environment.NewLine);
                Console.WriteLine("End processing image file." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + Environment.NewLine);
                Console.WriteLine(ex.StackTrace + Environment.NewLine);

                AppendText(ex.ToString() + Environment.NewLine);
                AppendText(ex.StackTrace + Environment.NewLine);

            }

        }

        delegate void AppendTextDelegate(string text);
        private void AppendText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new AppendTextDelegate(this.AppendText), new object[] { text });
            }
            else
            {
                textBox1.Text = textBox1.Text += text;
            }
        }

        static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open,
                         FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            //file is not locked
            return false;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
