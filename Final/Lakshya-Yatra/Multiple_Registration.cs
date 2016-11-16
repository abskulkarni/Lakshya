using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Lakshya_Yatra
{
    public partial class Multiple_Registration : Form
    {
        private FilterInfoCollection cameraCollection = null;
        private VideoCaptureDevice camera = null;
        string imagesFolder = string.Empty;
        string busRoute = string.Empty;

        AutoCompleteStringCollection autoCompleteCollectionFirstName = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autoCompleteCollectionLastName = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autoCompleteCollectionAddress = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autoCompleteCollectionMobile = new AutoCompleteStringCollection();
        AutoCompleteStringCollection autoCompleteCollectionAlternateMobile = new AutoCompleteStringCollection();

        BusinessRules objBusinessRules = new BusinessRules();

        string print_CustomerID;
        string print_Bus_Name;
        string print_Seat_No;
        string print_Yatra_Date;
        string print_Name;
        string print_Address;

        DataSet dsAllCustomers = new DataSet();
        private string submitMode { get; set; }
        public int Customer_ID { get; set; }
        public int Bus_Master_ID { get; set; }

        private byte[] Auto_Time;

        Image img;
        bool imageCaptured = false;
        
        struct Resolutions
        {
            public int ID { get; set; }
            public string Resolution { get; set; }
        }
        Resolutions availableResultion;

        public Multiple_Registration()
        {
            InitializeComponent();
        }
        
        private void Registration_Load(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Loading Registration Form");
            grpRegistrationDetails.BackColor = grpPicture.BackColor = grpTravelDetails.BackColor = label1.BackColor = lblBusTime.BackColor = Color.Transparent;
            imagesFolder = ConfigurationManager.AppSettings["ImagesFolder"];
            dgvTickets.AutoGenerateColumns = false;

            dsAllCustomers = objBusinessRules.getAllCustomers();

            ExtractAutoCompleteStringCollections();

            timer1.Start();
            if (Customer_ID == 0 && Bus_Master_ID == 0)
                InitializeForm(true);
        }
        
        public void InitializeForm(bool formLoad = false)
        {
            try
            {
                Utilities.Instance.WriteLog("Entered InitializeForm : formLoad=" + formLoad.ToString());
                submitMode = "Add";
                HideShowSearchCustomer("hide");
                lblCustomerID.Text = "New Customer";
                chkDontKnowBirthdate.Checked = true; dtpBirthDate.Enabled = false;

                chkDontKnowAlternateMobile.Checked = true; txtAlternateMobileNo.Enabled = false;

                chkDontKnowBloodGroup.Checked = true; cbBloodGroup.Enabled = false; cbBloodGroup.SelectedIndex = -1;
                imageCaptured = false;
                //groupBoxPrint.Visible = false;
                btnPrint.Visible = false;
                dtpBirthDate.MaxDate = DateTime.Now.Date;
                //dtpBirthDate.Checked = false;
                txtRegistrationDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                //cbNavratraDate.SelectedIndex = -1;
                //txtFirstName.Text = txtLastName.Text = txtMobileNo.Text = txtFees.Text = txtAge.Text = txtAddress.Text = txtAlternateMobileNo.Text = string.Empty;
                
                Utilities.Instance.WriteLog("Cleared control values");

                dtpBirthDate.MaxDate = DateTime.Now.Date;

                SetNoImageForAll();
                Utilities.Instance.WriteLog("Set No Image for three images");

                ResetTravelDetails();
                Utilities.Instance.WriteLog("Called date value changed event");

                GetAreas();

                if (formLoad)
                {
                    Utilities.Instance.WriteLog("Entered Camera Initialization snippet");
                    cbCamera.Items.Clear();
                    cbResolution.Items.Clear();
                    cameraCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    foreach (FilterInfo videoDevice in cameraCollection)
                    {
                        //if (videoDevice.Name.Contains("Face2Face"))
                        cbCamera.Items.Add(videoDevice.Name);
                        Utilities.Instance.WriteLog("Adding names of Video devices");
                    }

                    if (cbCamera.Items.Count > 0)
                    {
                        Utilities.Instance.WriteLog("Setting Camera dropdown index = 0");
                        if (cbCamera.Items.Contains("Face2Face ROBO K20 Webcam"))
                        {
                            cbCamera.SelectedIndex = cbCamera.Items.IndexOf("Face2Face ROBO K20 Webcam");
                        }
                        else
                        {
                            cbCamera.SelectedIndex = 0;
                        }
                    }
                }

                GetCustomerTickets();

                if (Customer_ID > 0 && Bus_Master_ID > 0)
                {
                    Utilities.Instance.WriteLog("Initializing for Customer ID = " + Customer_ID.ToString());
                    submitMode = "Edit";
                    lblCustomerID.Text = Customer_ID.ToString();
                    btnPrint.Visible = true;
                    Utilities.Instance.WriteLog("Calling getCustomerDetails");
                    DataSet ds = objBusinessRules.getCustomerDetails(Customer_ID, Bus_Master_ID);
                    Utilities.Instance.WriteLog("Called getCustomerDetails");
                   // Auto_Time = ds.Tables[0].Rows[0]["Auto_Time"] as byte[];
                    txtRegistrationDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Registration_Date"]).ToString("dd-MMM-yyyy");
                    cbBusRoutes.SelectedValue = Convert.ToInt16(ds.Tables[0].Rows[0]["Route_ID"]);

                    dtpNavratriDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["yatra_date"]).Date;
                    
                    cbArea.SelectedValue = ds.Tables[0].Rows[0]["Area_ID"] != DBNull.Value ? Convert.ToInt16(ds.Tables[0].Rows[0]["Area_ID"]) : 0;

                    txtFirstName.Text = ds.Tables[0].Rows[0]["First_Name"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    //txtAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Birth_Date"].ToString()))
                    {
                        dtpBirthDate.Enabled = true;
                        dtpBirthDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birth_Date"]);
                        chkDontKnowBirthdate.Checked = false;
                    }

                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Blood_Group"].ToString()))
                    {
                        chkDontKnowBloodGroup.Checked = false;
                        cbBloodGroup.SelectedItem = cbBloodGroup.Items[cbBloodGroup.Items.IndexOf(ds.Tables[0].Rows[0]["Blood_Group"].ToString())];
                    }
                    
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["Mobile_No"].ToString();

                    txtAlternateMobileNo.Text = ds.Tables[0].Rows[0]["Alternate_Mobile"].ToString();
                    chkDontKnowAlternateMobile.Checked = string.IsNullOrEmpty(txtAlternateMobileNo.Text.Trim());
                    Utilities.Instance.WriteLog("Setting Snapshot image");
                    SetCustomerImage();

                    if (cbBus.Items.IndexOf(ds.Tables[0].Rows[0]["Bus_Name"].ToString()) == -1)
                    {
                        cbBus.Items.Add(ds.Tables[0].Rows[0]["Bus_Name"].ToString());
                    }
                    cbBus.SelectedItem = cbBus.Items[cbBus.Items.IndexOf(ds.Tables[0].Rows[0]["Bus_Name"].ToString())];

                    if (cbSeatNo.Items.IndexOf(ds.Tables[0].Rows[0]["Seat_No"].ToString()) == -1)
                    {
                        cbSeatNo.Items.Add(ds.Tables[0].Rows[0]["Seat_No"].ToString());
                    }
                    cbSeatNo.SelectedItem = cbSeatNo.Items[cbSeatNo.Items.IndexOf(ds.Tables[0].Rows[0]["Seat_No"].ToString())];
                    txtFees.Text = ds.Tables[0].Rows[0]["Bus_Fees"].ToString();
                    
                    if (Convert.ToInt16(ds.Tables[0].Rows[0]["Discount"]) > 0)
                    {
                        chkDiscount.Checked = true;
                        txtDiscount.Text = lblOriginalDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                        txtDiscountReason.Text = lblOriginalDiscountReason.Text = ds.Tables[0].Rows[0]["DiscountReason"].ToString();
                    }

                    
                }

                CalculateAge();
                //Customer_ID = 0; Bus_Master_ID = 0; -- Commented for re-opening Edit requirement.
                //txtFirstName.Focus();
                Utilities.Instance.WriteLog("Calling GC Collect : InitializeForm method");
                GC.Collect();
            }
            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in InitializeForm \n" + ex.Message);
                MessageBox.Show(ex.Message);
            }           
        }

        private void GetAreas()
        {
            cbArea.DataSource = objBusinessRules.GetAreas();
            cbArea.DisplayMember = "Area";
            cbArea.ValueMember = "Area_ID";
        }

        private void SetCustomerImage()
        {
            if (System.IO.File.Exists(imagesFolder + Customer_ID.ToString() + ".jpg"))
            {
                using (var bmpTemp = new Bitmap(imagesFolder + Customer_ID.ToString() + ".jpg"))
                {
                    img = new Bitmap(bmpTemp);
                    imgSnapShot.Image = img;
                }
            }
            else
            {
                using (var bmpTemp = new Bitmap(@"Resources\NoImage.png"))
                {
                    img = new Bitmap(bmpTemp);
                    imgSnapShot.Image = img;
                }
            }
        }

        private void ExtractAutoCompleteStringCollections()
        {
            //autoCompleteCollectionAddress.Clear();
            //autoCompleteCollectionAlternateMobile.Clear();
            //autoCompleteCollectionFirstName.Clear();
            //autoCompleteCollectionLastName.Clear();
            //autoCompleteCollectionMobile.Clear();

            //txtFirstName.AutoCompleteSource = AutoCompleteSource.ListItems;


            if (dsAllCustomers.Tables[0].Rows.Count > 0)
                foreach (DataRow dr in dsAllCustomers.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(dr["Address"].ToString()) &&
                        !autoCompleteCollectionAddress.Contains(dr["Address"].ToString()))
                        autoCompleteCollectionAddress.Add(dr["Address"].ToString());

                    if (!string.IsNullOrEmpty(dr["Alternate_Mobile"].ToString()) &&
                        !autoCompleteCollectionAlternateMobile.Contains(dr["Alternate_Mobile"].ToString()))
                        autoCompleteCollectionAlternateMobile.Add(dr["Alternate_Mobile"].ToString());

                    if (!string.IsNullOrEmpty(dr["First_Name"].ToString()) &&
                        !autoCompleteCollectionFirstName.Contains(dr["First_Name"].ToString()))
                        autoCompleteCollectionFirstName.Add(dr["First_Name"].ToString());

                    if (!string.IsNullOrEmpty(dr["Last_Name"].ToString()) &&
                        !autoCompleteCollectionLastName.Contains(dr["Last_Name"].ToString()))
                        autoCompleteCollectionLastName.Add(dr["Last_Name"].ToString());

                    if (!string.IsNullOrEmpty(dr["Mobile_No"].ToString()) &&
                        !autoCompleteCollectionMobile.Contains(dr["Mobile_No"].ToString()))
                        autoCompleteCollectionMobile.Add(dr["Mobile_No"].ToString());
                }

            txtSearchAddress.AutoCompleteCustomSource = autoCompleteCollectionAddress;
            txtAlternateMobileNo.AutoCompleteCustomSource = autoCompleteCollectionAlternateMobile;
            txtFirstName.AutoCompleteCustomSource = autoCompleteCollectionFirstName;
            txtLastName.AutoCompleteCustomSource = autoCompleteCollectionLastName;
            txtMobileNo.AutoCompleteCustomSource = autoCompleteCollectionMobile;
        }

        private void ClearImages()
        {
            Utilities.Instance.WriteLog("Entered ClearImages method");            
            if (imgCapture.Image != null) imgCapture.Image = null;
            if (imgSnapShot.Image != null) imgSnapShot.Image = null;

            GC.Collect();
            Utilities.Instance.WriteLog("Exited ClearImages method");
        }

        private bool Authenticate()
        {
            //int i = cbNavratraDate.SelectedIndex;
            bool result = true;
            //FirstName
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                result = false;
                MessageBox.Show("Please enter First Name.");
                txtFirstName.Focus();
            }

            if (result)
            {
                if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    result = false;
                    MessageBox.Show("Please enter Last Name.");
                    txtLastName.Focus();
                }
            }

            if (result)
            {
                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    result = false;
                    MessageBox.Show("Please enter Address.");
                    txtAddress.Focus();
                }
            }

            if (result)
            {
                if (Convert.ToInt16(cbArea.SelectedValue) == 0)
                {
                    result = false;
                    MessageBox.Show("Please select Area.");
                    txtAddress.Focus();
                }
            }

            if (result)
            {
                if (chkDontKnowBloodGroup.Checked)
                {
                    DialogResult confirmation = MessageBox.Show("Blood group is not selected. Are you sure to continue?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (confirmation == System.Windows.Forms.DialogResult.No)
                        result = false;
                }
            }

            if (result)
            {
                if (!chkDontKnowBloodGroup.Checked && cbBloodGroup.SelectedIndex == -1)
                {
                    result = false;
                    MessageBox.Show("Please select Blood Group.");
                    cbBloodGroup.Focus();
                }
            }

            if (result)
            {
                if (string.IsNullOrEmpty(txtMobileNo.Text))
                {
                    result = false;
                    MessageBox.Show("Please enter Mobile Number.");
                    txtMobileNo.Focus();
                }
            }

            if (result)
            {
                if (txtMobileNo.Text.Trim().Length < 10)
                {
                    result = false;
                    MessageBox.Show("Please enter 10 digit valid Mobile Number.");
                    txtMobileNo.Focus();
                }
            }

            //if (result)
            //{
            //    if (string.IsNullOrEmpty(txtAlternateMobileNo.Text))
            //    {
            //        result = false;
            //        MessageBox.Show("Please enter Alternate Mobile Number.");
            //        txtAlternateMobileNo.Focus();
            //    }
            //}            

            //if (result)
            //{
            //    if (txtAlternateMobileNo.Text.Trim().Length < 10)
            //    {
            //        result = false;
            //        MessageBox.Show("Please enter 10 digit valid Alternate Mobile Number.");
            //        txtAlternateMobileNo.Focus();
            //    }
            //}

            if (result)
            {
                if (cbBus.SelectedIndex == -1)
                {
                    result = false;
                    MessageBox.Show("Please select Bus.");
                    cbBus.Focus();
                }
            }

            if (result)
            {
                if (cbSeatNo.SelectedIndex == -1)
                {
                    result = false;
                    MessageBox.Show("Please select Seat Number.");
                    cbSeatNo.Focus();
                }
            }

            if (result)
            {
                if (chkDiscount.Checked && (string.IsNullOrEmpty(txtDiscount.Text.Trim()) ||
                                            string.IsNullOrEmpty(txtDiscountReason.Text.Trim())))
                {
                    result = false;
                    MessageBox.Show("Please enter discount and reason.");
                    txtDiscount.Focus();
                }
            }

            if (result)
            {
                if (chkDiscount.Checked && Convert.ToInt16(txtDiscount.Text.Trim()) > Convert.ToInt16(txtFees.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Discount cannot be more than Bus Fees");
                    txtDiscount.Focus();
                }
            }

            //if (result)
            //{
            //    if (chkDiscount.Checked && !string.IsNullOrEmpty(lblBusFees.Text) && !string.IsNullOrEmpty(txtFees.Text.Trim()))
            //    {
            //        string t = lblBusFees.Text.Split(":".ToCharArray())[1].Trim().Split(")".ToCharArray())[0].Trim();
            //        if (Convert.ToInt16(t) != Convert.ToInt16(txtFees.Text.Trim()))
            //        {
            //            if (txtDiscount.Text.Trim() != Convert.ToString(Convert.ToInt16(t) - Convert.ToInt16(txtFees.Text.Trim())))
            //            {
            //                result = false;
            //                MessageBox.Show("Discount is not equal to (Bus Fees) - (Fees)");
            //                txtDiscount.Focus();
            //            }
            //        }
            //    }
            //}

            /* Commenting below validation as per new requirements discussed on 18th July 2016
            //if (result)
            //{
            //    if (!imageCaptured && Customer_ID == 0)
            //    {
            //        result = false;
            //        MessageBox.Show("Customer's photo is not captured.");
            //        bntCapture.Focus();
            //    }
            //}
             * */

            return result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entered Submit Click Method");
            if (!Authenticate())
            {
                return;
            }

            try
            {
                //if (txtAge.Text == "0")
                //{
                //    DialogResult confirmation = MessageBox.Show("Age is calculated as 0 years. Make sure Birthdate is entered correct.\nAre you sure to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (confirmation == System.Windows.Forms.DialogResult.No)
                //        return;
                //}

                DateTime strRegistrationDate = Convert.ToDateTime(txtRegistrationDate.Text);
                DateTime strYatraDate = dtpNavratriDate.Value.Date;
                string strFirstName = txtFirstName.Text;
                string strLastName = txtLastName.Text;
                string strAddress = txtAddress.Text;
                Single strAge = 0.0f;// Convert.ToSingle(txtAge.Text);
                //string strBirthDate = dtpBirthDate.Value.ToString("dd-MMM-yyyy");
                DateTime? strBirthDate = null;
                if (!chkDontKnowBirthdate.Checked)
                    strBirthDate = dtpBirthDate.Value;
                string strBloodGroup = string.Empty;
                if (!chkDontKnowBloodGroup.Checked)
                    strBloodGroup = cbBloodGroup.Items[cbBloodGroup.SelectedIndex].ToString();
                string strMobileNo = txtMobileNo.Text;
                string strBusNo = cbBus.Items[cbBus.SelectedIndex].ToString();
                int strSeatNo = int.Parse(cbSeatNo.Items[cbSeatNo.SelectedIndex].ToString());
                int strFees = !string.IsNullOrEmpty(txtFees.Text) ? int.Parse(txtFees.Text) : 0;
                string AlternateMobile = !chkDontKnowAlternateMobile.Checked ? txtAlternateMobileNo.Text.Trim() : string.Empty;
                int Area_ID = Convert.ToInt16(cbArea.SelectedValue);

                bool DiscountChanged = true;
                if (lblOriginalDiscount.Text == txtDiscount.Text.Trim() && lblOriginalDiscountReason.Text.Trim() == txtDiscountReason.Text.Trim())
                {
                    DiscountChanged = false;
                }
                string Discount_Given_By = User.Instance.User_Name;
                int Discount = string.IsNullOrEmpty(txtDiscount.Text.Trim()) ? 0 : Convert.ToInt16(txtDiscount.Text.Trim());
                string DiscountReason = txtDiscountReason.Text.Trim();

                Utilities.Instance.WriteLog("Collected form values");
                Utilities.Instance.WriteLog("Calling InsertUpdateCustomer method from UI");
                DataSet ds = objBusinessRules.InsertUpdateCustomer(strRegistrationDate, strYatraDate, strFirstName, strLastName, strAddress, Area_ID, strAge, strBirthDate, 
                                                                    strBloodGroup, strMobileNo, strBusNo, strSeatNo, strFees, Auto_Time,
                                                                    DiscountChanged, Discount, Discount_Given_By,DiscountReason,User.Instance.User_Name,
                                                                    Customer_ID, Bus_Master_ID,AlternateMobile);
                Utilities.Instance.WriteLog("Called InsertUpdateCustomer method");
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                {
                    string result = ds.Tables[0].Rows[0][0].ToString();
                    if (result == "Seat Availability Changed")
                    {
                        MessageBox.Show("For some reason, Availability of selected seat is changed. Please refresh \"Travel Details\" section");
                        return;
                    }
                    Customer_ID = int.Parse(ds.Tables[0].Rows[0][0].ToString().Split("|".ToCharArray())[0]);
                    Bus_Master_ID = int.Parse(ds.Tables[0].Rows[0][0].ToString().Split("|".ToCharArray())[1]);
                    Utilities.Instance.WriteLog("obtained Customer ID " + Customer_ID.ToString());
                    if (imageCaptured)
                    {
                        Utilities.Instance.WriteLog("Entered saving Snapshot image");
                        using (Bitmap saveImg = (Bitmap)imgSnapShot.Image.Clone())
                        {
                            //saveImg.Save(imagesFolder + Customer_ID.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.jpg);
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (FileStream fs = new FileStream(imagesFolder + Customer_ID.ToString() + ".jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                {
                                    saveImg.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    byte[] bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                    fs.Close();
                                    saveImg.Dispose();
                                }
                                memory.Close();
                            }
                        }
                        Utilities.Instance.WriteLog("Exited saving Snapshot image");
                    }

                    InitializeForm();

                    string date = strYatraDate.DayOfWeek.ToString() + " " + strYatraDate.ToString("dd MMM") + "\n";
                    string time = lblBusTime.Text.Replace("( Time :", "").Replace(" )", "") + "\n";
                    string route = busRoute.Replace(Environment.NewLine, " ");
                    //string vehicleNo = lblVehicleNo.Text + "\n";
                    //string SeatNo = lblSeatNo.Text + "\n";
                    //string smsResult = Utilities.Instance.SendSMSUsingBS(strFirstName, strLastName, date, time, route, "+91" + txtMobileNo.Text.Trim(), lblVehicleNo.Text, lblSeatNo.Text);
                    //if (smsResult.StartsWith("ES1009"))
                    //{
                    //    MessageBox.Show("SMS could not be sent. Invalid Mobile Number", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //else if (smsResult.StartsWith("Unable to connect to the remote server"))
                    //{
                    //    MessageBox.Show("SMS could not be sent. Please check internet connection", "SMS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                   // MessageBox.Show("Record updated successfully. Customer ID is " + Customer_ID.ToString());
                    //MessageBox.Show("Record updated successfully. Customer ID is " + lblCustomerID.Text);
                    MessageBox.Show("Record updated successfully.");
                    btnPrint.Focus();
                }
                
            }
            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in Submit Click \n" + ex.Message);
                MessageBox.Show(ex.Message);
            }
           
        }
        
        private void bntStart_Click(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entered Camera Start click");
            if (camera != null && camera.IsRunning)
            {                
                camera.Stop();
            }
            camera.Start();
            Utilities.Instance.WriteLog("Exited Camera start click");
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entered Camera Stop click");
            if (camera != null && camera.IsRunning)
            {
                camera.Stop();
                imgVideo.Image = null;
                imgSnapShot.Image = null;
                imgCapture.Image = null;
                SetNoImageForAll();
            }
            Utilities.Instance.WriteLog("Exited Camera Stop Click");
        }

        private void SetNoImageForAll()
        {
            using (var bmpTemp = new Bitmap(@"Resources\NoImage.png"))
            {
                img = new Bitmap(bmpTemp);
                imgCapture.Image = img;
                imgSnapShot.Image = img;
            }
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            //customerImage.im.Dispose();
            Utilities.Instance.WriteLog("Entered Capture Click");
            ClearImages();

            imgVideo.Image.Save("Customer.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            imageCaptured = true;

            using (var bmpTemp = new Bitmap("Customer.jpg"))
            {
                img = new Bitmap(bmpTemp);
                imgCapture.Image = img;
                imgSnapShot.Image = img;
            }

            Utilities.Instance.WriteLog("Exited Capture Click");
        }
        
        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utilities.Instance.WriteLog("Entered Camera Selected Index Changed " + cbCamera.SelectedIndex.ToString());
                if (camera != null && camera.IsRunning)
                {
                    camera.NewFrame -= camera_NewFrame;
                    camera.Stop();
                    camera = null;
                }
                cbResolution.Items.Clear();
                camera = new VideoCaptureDevice(cameraCollection[cbCamera.SelectedIndex].MonikerString);
                for (int i=0; i<=camera.VideoCapabilities.Length-1;i++)
                {
                    string resolution = camera.VideoCapabilities[i].FrameSize.Width.ToString() + "x" + camera.VideoCapabilities[i].FrameSize.Height.ToString();
                    availableResultion = new Resolutions();
                    availableResultion.ID = i;
                    availableResultion.Resolution = resolution;
                    cbResolution.Items.Add(availableResultion);
                    cbResolution.DisplayMember = "Resolution";
                    cbResolution.ValueMember = "ID";
                }

                if (cbResolution.Items.Count > 0)
                {
                    Utilities.Instance.WriteLog("Setting Resolution dropdown selected index = 0");
                    cbResolution.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception at Camera selected index changed \n" + ex.Message);
            }
            
        }

        private void cbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entered cbResolution_SelectedIndexChanged");
            if (camera != null)
            {
                camera.VideoResolution = camera.VideoCapabilities[cbResolution.SelectedIndex];
                camera.NewFrame += camera_NewFrame;
                if (camera.IsRunning) camera.Stop();
                Utilities.Instance.WriteLog("Starting Camera");
                camera.Start();
            }
            Utilities.Instance.WriteLog("Exiting cbResolution_SelectedIndexChanged");
        }

        void camera_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                //Logger.Instance.WriteLog("Entered camera_NewFrame");
                Bitmap image = (Bitmap)eventArgs.Frame.Clone();
                    imgVideo.Image = image;
                    image = null;
            }
            catch(Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in camera_NewFrame \n" + ex.Message);
                //Not able to find exact step of the error
            }
            //Logger.Instance.WriteLog("Exiting camera_NewFrame");
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utilities.Instance.WriteLog("Entered Registration_FormClosing");
            if (camera != null)
            {
                camera.NewFrame -= camera_NewFrame;
                if (camera.IsRunning) camera.Stop();
                camera = null;                
            }
            ClearImages();
            GC.Collect();
            timer1.Stop();
            Utilities.Instance.WriteLog("Exited Registration_FormClosing");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Utilities.Instance.WriteLog("Entered btnPrint_Click");
            try
            {            
                if (dgvTickets.DataSource == null) return;


                foreach (DataGridViewRow dgvRow in dgvTickets.Rows)
                {
                    print_CustomerID = print_Address = print_Bus_Name = print_Name = print_Seat_No = print_Yatra_Date = string.Empty;

                    print_CustomerID = Convert.ToString(dgvRow.Cells["CustomerID"].Value);
                    print_Bus_Name = Convert.ToString(dgvRow.Cells["Bus_Name"].Value);
                    print_Seat_No = Convert.ToString(dgvRow.Cells["Seat_No"].Value);
                    print_Yatra_Date = Convert.ToString(dgvRow.Cells["Yatra_Date"].Value);
                    print_Name = string.Format("{0} {1}", Convert.ToString(dgvRow.Cells["First_Name"].Value), Convert.ToString(dgvRow.Cells["Last_Name"].Value));
                    print_Address = Convert.ToString(dgvRow.Cells["Address"].Value);
                    printPreviewDialog1.Document = printDocument1;
                    printDocument1.Print();
                    // printPreviewDialog1.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in btnPrint_Click \n" + ex.Message);
                MessageBox.Show("Error in printing ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Not able to find exact step of the error
            }
            Utilities.Instance.WriteLog("Exited btnPrint_Click");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Print the contents.
            //Utilities.Instance.WriteLog("Entered printDocument1_PrintPage");            
            //e.Graphics.DrawImage(bitmap, 0, 0);
            //Utilities.Instance.WriteLog("Exited printDocument1_PrintPage");
            //bitmap.Dispose();

            //New Code
            Image printImg = null;
            if (System.IO.File.Exists(imagesFolder + print_CustomerID + ".jpg"))
            {
                using (var bmpTemp = new Bitmap(imagesFolder + print_CustomerID + ".jpg"))
                {
                    printImg = new Bitmap(bmpTemp);
                }
            }

            Font f = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular);
            Graphics g = e.Graphics;

            if (printImg != null)
            {
                g.DrawImage(img, 10, 10, 98, 91);
                printImg.Dispose();
            }

            g.DrawString("ID : \t\t" + print_CustomerID.ToString(), f, Brushes.Black, 145.0f, 10.0f);
            g.DrawString("Vehicle No. : \t" + print_Bus_Name.ToString(), f, Brushes.Black, 145.0f, 30.0f);
            g.DrawString("Seat No. : \t" + print_Seat_No.ToString(), f, Brushes.Black, 145.0f, 50.0f);
            g.DrawString("Yatra Date : \t" + print_Yatra_Date.ToString(), f, Brushes.Black, 145.0f, 70.0f);

            g.DrawString("Name : \t" + print_Name.ToString(), f, Brushes.Black, 10.0f, 100.0f);
            g.DrawString("Address : \t" + print_Address.ToString(), f, Brushes.Black, 10.0f, 120.0f);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Customer_ID = 0; Bus_Master_ID = 0; txtSearchAddress.Text = string.Empty;
            InitializeForm();
            //DialogResult newCustomer = MessageBox.Show("Is it new ticket for same customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (newCustomer == System.Windows.Forms.DialogResult.No)
                txtFirstName.Text = txtLastName.Text = txtMobileNo.Text = txtAddress.Text = txtAlternateMobileNo.Text = string.Empty;
        }

        private void ResetTravelDetails()
        {
            cbBus.Items.Clear();
            cbSeatNo.Items.Clear();
            lblBusTime.Text = string.Empty;

            busRoute = string.Empty;
            //chkEditFees.Checked = false; 
            txtFees.Enabled = false;
            txtFees.Text = string.Empty;
            chkDiscount.Checked = false; lblOriginalDiscount.Text = "0"; txtDiscount.Enabled = false; txtDiscountReason.Enabled = false;

            //using (DataSet dsDates = objBusinessRules.GetNavratriDatesForBusRoute(0))
            //{
            //    if (dsDates.Tables[0].Rows.Count > 0)
            //    {
            //        dtpNavratriDate.MaxDate = new DateTime(9998, 12, 12);
            //        dtpNavratriDate.MinDate = Convert.ToDateTime(dsDates.Tables[0].Rows[0]["Navratri_Date"]);
            //        dtpNavratriDate.MaxDate = Convert.ToDateTime(dsDates.Tables[0].Rows[dsDates.Tables[0].Rows.Count - 1]["Navratri_Date"]);                    
            //    }
            //}

            lblOriginalDiscountReason.Text = txtDiscountReason.Text = txtDiscount.Text = string.Empty;
            using(DataSet dsBusRoutes = objBusinessRules.GetBusRoutes())
            {
                if (dsBusRoutes.Tables[0].Rows.Count > 0)
                {
                    cbBusRoutes.DisplayMember = "Bus_Route";
                    cbBusRoutes.ValueMember = "Route_ID";
                    cbBusRoutes.DataSource = dsBusRoutes.Tables[0].Rows.Count > 0 ? dsBusRoutes.Tables[0] : null ;

                    if (cbBusRoutes.DataSource != null)
                    {
                        cbBusRoutes.SelectedIndex = 0;
                    }
                }
            }
        }

        private void ResetNavaratriDates(int Route_ID)
        {
            cbBus.Items.Clear();
            cbSeatNo.Items.Clear();
            lblBusTime.Text = string.Empty;

            busRoute = string.Empty;
            //chkEditFees.Checked = false; 
            txtFees.Enabled = false;
            chkDiscount.Checked = false; lblOriginalDiscount.Text = "0"; txtDiscount.Enabled = false; txtDiscountReason.Enabled = false;

            using (DataSet dsDates = objBusinessRules.GetNavratriDatesForBusRoute(Route_ID))
            {
                if (dsDates.Tables[0].Rows.Count > 0)
                {
                    if (dtpNavratriDate.Value.Date != Convert.ToDateTime(dsDates.Tables[0].Rows[0]["Navratri_Date"]).Date)
                        dtpNavratriDate.Value = Convert.ToDateTime(dsDates.Tables[0].Rows[0]["Navratri_Date"]).Date;
                    else
                        ResetAvailableBusNames(Route_ID, dtpNavratriDate.Value.Date);
                }
            }
        }

        private void ResetAvailableBusNames(int Route_ID, DateTime navratriDate)
        {
            cbBus.Items.Clear();
            cbSeatNo.Items.Clear();
            lblBusTime.Text = string.Empty;

            busRoute = string.Empty;
            //chkEditFees.Checked = false; 
            txtFees.Enabled = false;
            chkDiscount.Checked = false; lblOriginalDiscount.Text = "0"; txtDiscount.Enabled = false; txtDiscountReason.Enabled = false;

            using (DataSet ds = objBusinessRules.getAvailableBusName(Route_ID, navratriDate.Date))
            {
                if (ds.Tables[0] != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cbBus.Items.Add(row["Bus_Name"]);
                    }
                    if (cbBus.Items.Count > 0) cbBus.SelectedIndex = 0;
                }
            }
        }

        private void ResetAvailableSeats(int Route_ID, DateTime navratriDate, string busName)
        {
            cbSeatNo.Items.Clear();
            lblBusTime.Text = string.Empty;

            busRoute = string.Empty;
            //chkEditFees.Checked = false; 
            txtFees.Enabled = false;
            chkDiscount.Checked = false; lblOriginalDiscount.Text = "0"; txtDiscount.Enabled = false; txtDiscountReason.Enabled = false;

            using (DataSet ds = objBusinessRules.getAvailableSeatNo(Route_ID, navratriDate.Date, busName))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cbSeatNo.Items.Add(row["Seat_No"].ToString());
                    }
                    if (cbSeatNo.Items.Count > 0) cbSeatNo.SelectedIndex = 0;
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Bus_Time"].ToString()))
                    {
                        TimeSpan t = (TimeSpan)ds.Tables[0].Rows[0]["Bus_Time"];
                        lblBusTime.Text = "( Time : " + Convert.ToDateTime(new DateTime(navratriDate.Year, navratriDate.Month, 1, t.Hours, t.Minutes, 0)).ToString("hh:mm tt") + " )";
                    }

                    txtFees.Text = ds.Tables[0].Rows[0]["Bus_Fees"].ToString();
                    txtFees.Enabled = false;
                }
            }
        }

        private void cbBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAvailableSeats(Convert.ToInt16(cbBusRoutes.SelectedValue), dtpNavratriDate.Value.Date, cbBus.SelectedItem.ToString());
        }

        private void cbBusRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetNavaratriDates(Convert.ToInt16(cbBusRoutes.SelectedValue));
        }

        private void dtpNavratriDate_ValueChanged(object sender, EventArgs e)
        {
            ResetAvailableBusNames(Convert.ToInt16(cbBusRoutes.SelectedValue), dtpNavratriDate.Value.Date);
        }
        private void AllowDecimal(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ||
                        e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back
                        || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void RestrictToNegativeInteger(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ||
                        e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back
                        || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left) || e.KeyChar == '.')
            { e.Handled = true; }
            TextBox txtNegativeNumber = sender as TextBox;
            if (e.KeyChar == '-' && txtNegativeNumber.Text.Trim().Length == 0)
            {
                e.Handled = false;
            }
        }

        private void RestrictToPositiveInteger(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back ||
                        e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back
                        || e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left) || e.KeyChar == '.')
            { e.Handled = true; }
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge();
        }

        private void CalculateAge()
        {
            DateTime currentDate = DateTime.Now.Date;
            TimeSpan diff = currentDate.Date - dtpBirthDate.Value.Date;
            DateTime age = DateTime.MinValue.AddDays(diff.Days);

            //txtAge.Text = (age.Year - 1).ToString();// +"." + (age.Month - 1).ToString("00");
        }

        private void GetCustomerTickets()
        {
            //DataSet dsTickets = objBusinessRules.GetCustomerTickets(Customer_ID);
            using(DataSet dsTickets = objBusinessRules.GetCustomerTickets(Customer_ID, true))
            {
                dgvTickets.DataSource = dsTickets.Tables[0].Rows.Count > 0 ? dsTickets.Tables[0] : null;
                btnPrint.Visible = dsTickets.Tables[0].Rows.Count > 0 ? true : false;
            }
            using (DataSet dsTickets = objBusinessRules.GetCustomerTickets(Customer_ID, false))
            {
                dgvPreviousTickets.DataSource = dsTickets.Tables[0].Rows.Count > 0 ? dsTickets.Tables[0] : null;
            }
        }

        private void EnableDisableForm(bool flag)
        {
            grpPicture.Enabled = flag;
            grpRegistrationDetails.Enabled = flag;
            grpTravelDetails.Enabled = flag;

            btnAddNew.Enabled = flag;
            btnPrint.Enabled = flag;
            btnSubmit.Enabled = flag;
        }

        private void AddAnotherTicket()
        {
            ResetTravelDetails();
            Bus_Master_ID = 0;
            cbBusRoutes.Focus();
        }

        private void GetCustomerDetailsForMobile(string mobileNo)
        {
            using (DataTable dt = objBusinessRules.GetCustomerDetailsForMobile(mobileNo))
            {
                if (dt.Rows.Count > 0)
                {
                    lblCustomerID.Text = Convert.ToString(dt.Rows[0]["Customer_ID"]);
                    Customer_ID = Convert.ToInt16(dt.Rows[0]["Customer_ID"]);

                    SetCustomerImage();

                    txtFirstName.Text = Convert.ToString(dt.Rows[0]["First_Name"]);
                    txtLastName.Text = Convert.ToString(dt.Rows[0]["Last_Name"]);
                    txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                    cbArea.SelectedValue = dt.Rows[0]["Area_ID"] != DBNull.Value ? Convert.ToInt16(dt.Rows[0]["Area_ID"]) : 0;

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Blood_Group"].ToString()))
                    {
                        chkDontKnowBloodGroup.Checked = false;
                        cbBloodGroup.SelectedItem = cbBloodGroup.Items[cbBloodGroup.Items.IndexOf(dt.Rows[0]["Blood_Group"].ToString())];
                    }
                    else
                    {
                        chkDontKnowBloodGroup.Checked = true;
                        cbBloodGroup.SelectedIndex = -1;
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Birth_Date"].ToString()))
                    {
                        dtpBirthDate.Enabled = true;
                        dtpBirthDate.Value = Convert.ToDateTime(dt.Rows[0]["Birth_Date"]).Date;
                        chkDontKnowBirthdate.Checked = false;
                    }
                    else
                    {
                        dtpBirthDate.Value = DateTime.Now.Date;
                        chkDontKnowBirthdate.Checked = true;
                    }

                    txtAlternateMobileNo.Text = dt.Rows[0]["Alternate_Mobile"].ToString();
                    chkDontKnowAlternateMobile.Checked = string.IsNullOrEmpty(txtAlternateMobileNo.Text);

                    GetCustomerTickets();
                    btnPrint.Visible = true;
                    cbBusRoutes.Focus();
                }
                else
                {
                    lblCustomerID.Text = "New Customer";
                    Customer_ID = 0;
                    cbArea.SelectedValue = 0;

                    txtFirstName.Text = txtLastName.Text = txtAddress.Text = string.Empty;
                    chkDontKnowBloodGroup.Checked = true;
                    cbBloodGroup.SelectedIndex = -1;

                    chkDontKnowAlternateMobile.Checked = true;
                    txtAlternateMobileNo.Text = string.Empty;

                    dtpBirthDate.Value = DateTime.Now.Date;
                    chkDontKnowBirthdate.Checked = true;
                    dgvTickets.DataSource = null;
                    btnPrint.Visible = false;
                    txtFirstName.Focus();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
        
        private void btnRefreshTravelDetails_Click(object sender, EventArgs e)
        {
            AddAnotherTicket();
        }

        private void cbSeatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utilities.Instance.WriteLog("Entered cbSeatNo_SelectedIndexChanged");
                DataSet ds = objBusinessRules.getLatestUpdatedTimeStamp(dtpNavratriDate.Value.Date, cbBus.SelectedItem.ToString(), Convert.ToInt16(cbSeatNo.SelectedItem));
                Auto_Time = ds.Tables[0].Rows[0]["Auto_Time"] as byte[];
                Utilities.Instance.WriteLog("Exited cbSeatNo_SelectedIndexChanged");
            }
            catch(Exception ex)
            {
                Utilities.Instance.WriteLog("*** Exception in cbSeatNo_SelectedIndexChanged \n" + ex.Message);
            }
        }

        private void HideShowSearchCustomer(string flag)
        {
            if (flag == "show")
            {
                EnableDisableForm(false);
                panelSearch.Show();
                txtSearchMobileNumber.Focus();
                txtSearchFirstName.Text = txtSearchLastName.Text = txtSearchMobileNumber.Text = txtSearchAlternateMobileNumber.Text = string.Empty;
                panelSearch.BringToFront();
                
                dgvCustomers.DataSource = dsAllCustomers.Tables[0].Rows.Count > 0 ? dsAllCustomers.Tables[0] : null;
                if (dgvCustomers.DataSource != null)
                {
                    dgvCustomers.Columns["Customer_ID"].Visible = false;
                    dgvCustomers.Columns["First_Name"].HeaderText = "First Name";
                    dgvCustomers.Columns["Last_Name"].HeaderText = "Last Name";
                    dgvCustomers.Columns["Address"].HeaderText = "Address";
                    dgvCustomers.Columns["Mobile_No"].HeaderText = "Mobile No";
                    dgvCustomers.Columns["Alternate_Mobile"].HeaderText = "Alternate Mobile";
                    dgvCustomers.Columns["Birth_Date"].HeaderText = "Birth Date";

                    dgvCustomers.Columns["Alternate_Mobile"].DefaultCellStyle.Alignment =
                        dgvCustomers.Columns["Mobile_No"].DefaultCellStyle.Alignment =
                        dgvCustomers.Columns["Birth_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else
            {
                EnableDisableForm(true);
                panelSearch.Hide();
                txtFirstName.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dsAllCustomers = objBusinessRules.getAllCustomers();

            ExtractAutoCompleteStringCollections();
            HideShowSearchCustomer("show");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideShowSearchCustomer("hide");
        }

        private void SearchParameterChanged(object sender, EventArgs e)
        {
            if (dsAllCustomers != null && dsAllCustomers.Tables[0].Rows.Count > 0)
            {
                var query = dsAllCustomers.Tables[0].AsEnumerable().Where(row =>
                    row["First_Name"].ToString().ToLower().StartsWith(string.IsNullOrEmpty(txtSearchFirstName.Text.Trim()) ? row["First_Name"].ToString().ToLower() : txtSearchFirstName.Text.Trim().ToLower()) &&
                    row["Last_Name"].ToString().ToLower().StartsWith(string.IsNullOrEmpty(txtSearchLastName.Text.Trim()) ? row["Last_Name"].ToString().ToLower() : txtSearchLastName.Text.Trim().ToLower()) &&
                    row["Mobile_No"].ToString().ToLower().StartsWith(string.IsNullOrEmpty(txtSearchMobileNumber.Text.Trim()) ? row["Mobile_No"].ToString().ToLower() : txtSearchMobileNumber.Text.Trim().ToLower()) &&
                    row["Alternate_Mobile"].ToString().ToLower().StartsWith(string.IsNullOrEmpty(txtSearchAlternateMobileNumber.Text.Trim()) ? row["Alternate_Mobile"].ToString().ToLower() : txtSearchAlternateMobileNumber.Text.Trim().ToLower()));

                dgvCustomers.DataSource = query.Any() ? query.CopyToDataTable() : null;// dsAllCustomers.Tables[0].Rows.Count > 0 ? dsAllCustomers.Tables[0] : null;
                if (dgvCustomers.DataSource != null)
                {
                    dgvCustomers.Columns["Customer_ID"].Visible = false;
                    dgvCustomers.Columns["First_Name"].HeaderText = "First Name";
                    dgvCustomers.Columns["Last_Name"].HeaderText = "Last Name";
                    dgvCustomers.Columns["Address"].HeaderText = "Address";
                    dgvCustomers.Columns["Mobile_No"].HeaderText = "Mobile No";
                    dgvCustomers.Columns["Alternate_Mobile"].HeaderText = "Alternate Mobile";
                    dgvCustomers.Columns["Birth_Date"].HeaderText = "Birth Date";

                    dgvCustomers.Columns["Alternate_Mobile"].DefaultCellStyle.Alignment =
                        dgvCustomers.Columns["Mobile_No"].DefaultCellStyle.Alignment =
                        dgvCustomers.Columns["Birth_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void chkDontKnowBloodGroup_CheckedChanged(object sender, EventArgs e)
        {
            //cbBloodGroup.SelectedIndex = chkDontKnowBloodGroup.Checked ? -1 : 0;
            cbBloodGroup.Enabled = !chkDontKnowBloodGroup.Checked;
        }

        private void TransferContents()
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                Customer_ID = 0; Bus_Master_ID = 0;
                
                InitializeForm();
                DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                txtFirstName.Text = Convert.ToString(selectedRow.Cells["First_Name"].Value);
                txtLastName.Text = Convert.ToString(selectedRow.Cells["Last_Name"].Value);
                txtAddress.Text = Convert.ToString(selectedRow.Cells["Address"].Value);
                txtMobileNo.Text = Convert.ToString(selectedRow.Cells["Mobile_No"].Value);
                txtAlternateMobileNo.Text = Convert.ToString(selectedRow.Cells["Alternate_Mobile"].Value);
                chkDontKnowAlternateMobile.Checked = string.IsNullOrEmpty(txtAlternateMobileNo.Text);
                if (!string.IsNullOrEmpty(selectedRow.Cells["Birth_Date"].Value.ToString()))
                    dtpBirthDate.Value = Convert.ToDateTime(selectedRow.Cells["Birth_Date"].Value);
                else
                    chkDontKnowBirthdate.Checked = true;

                if (!string.IsNullOrEmpty(Convert.ToString(selectedRow.Cells["Blood_Group"].Value)))
                {
                    chkDontKnowBloodGroup.Checked = false;
                    cbBloodGroup.SelectedItem = cbBloodGroup.Items[cbBloodGroup.Items.IndexOf(Convert.ToString(selectedRow.Cells["Blood_Group"].Value))];
                }
                else
                {
                    chkDontKnowBloodGroup.Checked = true;
                    cbBloodGroup.SelectedIndex = -1;
                }

                Customer_ID = Convert.ToInt16(selectedRow.Cells["Customer_ID"].Value);
                cbArea.SelectedValue = !string.IsNullOrEmpty(selectedRow.Cells["Area_ID"].Value.ToString()) ? Convert.ToInt16(selectedRow.Cells["Area_ID"].Value) : 0;

                imageCaptured = true;
                SetCustomerImage();
                GC.Collect();
                ResetTravelDetails();
                GetCustomerTickets();
                HideShowSearchCustomer("hide");
            }

        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtDiscount.Text = string.Empty;
                txtDiscountReason.Text = string.Empty;
                txtDiscountReason.Enabled = true;
                txtDiscount.Enabled = true;                
            }
            else
            {
                txtDiscountReason.Enabled = false;
                txtDiscount.Enabled = false;
            }
            txtDiscount.Text = string.Empty;
        }

        private void chkDontKnowBirthdate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBirthDate.Enabled = !chkDontKnowBirthdate.Checked;            
        }

        private void chkDontKnowAlternateMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDontKnowAlternateMobile.Checked)
            {
                //txtAlternateMobileNo.Text = string.Empty;
                txtAlternateMobileNo.Enabled = false;
                txtAlternateMobileNo.BackColor = Color.FromKnownColor(KnownColor.Control);

                
            }
            else
            {
                txtAlternateMobileNo.Enabled = true;
                txtAlternateMobileNo.BackColor = Color.White;
            }
        }
        
        private void ActivateControl(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Aqua;
            ((Control)sender).ForeColor = Color.DarkRed;
            toolTip1.Show(Convert.ToString(((Control)sender).Tag), ((Control)sender));
        }

        private void DeActivateControl(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                switch (((Button) sender).Name)
                {
                    case "btnAddNew":
                    case "btnSubmit":
                        {
                            ((Control)sender).BackColor = Color.FromArgb(192, 192, 255);
                            ((Control)sender).ForeColor = Color.Black;
                            break;
                        }
                    default:
                        ((Control)sender).BackColor = Color.White;
                        ((Control)sender).ForeColor = Color.Black;
                        break;
                }
            }
            else if (sender is TextBox && ((TextBox)sender).Name == "txtMobileNo")
            {
                TextBox txt = (TextBox)sender;
                if (!string.IsNullOrEmpty(txt.Text.Trim()) && txt.Text.Trim().Length == 10)
                {
                    GetCustomerDetailsForMobile(txt.Text.Trim());
                }

                ((Control)sender).BackColor = Color.White;
                ((Control)sender).ForeColor = Color.Black;
            }
            else if (sender is TextBox && ((TextBox)sender).Name == "txtAddress")
            {
                TextBox txt = (TextBox)sender;
                
                if (chkDontKnowBirthdate.Checked && chkDontKnowAlternateMobile.Checked && chkDontKnowBloodGroup.Checked)
                {
                    cbBusRoutes.Focus();
                }

                ((Control)sender).BackColor = Color.White;
                ((Control)sender).ForeColor = Color.Black;
            }
            else
            {
                ((Control)sender).BackColor = Color.White;
                ((Control)sender).ForeColor = Color.Black;
            }
            toolTip1.Hide(((Control)sender));
        }

        private void txtSearchAddress_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchAddress.Text.Trim()))
            {
                txtAddress.Text = txtSearchAddress.Text;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            TransferContents();
        }

        private void dgvCustomers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TransferContents();
        }

        private void btnRefreshAutoLists_Click(object sender, EventArgs e)
        {
            dsAllCustomers = objBusinessRules.getAllCustomers();

            ExtractAutoCompleteStringCollections();

            DialogResult f = MessageBox.Show("Add another ticket?", "Another Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (f == System.Windows.Forms.DialogResult.Yes)
            {
                AddAnotherTicket();
            }
            else
            {
                btnAddNew.Focus();
            }
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TransferContents();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TransferContents();
        }

        private void dgvTickets_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvTickets.ClearSelection();
                this.dgvTickets.Rows[e.RowIndex].Selected = true;
                Customer_ID = int.Parse(dgvTickets.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString().Trim());
                Bus_Master_ID = int.Parse(dgvTickets.Rows[e.RowIndex].Cells["BusMasterID"].Value.ToString().Trim());
                //this.dgvCustomers.CurrentCell = this.dgvCustomers.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dgvTickets, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void editTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_ID = Convert.ToInt32(dgvTickets.SelectedRows[0].Cells["Customer_ID"].Value);
            Bus_Master_ID = Convert.ToInt32(dgvTickets.SelectedRows[0].Cells["Bus_Master_ID"].Value);
            InitializeForm();
        }

        private void deleteTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult f = MessageBox.Show("Are you sure to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (f == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                f = MessageBox.Show("Are you sure to delete this entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (f == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                BusinessRules objDatabase = new BusinessRules();
                DataSet ds = objDatabase.DeleteTicket(Customer_ID, Bus_Master_ID);
                //if (System.IO.File.Exists(imagesFolder + customerID.ToString() + ".jpg"))
                //{
                //    System.IO.File.Delete(imagesFolder + customerID.ToString() + ".jpg");
                //}
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    ResetTravelDetails();
                    GetCustomerTickets();
                    Bus_Master_ID = 0;
                    MessageBox.Show("Record deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Error in deleting Record, please contact System Administrator!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updating Record, please contact System Administrator!\n" + ex.Message.ToString());
            }
        }

        private void btnPrintOld_Click(object sender, EventArgs e)
        {
            if (dgvPreviousTickets.DataSource == null) return;


            foreach (DataGridViewRow dgvRow in dgvPreviousTickets.Rows)
            {
                print_CustomerID = print_Address = print_Bus_Name = print_Name = print_Seat_No = print_Yatra_Date = string.Empty;

                print_CustomerID = Convert.ToString(dgvRow.Cells["CustomerID1"].Value);
                print_Bus_Name = Convert.ToString(dgvRow.Cells["Bus_Name1"].Value);
                print_Seat_No = Convert.ToString(dgvRow.Cells["Seat_No1"].Value);
                print_Yatra_Date = Convert.ToString(dgvRow.Cells["Yatra_Date1"].Value);
                print_Name = string.Format("{0} {1}", Convert.ToString(dgvRow.Cells["First_Name1"].Value), Convert.ToString(dgvRow.Cells["Last_Name1"].Value));
                print_Address = Convert.ToString(dgvRow.Cells["Address1"].Value);
                printPreviewDialog1.Document = printDocument1;
                printDocument1.Print();
                //printPreviewDialog1.ShowDialog();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtAddress.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
            }
        }

    }
}
