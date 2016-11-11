using System;
using System.IO;
using System.Net;

namespace Lakshya_Yatra
{
    public struct ListItem
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
    }
    public class User
    {
        private static User _instance = null;
        private User() { }

        public static User Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new User();
                }
                return _instance;
            }
        }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string User_Name { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
    }
    public class Utilities
    {        
        private static Utilities _instance = null;
        private Utilities() { }

        public static Utilities Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Utilities();
                }
                return _instance;
            }
        }

        public void WriteLog(string message)
        {
            return;
            FileStream fs = null;
            StreamWriter sr = null;
            try
            {
                string filePath = @"D:\" + DateTime.Now.ToString("dd_MMM_yyyy") + ".Log";
                using(fs = new FileStream(filePath,FileMode.Append,FileAccess.Write))
                {
                    using (sr = new StreamWriter(fs))
                    {
                        sr.WriteLine(DateTime.Now.ToString());
                        sr.WriteLine(message);
                        sr.WriteLine("-----------------------------------------------");
                        sr.Close();
                    }
                    fs.Close();
                }

            }
            catch(IOException ioException)
            {
                System.Windows.Forms.MessageBox.Show("Error in writing Log : \n" + ioException.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        public string SendSMSUsingBS(string firstName, string lastName, string date, string time, string route, string mobileNumber, string vehicleNumber = "", string seatNo = "")
        {
            string xmlResult = "";
            try
            {
                string xmlUrl = null;
                xmlUrl = "http://203.129.203.243/blank/sms/user/urlsmstemp.php?username=lakshyap&pass=123456789&senderid=LAKSHY&dest_mobileno=";
                xmlUrl += mobileNumber + "&tempid=48525&F1=" + firstName + " " + lastName + "&F2=" + date + "&F3=" + vehicleNumber + "&F4=" + seatNo + "&F5=" + time + "&F6=" + route + "&response=Y";


                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(xmlUrl);

                myWebRequest.Method = "POST";
                myWebRequest.ContentType = "text/xml";

                //read the response
                using (StreamReader responseReader = new StreamReader(myWebRequest.GetResponse().GetResponseStream()))
                {
                    xmlResult = responseReader.ReadToEnd().Trim();
                    responseReader.Close();
                }
            }
            catch (Exception ex)
            {
                xmlResult = ex.Message;
            }
            return xmlResult;
        }

        public string SendCustomSMS(string message, string mobileNumber)
        {
            string xmlResult = "";
            try
            {
                string xmlUrl = null;
                xmlUrl = "http://203.129.203.243/blank/sms/user/urlsms.php?username=lakshyap&pass=123456789&senderid=LAKSHY&dest_mobileno=";
                xmlUrl += mobileNumber + "&message=" + message + "&response=Y";


                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(xmlUrl);

                myWebRequest.Method = "POST";
                myWebRequest.ContentType = "text/xml";

                //read the response
                using (StreamReader responseReader = new StreamReader(myWebRequest.GetResponse().GetResponseStream()))
                {
                    xmlResult = responseReader.ReadToEnd().Trim();
                    responseReader.Close();
                }
            }
            catch (Exception ex)
            {
                xmlResult = ex.Message;
            }
            return xmlResult;
        }
    }
}
