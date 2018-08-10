using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.IO;

namespace TendekaObjectiveTask1
{
    public partial class Form1 : Form
    {
        //Declaring a Dictionary to store the and reterive the values where Depths are keys and Temperature,Stokes,AntiStokes are Values.
        Dictionary<string, string> dic = new Dictionary<string, string>();
        string strFileName;  //Declared a gloable variable to store the file path
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //used to open a dialog box feom file system.
            if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK) //if selected a file then this will be true 
            {
                try  //using exception handling concepts to catch the parsing exceptions that occure due to invalid file format
                {
                    strFileName = openFileDialog1.FileName;
                    string ext = Path.GetExtension(strFileName).ToLower();
                    if((ext==".xml")) // Checking for correct file format i.e xml or json format only
                    {
                        lblParseError.Text = string.Empty;
                        // loadJson();
                        xmlParser(); //calling this method to parse the xml file 
                        //jsonParser();
                        visibility(); //calling a method to make all the controls visible
                    }
                    else
                    {
                        lblParseError.Text = string.Empty;
                        lblParseError.Text = "File Format not supported, Only XML and JSON";
                        
                    }
                   
                }
                catch(Exception ex)
                {
                    lblParseError.Text = string.Empty;
                    lblParseError.Text = "File was not in correct format try to open correct file";
                    ErrorLogging(ex);         //Logging the errors to the file system
                    //Rather than storing the error to the file system we can store them to the Event Viewer where we can have all types of errors.
                }
                finally
                {

                }
                
            }
            else
            {

            }
        }
        private void visibility()
        {
            lblFiberName.Visible = true;
            txtDisplayName.Visible = true;
            button2.Visible = true;
            lstDepth.Visible = true;
            lblSelectDepth.Visible = true;
        }
        private void xmlParser()
        {
            XDocument document1 = XDocument.Load(strFileName, LoadOptions.None);//Loading the xml file
            //getting the name of the fo=iber by using descendants
            XElement element= document1.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("dtsInstalledSystemSet").Descendants("dtsInstalledSystem").Descendants("name").FirstOrDefault();
            string name = element.Value;
            txtDisplayName.Text = name;
           // XDocument document1 = XDocument.Load(strFileName, LoadOptions.None);
           //storing the datalog values as array of XElement
            XElement[] element1 = document1.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("wellLogSet").Descendants("wellLog").Descendants("logData").Descendants("data").ToArray();
           for(int i=0;i<element1.Length;i++)//looping through each element and retreiving the Depth, Temperature ,Stokes, Anti-Stokes values and storing them in a dictionery.
            {
                string items = element1[i].ToString();
                items = items.Replace("<data id=", "").Replace("</data>", "");
                string[] items1 = items.Split('>');
                string[] values = items1[1].Split(',');
                dic.Add(values[0], values[1] + " "+ values[2]+" "+values[3]);
                //MessageBox.Show(values[0] + "\n " + values[1] + "\n " + values[2] + "\n " + values[3]);
                
            }
            Dictionary<string, string>.KeyCollection keys = dic.Keys;
            foreach (string key in keys) //looping through all the keys in the dictionary i.e all the Depths to display them on to ListBox
            {
                lstDepth.Items.Add(key);
                //Console.WriteLine("Key: {0}", key);
            }

        }
        public void loadJson()
        {
            using (StreamReader r = new StreamReader(strFileName))
            {
                string json = r.ReadToEnd();
                //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach(var item in array)
                {
                    MessageBox.Show(item[0].wellSet[0].well[0].wellboreSet[0].wellbore[0]);
                }
            }
        }
        private void jsonParser()
        {

            //StreamReader r = new StreamReader(strFileName);
            //string json = r.ReadToEnd();

            //Newtonsoft.Json.Linq.JObject ser = Newtonsoft.Json.Linq.JObject.Parse(json);
            //List<Newtonsoft.Json.Linq.JToken> data = ser.Children().ToList();
            //var rateInfo = JSON["WITSMLComposite"]["wellSet"]["well"]["wellboreSet"]["wellbore"]["dtsInstalledSystemSet"]["dtsInstalledSystem"]["name"];
           
            
            
            
            ////foreach(Newtonsoft.Json.Linq.JProperty item in data)
            //{
            //    item.CreateReader();
            //    switch (item.Name)
            //    {
            //        case "children_dtaa": ReadTree(Item);

            //    }
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //saving the xml file after modifying the FiberName
                XDocument document = XDocument.Load(strFileName, LoadOptions.None);
                XElement element = document.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("dtsInstalledSystemSet").Descendants("dtsInstalledSystem").Descendants("name").FirstOrDefault();
                element.Value = txtDisplayName.Text;
                document.Save(strFileName);
                MessageBox.Show(" Saved the file successfully with Fiber Name " + element.Value);
            }
            catch(Exception ex)
            {
                ErrorLogging(ex);
            }
           
        }
        private void lstDepth_SelectedValueChanged(object sender, EventArgs e)
        {
            //Used to display the Temperature, Stokes, Anti-Stokes in chart
            chart1.Series.Clear();
            chart1.Series.Add("Log Data");
            string value = dic[lstDepth.SelectedItem.ToString()];
            string[] details = value.Split(' ');
            decimal temp=Convert.ToDecimal(details[0]);
            decimal stoke= Convert.ToDecimal(details[1]); ;
            decimal aStoke= Convert.ToDecimal(details[2]); ;
            lblDisplay.Text = value;
            chart1.Visible = true;
            lblDepth.Visible = true;
            lblDepthDisplay.Text = lstDepth.SelectedItem.ToString(); ;
            chart1.Series["Log Data"].Points.AddXY("Temperature \n"+temp ,temp);
            chart1.Series["Log Data"].Points.AddXY("Stokes \n"+stoke, stoke);
            chart1.Series["Log Data"].Points.AddXY("Anti-Stoke \n"+aStoke, aStoke);
            
        }
        private  void ErrorLogging(Exception ex)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//getting the desktop path to store the Error Log file
            desktopPath += "\\Log.txt";
            //string strPath = @"D:\Rekha\Log.txt";
            if (!File.Exists(desktopPath))   // if  file not exists then create new one else appends the errors text to the file.
            {
                File.Create(desktopPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(desktopPath))
            {
                sw.WriteLine("\n\n      Logging the Errors    Start Time " + DateTime.Now);
                sw.WriteLine("====================================================================== \n" );
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("====================================================================== ");
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("====================================================================== \n " );
                sw.WriteLine("     Logging Done      End Time " + DateTime.Now+"\n");
            }
        }
    }
}
