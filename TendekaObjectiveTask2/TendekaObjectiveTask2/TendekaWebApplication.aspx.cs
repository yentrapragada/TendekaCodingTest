using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;


namespace TendekaObjectiveTask2
{
    public partial class TendekaWebApplication : System.Web.UI.Page
    {
        string filePath;
        Dictionary<string, string> dic = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
               
            }
        }

        public void FileUpload1_Load(object sender, EventArgs e)
        {
           
        }

        public void btnOpenFile_Click(object sender, EventArgs e)
        {
            
            if(FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                if(ext==".xml")
                {
                    try
                    {
                        lblNoFileError.Text = string.Empty;
                        lblNoFileError.Visible = false;
                        FileUpload1.SaveAs(Server.MapPath("~/Files/") + FileUpload1.PostedFile.FileName);
                        filePath = Server.MapPath("~/Files/") + FileUpload1.PostedFile.FileName;
                        Session["fileName"] = FileUpload1.FileName;
                        Session["filePath"] = filePath;
                        XmlParser();
                    }
                    catch (Exception ex)
                    {
                        Invisibility();
                        lblNoFileError.Text = string.Empty;
                        lblNoFileError.Visible = true;
                        lblNoFileError.Text = "Some Errored occured and our team is working on it ";
                        ErrorLogging(ex);
                    }
                }
                else
                {
                    Invisibility();
                    lblNoFileError.Text = string.Empty;
                    lblNoFileError.Visible = true;
                    lblNoFileError.Text = "File Format not supported, Only XML and JSON";

                }
                
            }
            else
            {
                lblNoFileError.Text = string.Empty;
                lblNoFileError.Visible = true;
                lblNoFileError.Text = "No file ";
            }

            //filePath= (FileUpload1.PostedFile.FileName);
            //filePath = Server.MapPath(FileUpload1.PostedFile.FileName);

           
            
        }
        private void visibility()
        {
            chart1.Visible = true;
            lblDepts.Visible = true;
            lblDepthDisplay.Visible = true;
            ddlDepths.Visible = true;
            btnSave.Visible = true;
            txtDisplayName.Visible = true;
            lblFiberName.Visible = true;
            lblDepthValues.Visible = true;
        }
        private void Invisibility()
        {
            chart1.Visible = false;
            lblDepts.Visible = false;
            lblDepthDisplay.Visible = false;
            ddlDepths.Visible = false;
            btnSave.Visible = false;
            txtDisplayName.Visible = false;
            lblFiberName.Visible = false;
            lblDepthValues.Visible = false;
            divError.InnerText = string.Empty;
        }
        public void XmlParser()
        {
            try
            {
                divError.InnerText = string.Empty;
                lblNoFileError.Text = string.Empty;
                lblNoFileError.Visible = false;
                //XmlDocument doc = new XmlDocument();
                //doc.Load(filePath);

                XDocument document1 = XDocument.Load(filePath);//Loading the xml file
                                                               //getting the name of the fo=iber by using descendants
                XElement element = document1.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("dtsInstalledSystemSet").Descendants("dtsInstalledSystem").Descendants("name").FirstOrDefault();
                string name = element.Value;
                txtDisplayName.Text = name;
                // XDocument document1 = XDocument.Load(strFileName, LoadOptions.None);
                //storing the datalog values as array of XElement
                XElement[] element1 = document1.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("wellLogSet").Descendants("wellLog").Descendants("logData").Descendants("data").ToArray();
                for (int i = 0; i < element1.Length; i++)//looping through each element and retreiving the Depth, Temperature ,Stokes, Anti-Stokes values and storing them in a dictionery.
                {
                    string items = element1[i].ToString();
                    items = items.Replace("<data id=", "").Replace("</data>", "");
                    string[] items1 = items.Split('>');
                    string[] values = items1[1].Split(',');
                    dic.Add(values[0], values[1] + " " + values[2] + " " + values[3]);
                    //MessageBox.Show(values[0] + "\n " + values[1] + "\n " + values[2] + "\n " + values[3]);

                }
                //Session["values"] = dic;
                Dictionary<string, string>.KeyCollection keys = dic.Keys;
                foreach (string key in keys) //looping through all the keys in the dictionary i.e all the Depths to display them on to ListBox
                {
                    ddlDepths.Items.Add(key);
                    //Console.WriteLine("Key: {0}", key);
                }
                string firstKey = dic.Keys.FirstOrDefault();
                displayCharts(firstKey);
                visibility();
            }
            catch(Exception ex)
            {
                Invisibility();
                lblNoFileError.Text = string.Empty;
                lblNoFileError.Visible = true;
                lblNoFileError.Text= "File was not in correct format try to open correct file";
                ErrorLogging(ex);
            }
           
        }
        public void XmlParser1()
        {
            try
            {
                divError.InnerText = string.Empty;
                lblNoFileError.Text = string.Empty;
                lblNoFileError.Visible = false;
                //XmlDocument doc = new XmlDocument();
                //doc.Load(filePath);

                XDocument document1 = XDocument.Load(filePath);//Loading the xml file
                                                               //getting the name of the fo=iber by using descendants
                XElement element = document1.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("dtsInstalledSystemSet").Descendants("dtsInstalledSystem").Descendants("name").FirstOrDefault();
                string name = element.Value;
                txtDisplayName.Text = name;
                // XDocument document1 = XDocument.Load(strFileName, LoadOptions.None);
                //storing the datalog values as array of XElement
                XElement[] element1 = document1.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("wellLogSet").Descendants("wellLog").Descendants("logData").Descendants("data").ToArray();
                for (int i = 0; i < element1.Length; i++)//looping through each element and retreiving the Depth, Temperature ,Stokes, Anti-Stokes values and storing them in a dictionery.
                {
                    string items = element1[i].ToString();
                    items = items.Replace("<data id=", "").Replace("</data>", "");
                    string[] items1 = items.Split('>');
                    string[] values = items1[1].Split(',');
                    dic.Add(values[0], values[1] + " " + values[2] + " " + values[3]);
                    //MessageBox.Show(values[0] + "\n " + values[1] + "\n " + values[2] + "\n " + values[3]);

                }
                //Session["values"] = dic;
                Dictionary<string, string>.KeyCollection keys = dic.Keys;
                foreach (string key in keys) //looping through all the keys in the dictionary i.e all the Depths to display them on to ListBox
                {
                    ddlDepths.Items.Add(key);
                    //Console.WriteLine("Key: {0}", key);
                }
                visibility();
            }
            catch (Exception ex)
            {
                Invisibility();
                lblNoFileError.Text = string.Empty;
                lblNoFileError.Visible = true;
                lblNoFileError.Text = "some error occured and developing team is looking over it";
                ErrorLogging(ex);
            }
           
          
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                divError.InnerText = string.Empty;
                //saving the xml file after modifying the FiberName
                XDocument document = XDocument.Load(Session["filePath"].ToString(), LoadOptions.None);
                XElement element = document.Descendants("wellSet").Descendants("well").Descendants("wellboreSet").Descendants("wellbore").Descendants("dtsInstalledSystemSet").Descendants("dtsInstalledSystem").Descendants("name").FirstOrDefault();
                element.Value = txtDisplayName.Text;
                document.Save(Session["filePath"].ToString());
                //MessageBox.Show(" Saved the file successfully with Fiber Name " + element.Value);

                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + Session["fileName"].ToString());
                Response.TransmitFile(Session["filePath"].ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Invisibility();
               ErrorLogging(ex);
            }

            
        }
        public void ErrorLogging(Exception ex)
        {
            divError.InnerText = string.Empty;
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
                sw.WriteLine("====================================================================== \n");
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("====================================================================== ");
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("====================================================================== \n ");
                sw.WriteLine("     Logging Done      End Time " + DateTime.Now + "\n");
            }

            //Adding exception details to Div

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "function('x')", true);

            divError.InnerText = ex.Message;
        }
        protected void displayCharts(string firstKey)
        {
            chart1.Series.Clear();
            chart1.Series.Add("Log Data");
            //filePath = Session["filePath"].ToString();
           // XmlParser();
            string value = dic[firstKey];
            string[] details = value.Split(' ');
            decimal temp = Convert.ToDecimal(details[0]);
            decimal stoke = Convert.ToDecimal(details[1]); ;
            decimal aStoke = Convert.ToDecimal(details[2]); ;
            //lblDisplay.Text = value;
            chart1.Visible = true;
            // lblDepth.Visible = true;
            lblDepthDisplay.Text = ddlDepths.SelectedItem.Text.ToString(); ;
            chart1.Series["Log Data"].Points.AddXY("Temperature \n" + temp, temp);
            chart1.Series["Log Data"].Points.AddXY("Stokes \n" + stoke, stoke);
            chart1.Series["Log Data"].Points.AddXY("Anti-Stoke \n" + aStoke, aStoke);
        }
        public void ddlDepths_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Used to display the Temperature, Stokes, Anti-Stokes in chart
            chart1.Series.Clear();
            chart1.Series.Add("Log Data");
            filePath = Session["filePath"].ToString();
            XmlParser1();
            string value = dic[ddlDepths.SelectedItem.Text.ToString()];
            string[] details = value.Split(' ');
            decimal temp = Convert.ToDecimal(details[0]);
            decimal stoke = Convert.ToDecimal(details[1]); ;
            decimal aStoke = Convert.ToDecimal(details[2]); ;
            //lblDisplay.Text = value;
            chart1.Visible = true;
            // lblDepth.Visible = true;
            lblDepthDisplay.Text = ddlDepths.SelectedItem.Text.ToString(); ;
            chart1.Series["Log Data"].Points.AddXY("Temperature \n" + temp, temp);
            chart1.Series["Log Data"].Points.AddXY("Stokes \n" + stoke, stoke);
            chart1.Series["Log Data"].Points.AddXY("Anti-Stoke \n" + aStoke, aStoke);
        }
       
    }
}