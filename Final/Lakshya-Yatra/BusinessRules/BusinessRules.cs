using System;
using System.Data;
using System.Data.SqlClient;

namespace Lakshya_Yatra
{
    class BusinessRules
    {
        # region Objects & Variables
        private SqlConnection sqlCon;
        private SqlDataAdapter sqlDa;
        private DataSet dataSet;
        public System.Configuration.AppSettingsReader AppSettings = new System.Configuration.AppSettingsReader();
        string sourcePath;
        # endregion

        #region GetElectionReport 
        public DataSet GetElectionReport(int Area_ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "GetElectionReport";
            if (Area_ID > 0)
                sqlCmd.Parameters.Add(new SqlParameter("@Area_ID", SqlDbType.Int)).Value = Area_ID;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsGetElectionReport = this.ExecuteToDataSet(sqlCmd);
            return dsGetElectionReport;
        }
        #endregion

        #region Area Management Functions 
        
        public DataTable InsertUpdateArea(int Area_ID, string Area, bool IsVisible, string UserName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.InsertUpdateArea";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = UserName;
            sqlCmd.Parameters.Add(new SqlParameter("@Area_ID", SqlDbType.Int)).Value = Area_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.VarChar)).Value = Area;
            sqlCmd.Parameters.Add(new SqlParameter("@IsVisible", SqlDbType.Bit)).Value = IsVisible;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsAreaDetails = this.ExecuteToDataSet(sqlCmd);
            return dsAreaDetails.Tables[0];
        }

        public DataTable DeleteArea(int Area_ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.DeleteArea";
            sqlCmd.Parameters.Add(new SqlParameter("@Area_ID", SqlDbType.Int)).Value = Area_ID;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsAreaDetails = this.ExecuteToDataSet(sqlCmd);
            return dsAreaDetails.Tables[0];
        }
        #endregion

        #region Customer Management Functions 

        public DataTable GetAreas(bool withSelect = true)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.getAreas";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetAreas = this.ExecuteToDataSet(sqlCmd);
            if (withSelect)
            {
                DataRow dr = dsgetAreas.Tables[0].NewRow();
                dr["Area_ID"] = 0;
                dr["Area"] = "--Select--";
                dsgetAreas.Tables[0].Rows.InsertAt(dr, 0);
                dr = null;
            }
            return dsgetAreas.Tables[0];
        }

        public DataTable GetCustomers(string First_Name, string Last_Name, string Mobile_No)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.SearchCustomer";
            if (!string.IsNullOrEmpty(First_Name))
                sqlCmd.Parameters.Add(new SqlParameter("@First_Name", SqlDbType.VarChar)).Value = First_Name;
            if (!string.IsNullOrEmpty(Last_Name))
                sqlCmd.Parameters.Add(new SqlParameter("@Last_Name", SqlDbType.VarChar)).Value = Last_Name;
            if (!string.IsNullOrEmpty(Mobile_No))
                sqlCmd.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.VarChar)).Value = Mobile_No;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerDetails = this.ExecuteToDataSet(sqlCmd);
            
            return dsCustomerDetails.Tables[0];
        }

        public DataTable InsertCustomer(string First_Name, string Last_Name, string Mobile_No, string Address, int Area_ID,
                                        DateTime Birth_Date, bool isBirthDateknown, string Blood_Group, string Alternate_Mobile, string UserName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.InsertCustomer";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = UserName;
            sqlCmd.Parameters.Add(new SqlParameter("@first_Name", SqlDbType.VarChar)).Value = First_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@last_Name", SqlDbType.VarChar)).Value = Last_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.VarChar)).Value = Mobile_No;
            sqlCmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = Address;
            if (!string.IsNullOrEmpty(Alternate_Mobile))
                sqlCmd.Parameters.Add(new SqlParameter("@Alternate_Mobile", SqlDbType.VarChar)).Value = Alternate_Mobile;
            if (!string.IsNullOrEmpty(Blood_Group))
                sqlCmd.Parameters.Add(new SqlParameter("@Blood_Group", SqlDbType.VarChar)).Value = Blood_Group;
            if (isBirthDateknown)
                sqlCmd.Parameters.Add(new SqlParameter("@Birth_Date", SqlDbType.Date)).Value = Birth_Date;
            if (Area_ID > 0)
                sqlCmd.Parameters.Add(new SqlParameter("@Area_ID", SqlDbType.Int)).Value = Area_ID;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerDetails = this.ExecuteToDataSet(sqlCmd);
            return dsCustomerDetails.Tables[0];
        }

        public DataTable UpdateCustomer(int Customer_ID, string First_Name, string Last_Name, string Mobile_No, string Address, int Area_ID,
                                        DateTime Birth_Date, bool isBirthDateknown, string Blood_Group, string Alternate_Mobile, string UserName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.UpdateCustomer";
            sqlCmd.Parameters.Add(new SqlParameter("@Customer_ID", SqlDbType.Int)).Value = Customer_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = UserName;
            sqlCmd.Parameters.Add(new SqlParameter("@first_Name", SqlDbType.VarChar)).Value = First_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@last_Name", SqlDbType.VarChar)).Value = Last_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.VarChar)).Value = Mobile_No;
            sqlCmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = Address;
            if (!string.IsNullOrEmpty(Alternate_Mobile))
                sqlCmd.Parameters.Add(new SqlParameter("@Alternate_Mobile", SqlDbType.VarChar)).Value = Alternate_Mobile;
            if (!string.IsNullOrEmpty(Blood_Group))
                sqlCmd.Parameters.Add(new SqlParameter("@Blood_Group", SqlDbType.VarChar)).Value = Blood_Group;
            if (isBirthDateknown)
                sqlCmd.Parameters.Add(new SqlParameter("@Birth_Date", SqlDbType.Date)).Value = Birth_Date;
            if (Area_ID > 0)
                sqlCmd.Parameters.Add(new SqlParameter("@Area_ID", SqlDbType.Int)).Value = Area_ID;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerDetails = this.ExecuteToDataSet(sqlCmd);
            return dsCustomerDetails.Tables[0];
        }

        public DataTable DeleteCustomer(int Customer_ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "dbo.DeleteCustomer";
            sqlCmd.Parameters.Add(new SqlParameter("@Customer_ID", SqlDbType.Int)).Value = Customer_ID;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerDetails = this.ExecuteToDataSet(sqlCmd);
            return dsCustomerDetails.Tables[0];
        }
        #endregion

        #region User Management Functions 
        
        public DataTable GetUserNames()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[GetUserNames]";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            DataRow dr = dsUserDetails.Tables[0].NewRow();
            dr["User_Name"] = "All";
            dr["Full_Name"] = "All";
            dsUserDetails.Tables[0].Rows.InsertAt(dr, 0);
            dr = null;
            return dsUserDetails.Tables[0];
        }
        public DataTable GetUserDetails(string User_Name, string First_Name, string Last_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[GetUserDetails]";
            if (!string.IsNullOrEmpty(User_Name))
                sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = User_Name;
            if (!string.IsNullOrEmpty(First_Name))
                sqlCmd.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar)).Value = First_Name;
            if (!string.IsNullOrEmpty(Last_Name))
                sqlCmd.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar)).Value = Last_Name;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            return dsUserDetails.Tables[0];
        }

        public DataTable AuthenticateUser(string User_Name, string Password)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[AuthenticateUser]";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = User_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = Password;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            return dsUserDetails.Tables[0];
        }

        public DataTable ChangePassword(string User_Name, string NewPassword)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[ChangePassword]";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = User_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@NewPassword", SqlDbType.VarChar)).Value = NewPassword;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            return dsUserDetails.Tables[0];
        }

        public DataTable CreateUser(string User_Name, string Password, string First_Name, string Last_Name, bool IsAdmin)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[CreateUser]";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = User_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = Password;

            sqlCmd.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar)).Value = First_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar)).Value = Last_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@IsAdmin", SqlDbType.Bit)).Value = IsAdmin;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            return dsUserDetails.Tables[0];
        }

        public DataTable UpdateUser(string User_Name, string Password, string First_Name, string Last_Name, bool IsAdmin)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[UpdateUser]";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = User_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = Password;

            sqlCmd.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar)).Value = First_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar)).Value = Last_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@IsAdmin", SqlDbType.Bit)).Value = IsAdmin;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            return dsUserDetails.Tables[0];
        }

        public DataTable DeleteUser(string User_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[DeleteUser]";
            sqlCmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar)).Value = User_Name;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUserDetails = this.ExecuteToDataSet(sqlCmd);
            return dsUserDetails.Tables[0];
        }
        #endregion

        public DataSet GetRouteAndDates()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.GetRouteAndDates";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsGetRouteAndDates = this.ExecuteToDataSet(sqlCmd);
            return dsGetRouteAndDates;
        }

        public DataTable GetRouteAndDateVisibility(DateTime Navratri_Date, int Route_ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "dbo.GetRouteAndDateVisibility";
            sqlCmd.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int)).Value = Route_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@Navratri_Date", SqlDbType.Date)).Value = Navratri_Date;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            using(DataSet dsGetRouteAndDates = this.ExecuteToDataSet(sqlCmd))
                return dsGetRouteAndDates.Tables[0];
        }

        public DataSet GetNavratriDatesForBusRoute(int Route_ID = 0)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "getNavratriDatesForBusRoute";
            if (Route_ID > 0)
                sqlCmd.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int)).Value = Route_ID;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetNavratriDates = this.ExecuteToDataSet(sqlCmd);
            return dsgetNavratriDates;
        }

        public DataSet InsertUpdateBusRoute(int Route_ID, string Bus_Route, string userName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            if (Route_ID == 0)
            {
                sqlCmd.CommandText = "InsertBusRoute";
                sqlCmd.Parameters.Add(new SqlParameter("@Bus_Route", SqlDbType.VarChar)).Value = Bus_Route;
                sqlCmd.Parameters.Add(new SqlParameter("@Created_By", SqlDbType.VarChar)).Value = userName;
            }
            else
            {
                sqlCmd.CommandText = "UpdateBusRoute";
                sqlCmd.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int)).Value = Route_ID;
                sqlCmd.Parameters.Add(new SqlParameter("@Bus_Route", SqlDbType.VarChar)).Value = Bus_Route;
                sqlCmd.Parameters.Add(new SqlParameter("@Updated_By", SqlDbType.VarChar)).Value = userName;
            }

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsBusRoute = this.ExecuteToDataSet(sqlCmd);
            return dsBusRoute;
        }

        public DataSet GetCustomerTickets(int Customer_ID, bool showTodayTickets)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "GetCustomerTickets";
            sqlCmd.Parameters.Add(new SqlParameter("@Cust_ID", SqlDbType.Int)).Value = Customer_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@showTodayTickets", SqlDbType.Bit)).Value = showTodayTickets;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsGetCustomerTickets = this.ExecuteToDataSet(sqlCmd);
            return dsGetCustomerTickets;
        }

        public DataTable GetCustomerDetailsForMobile(string mobileNo)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "getCustomerDetailsForMobileNumber";
            sqlCmd.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.VarChar)).Value = mobileNo;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsGetCustomerDetails = this.ExecuteToDataSet(sqlCmd);
            return dsGetCustomerDetails.Tables[0];
        }

        public DataSet GetBusRoutes()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getBusRoutes";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetBusRoutes = this.ExecuteToDataSet(sqlCmd);
            return dsgetBusRoutes;
        }

        public DataSet GetBusRegistrationInfo()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getBusRegistrationInfo";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetBusRegistrationInfo = this.ExecuteToDataSet(sqlCmd);
            return dsgetBusRegistrationInfo;
        }

        # region getAllCustomers 
        public DataSet getAllCustomers()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getAllCustomers";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetAllCustomers = this.ExecuteToDataSet(sqlCmd);
            return dsgetAllCustomers;
        }
        # endregion getAllCustomers

        # region UpdateBusRegistration 
        public DataSet UpdateBusRegistration(string Bus_Name, DateTime Navratri_Date, string Seat_No, 
                                            int Seat_Count, int Bus_Fees, int Route_ID, DateTime Bus_Time,bool Is_Visible,
                                            string userName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "UpdateBusRegistration";
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Navratri_Date", SqlDbType.DateTime)).Value = Navratri_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@Seat_No", SqlDbType.VarChar)).Value = Seat_No;
            sqlCmd.Parameters.Add(new SqlParameter("@Seat_Count", SqlDbType.Int)).Value = Seat_Count;
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Fees", SqlDbType.Int)).Value = Bus_Fees;
            sqlCmd.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int)).Value = Route_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Time", SqlDbType.DateTime)).Value = Bus_Time;
            sqlCmd.Parameters.Add(new SqlParameter("@Is_Visible", SqlDbType.Bit)).Value = Is_Visible;
            sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = userName;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUpdateBusRegistration = this.ExecuteToDataSet(sqlCmd);
            return dsUpdateBusRegistration;
        }
        # endregion UpdateBusRegistration

        # region DeleteCustomer 
        public DataSet DeleteTicket(int Customer_ID, int old_Bus_Master_ID, string userName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "DeleteTicket";
            sqlCmd.Parameters.Add(new SqlParameter("@Customer_ID", SqlDbType.Int)).Value = Customer_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@old_Bus_Master_ID", SqlDbType.Int)).Value = old_Bus_Master_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = userName;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsUpdateBusRegistration = this.ExecuteToDataSet(sqlCmd);
            return dsUpdateBusRegistration;
        }
        # endregion DeleteCustomer

        # region getCustomerDetails 
        public DataSet getCustomerDetails(int Customer_ID, int Bus_Master_ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getCustomerDetails";
            sqlCmd.Parameters.Add(new SqlParameter("@Customer_ID", SqlDbType.Int)).Value = Customer_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Master_ID", SqlDbType.Int)).Value = Bus_Master_ID;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetCustomerDetails = this.ExecuteToDataSet(sqlCmd);
            return dsgetCustomerDetails;
        }
        # endregion getCustomerDetails 

        # region getAvailableBusName
        public DataSet getAvailableBusName(int Route_ID, DateTime Yatra_Date)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "getAvailableBusName";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int)).Value = Route_ID;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetAvailableBusName = this.ExecuteToDataSet(sqlCmd);
            return dsgetAvailableBusName;
        }
        # endregion getAvailableBusName

        # region getBusByYatraDate
        public DataSet getBusByYatraDate(DateTime Yatra_Date)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "[getBusByYatraDate]";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetBusByYatraDate = this.ExecuteToDataSet(sqlCmd);
            return dsgetBusByYatraDate;
        }
        # endregion getBusByYatraDate

        # region getAvailableSeatNo
        public DataSet getAvailableSeatNo(int Route_ID, DateTime Yatra_Date, string Bus_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "getAvailableSeatNo";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Route_ID", SqlDbType.Int)).Value = Route_ID;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetAvailableSeatNo = this.ExecuteToDataSet(sqlCmd);
            return dsgetAvailableSeatNo;
        }
        # endregion getAvailableSeatNo

        # region getMobileNumbers 
        public DataSet getMobileNumbers(int YatraYear = 0, DateTime? YatraDate = null, string MobileOrAlternate = "Mobile")
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "GetMobileNumbers";

            sqlCmd.Parameters.Add(new SqlParameter("@MobileOrAlternate", SqlDbType.VarChar)).Value = MobileOrAlternate;

            if (YatraYear != 0)
                sqlCmd.Parameters.Add(new SqlParameter("@YatraYear", SqlDbType.Int)).Value = YatraYear;
            if (YatraDate != null)
                sqlCmd.Parameters.Add(new SqlParameter("@YatraDate", SqlDbType.Date)).Value = YatraDate;
            
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsMobileNumbers = this.ExecuteToDataSet(sqlCmd);
            return dsMobileNumbers;
        }
        # endregion getMobileNumbers

        # region getLatestUpdatedTimeStamp
        public DataSet getLatestUpdatedTimeStamp(DateTime Yatra_Date, string Bus_Name, int Seat_No)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getLatestUpdatedTimeStamp";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Seat_No", SqlDbType.Int)).Value = Seat_No;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetLatestUpdatedTimeStamp = this.ExecuteToDataSet(sqlCmd);
            return dsgetLatestUpdatedTimeStamp;
        }
        # endregion getLatestUpdatedTimeStamp

        # region DeleteAllData
        public DataSet DeleteData(DateTime FromDate, DateTime ToDate, bool DeleteBusRoutes = false,
                                    bool DeleteBuses = false, bool DeleteCustomers = false)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "DeleteData";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.Date)).Value = FromDate;
            sqlCmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.Date)).Value = ToDate;
            if (DeleteBusRoutes)
                sqlCmd.Parameters.Add(new SqlParameter("@DeleteBusRoutes", SqlDbType.Bit)).Value = DeleteBusRoutes;
            if (DeleteBuses)
                sqlCmd.Parameters.Add(new SqlParameter("@DeleteBuses", SqlDbType.Bit)).Value = DeleteBuses;
            if (DeleteCustomers)
                sqlCmd.Parameters.Add(new SqlParameter("@DeleteCustomers", SqlDbType.Bit)).Value = DeleteCustomers;

            DataSet dsDeleteData = this.ExecuteToDataSet(sqlCmd);
            return dsDeleteData;
        }
        # endregion DeleteAllData

        # region DeleteBus 
        public DataSet DeleteBus(string Bus_Name, DateTime Navratri_Date)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "DeleteBus";
            sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Navratri_Date", SqlDbType.Date)).Value = Navratri_Date;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsDeleteBus = this.ExecuteToDataSet(sqlCmd);
            return dsDeleteBus;
        }
        # endregion DeleteBus

        # region InsertCustomer
        public DataSet InsertUpdateCustomer(DateTime Registration_Date,
            DateTime Navratri_Date, string First_Name, string Last_Name, string Address, int Area_ID,
            float Age, DateTime? Birth_Date, string Blood_Group, string Mobile_No, string Bus_No, int Seat_No, int Fees, byte[] Auto_Time, bool DiscountChanged, int Discount, string Discount_Given_By, string DiscountReason, string created_By, int Customer_ID = 0, int Bus_Master_ID = 0, string Alternate_Mobile = "")
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            if (Bus_Master_ID == 0)
            {
                sqlCmd.CommandText = "InsertCustomerAndTravel";
                sqlCmd.Parameters.Add(new SqlParameter("@Created_By", SqlDbType.VarChar)).Value = created_By;
            }
            else
            {
                sqlCmd.CommandText = "UpdateCustomerAndTravel";
                sqlCmd.Parameters.Add(new SqlParameter("@Customer_ID", SqlDbType.Int)).Value = Customer_ID;
                sqlCmd.Parameters.Add(new SqlParameter("@old_Bus_Master_ID", SqlDbType.Int)).Value = Bus_Master_ID;
                sqlCmd.Parameters.Add(new SqlParameter("@Updated_By", SqlDbType.VarChar)).Value = created_By;
            }
            sqlCmd.Parameters.Add(new SqlParameter("@Registration_Date", SqlDbType.Date)).Value = Registration_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@First_Name", SqlDbType.VarChar)).Value = First_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Last_Name", SqlDbType.VarChar)).Value = Last_Name;
            sqlCmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar)).Value = Address;
            sqlCmd.Parameters.Add(new SqlParameter("@Age", SqlDbType.Float)).Value = Age;
            if (Birth_Date != null)
                sqlCmd.Parameters.Add(new SqlParameter("@Birth_Date", SqlDbType.Date)).Value = Birth_Date;
            if (!string.IsNullOrEmpty(Blood_Group))
                sqlCmd.Parameters.Add(new SqlParameter("@Blood_Group", SqlDbType.VarChar)).Value = Blood_Group;
            if (Area_ID > 0)
                sqlCmd.Parameters.Add(new SqlParameter("@Area_ID", SqlDbType.Int)).Value = Area_ID;

            sqlCmd.Parameters.Add(new SqlParameter("@DiscountChanged", SqlDbType.Bit)).Value = DiscountChanged;
            sqlCmd.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Int)).Value = Discount;
            sqlCmd.Parameters.Add(new SqlParameter("@Discount_Given_By", SqlDbType.VarChar)).Value = Discount_Given_By;
            sqlCmd.Parameters.Add(new SqlParameter("@DiscountReason", SqlDbType.VarChar)).Value = DiscountReason;

            sqlCmd.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.VarChar)).Value = Mobile_No;
            sqlCmd.Parameters.Add(new SqlParameter("@yatra_date", SqlDbType.Date)).Value = Navratri_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@bus_name", SqlDbType.VarChar)).Value = Bus_No;
            sqlCmd.Parameters.Add(new SqlParameter("@Seat_No", SqlDbType.Int)).Value = Seat_No;
            sqlCmd.Parameters.Add(new SqlParameter("@Auto_Time", SqlDbType.Timestamp)).Value = Auto_Time;

            

            if (Fees > 0)
                sqlCmd.Parameters.Add(new SqlParameter("@Fees", SqlDbType.Int)).Value = Fees;
            if (!string.IsNullOrEmpty(Alternate_Mobile))
                sqlCmd.Parameters.Add(new SqlParameter("@Alternate_Mobile", SqlDbType.VarChar)).Value = Alternate_Mobile;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsInsertCustomer = this.ExecuteToDataSet(sqlCmd);
            return dsInsertCustomer;
        }
        # endregion InsertCustomer

        # region getUserwiseTickets 

        public DataSet getUserwiseTickets(string userName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getUserwiseTickets";
            if (userName != "All")
                sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = userName;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetUserwiseTickets = this.ExecuteToDataSet(sqlCmd);
            return dsgetUserwiseTickets;
        }
        # endregion getUserwiseTickets

        # region getCashReport
        public DataSet getCashReport(DateTime Yatra_Date, string Bus_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "CashReport";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            if (Bus_Name != "All")
                sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerReport = this.ExecuteToDataSet(sqlCmd);
            dsCustomerReport.Tables[0].TableName = "dtCashReport";
            dsCustomerReport.Tables[1].TableName = "dtCashTotals";
            return dsCustomerReport;
        }

        public DataSet getCashReport(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "CashReport_Yearly";
            sqlCmd.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.Date)).Value = FromDate;
            sqlCmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.Date)).Value = ToDate;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerReport = this.ExecuteToDataSet(sqlCmd);
            dsCustomerReport.Tables[0].TableName = "dtCashReport";
            dsCustomerReport.Tables[1].TableName = "dtCashTotals";
            return dsCustomerReport;
        }
        # endregion getCashReport

        # region getCashReport_Userwise 

        public DataSet getCashReport_Userwise(string userName, int yatraYear)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "CashReport_Userwise";
            if (userName != "All")
                sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = userName;
            sqlCmd.Parameters.Add(new SqlParameter("@YatraYear", SqlDbType.Int)).Value = yatraYear;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCashReport_Userwise = this.ExecuteToDataSet(sqlCmd);
            return dsCashReport_Userwise;
        }
        # endregion getCashReport_Userwise
        
        # region getCashReport_UserwiseYearly 

        public DataSet getCashReport_UserwiseYearly(int yatraYear)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "CashReport_UserwiseYearly";
            sqlCmd.Parameters.Add(new SqlParameter("@YatraYear", SqlDbType.Int)).Value = yatraYear;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCashReport_UserwiseYearly = this.ExecuteToDataSet(sqlCmd);
            return dsCashReport_UserwiseYearly;
        }
        # endregion getCashReport_UserwiseYearly

        # region getDailyCashReport
        public DataSet getDailyCashReport(DateTime Yatra_Date)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "DailyCashReport";
            sqlCmd.Parameters.Add(new SqlParameter("@Registration_Date", SqlDbType.Date)).Value = Yatra_Date;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsDailyCashReport = this.ExecuteToDataSet(sqlCmd);
            return dsDailyCashReport;
        }

        public DataSet getDailyCashReport(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "DailyCashReport_Yearly";
            sqlCmd.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.Date)).Value = FromDate;
            sqlCmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.Date)).Value = ToDate;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsDailyCashReport = this.ExecuteToDataSet(sqlCmd);
            return dsDailyCashReport;
        }
        # endregion getDailyCashReport

        #region Discount Report 
        public DataSet getDiscountReport(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "DiscountReport_Yearly";
            sqlCmd.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.Date)).Value = FromDate;
            sqlCmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.Date)).Value = ToDate;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsDiscountReport = this.ExecuteToDataSet(sqlCmd);
            return dsDiscountReport;
        } 
        #endregion

        # region getBusReport
        public DataSet getBusReport(DateTime Yatra_Date, string Bus_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "BusReport";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            if (Bus_Name != "All")
                sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsBusReport = this.ExecuteToDataSet(sqlCmd);
            return dsBusReport;
        }

        public DataSet getBusReport(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "BusReport_Yearly";
            sqlCmd.Parameters.Add(new SqlParameter("@FromDate", SqlDbType.Date)).Value = FromDate;
            sqlCmd.Parameters.Add(new SqlParameter("@ToDate", SqlDbType.Date)).Value = ToDate;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsBusReport = this.ExecuteToDataSet(sqlCmd);
            return dsBusReport;
        }
        
        # endregion getBusReport

        # region getEmptySeats 
        public DataSet getEmptySeats(DateTime Yatra_Date, string Bus_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "EmptySeats";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;
            if (Bus_Name != "All")
                sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsgetEmptySeats = this.ExecuteToDataSet(sqlCmd);
            return dsgetEmptySeats;
        }
        # endregion getBusReport

        # region getAllYatraDatesAllBusesCashReport
        public DataSet getAllYatraDatesAllBusesCashReport(DateTime Yatra_Date_From, DateTime Yatra_Date_To)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "AllYatraDateAllBusesCashReport";
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date_From", SqlDbType.Date)).Value = Yatra_Date_From;
            sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date_To", SqlDbType.Date)).Value = Yatra_Date_To;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCashReport = this.ExecuteToDataSet(sqlCmd);
            return dsCashReport;
        }
        # endregion getDailyCashReport

        # region getBloodGroupReport
        public DataSet getBloodGroupReport(string Blood_Group)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "BloodGroupReport";
            if (Blood_Group != "All")
                sqlCmd.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.VarChar)).Value = Blood_Group;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsBGReport = this.ExecuteToDataSet(sqlCmd);
            return dsBGReport;
        }
        # endregion getBloodGroupReport

        # region getBirthDateReport 
        public DataSet getBirthDateReport(int BirthMonth = 0, DateTime? BirthDate = null, bool ForReport = false)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "BirthDateReport";
            if (BirthMonth != 0)
                sqlCmd.Parameters.Add(new SqlParameter("@BirthMonth", SqlDbType.Int)).Value = BirthMonth;
            if (BirthDate != null)
                sqlCmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date)).Value = BirthDate;
            if (ForReport != false)
                sqlCmd.Parameters.Add(new SqlParameter("@ForReport", SqlDbType.Bit)).Value = ForReport;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsBGReport = this.ExecuteToDataSet(sqlCmd);
            return dsBGReport;
        }
        # endregion getBirthDateReport

        # region getExpenseReport
        public DataSet getExpenseReport(string UserName, int FromYear, int ToYear)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getCashExpenseReport";
            sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = UserName;
            sqlCmd.Parameters.Add(new SqlParameter("@FromYear", SqlDbType.Int)).Value = FromYear;
            sqlCmd.Parameters.Add(new SqlParameter("@ToYear", SqlDbType.Int)).Value = ToYear;
            
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerReport = this.ExecuteToDataSet(sqlCmd);
            return dsCustomerReport;
        }

        public DataSet getExpenseReport(int FromYear, int ToYear)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getCashExpenseReport";
            sqlCmd.Parameters.Add(new SqlParameter("@FromYear", SqlDbType.Int)).Value = FromYear;
            sqlCmd.Parameters.Add(new SqlParameter("@ToYear", SqlDbType.Int)).Value = ToYear;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsCustomerReport = this.ExecuteToDataSet(sqlCmd);
            return dsCustomerReport;
        }
        # endregion getExpenseReport 

        # region searchCustomer
        public DataSet searchCustomer(string Customer_ID, string Blood_Group, DateTime? Yatra_Date, int Yatra_Year, string Mobile_No, string Alternate_Mobile_No, string First_Name, string Last_Name, string Bus_Name)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "SearchReport";

            //if (showAll == false)
            {
                if (!string.IsNullOrEmpty(Customer_ID))
                    sqlCmd.Parameters.Add(new SqlParameter("@Cust_ID", SqlDbType.VarChar)).Value = Customer_ID;

                if (!string.IsNullOrEmpty(Blood_Group))
                    sqlCmd.Parameters.Add(new SqlParameter("@Blood_Group", SqlDbType.VarChar)).Value = Blood_Group;

                if (Yatra_Date != null)
                    sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Date", SqlDbType.Date)).Value = Yatra_Date;

                if (Yatra_Year != 0)
                    sqlCmd.Parameters.Add(new SqlParameter("@Yatra_Year", SqlDbType.Int)).Value = Yatra_Year;

                if (!string.IsNullOrEmpty(Bus_Name))
                    sqlCmd.Parameters.Add(new SqlParameter("@Bus_Name", SqlDbType.VarChar)).Value = Bus_Name;

                if (!string.IsNullOrEmpty(Mobile_No))
                    sqlCmd.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.VarChar)).Value = Mobile_No;

                if (!string.IsNullOrEmpty(Alternate_Mobile_No))
                    sqlCmd.Parameters.Add(new SqlParameter("@Alternate_Mobile_No", SqlDbType.VarChar)).Value = Alternate_Mobile_No;

                if (!string.IsNullOrEmpty(First_Name))
                    sqlCmd.Parameters.Add(new SqlParameter("@First_Name", SqlDbType.VarChar)).Value = First_Name;

                if (!string.IsNullOrEmpty(Last_Name))
                    sqlCmd.Parameters.Add(new SqlParameter("@Last_Name", SqlDbType.VarChar)).Value = Last_Name;
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsSearchCustomer = this.ExecuteToDataSet(sqlCmd);
            return dsSearchCustomer;
        }
        # endregion searchCustomer

        # region getAllExpenseTypeTransactions
        public DataSet getAllExpenseTypeTransactions(DateTime Expense_Date)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "getAllCashExpenseTransactions";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(new SqlParameter("@Expense_Date", SqlDbType.Date)).Value = Expense_Date;
            DataSet dsgetAllExpenseTypeTransactions = this.ExecuteToDataSet(sqlCmd);
            return dsgetAllExpenseTypeTransactions;
        }
        # endregion getAllExpenseTypeTransactions

        # region DeleteCashExpenseTransaction
        public DataSet DeleteCashExpenseTransaction(int Auto_ID)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "DeleteCashExpenseTransaction";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(new SqlParameter("@Auto_ID", SqlDbType.Int)).Value = Auto_ID;
            DataSet dsDeleteExpenseTypeTransaction = this.ExecuteToDataSet(sqlCmd);
            return dsDeleteExpenseTypeTransaction;
        }
        # endregion DeleteCashExpenseTransaction

        # region InsertUpdateCashExpenseTransaction
        public DataSet InsertUpdateCashExpenseTransaction(int Auto_ID, DateTime Expense_Date, int Expense_ID, int Amount, string Remarks, string UserName)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Parameters.Clear();
            sqlCmd.CommandText = "InsertUpdateCashExpenseTransaction";
            if (!string.IsNullOrEmpty(Remarks))
                sqlCmd.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.VarChar)).Value = Remarks;

            sqlCmd.Parameters.Add(new SqlParameter("@Auto_ID", SqlDbType.Int)).Value = Auto_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@Expense_ID", SqlDbType.Int)).Value = Expense_ID;
            sqlCmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int)).Value = Amount;
            sqlCmd.Parameters.Add(new SqlParameter("@Expense_Date", SqlDbType.Date)).Value = Expense_Date;
            sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = UserName;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            DataSet dsInsertUpdateCashExpenseTransaction = this.ExecuteToDataSet(sqlCmd);
            return dsInsertUpdateCashExpenseTransaction;
        }
        # endregion InsertUpdateCashExpenseTransaction


        # region ExecuteToDataSet
        public DataSet ExecuteToDataSet(SqlCommand sqlCmd)
        {
            try
            {
                //sourcePath = "server=" + ((string)(AppSettings.GetValue("HostName", typeof(string)))) + ";Initial Catalog=" + ((string)(AppSettings.GetValue("DatabaseName", typeof(string)))) + ";uid=" + ((string)(AppSettings.GetValue("UserID", typeof(string)))) + ";pwd=" + ((string)(AppSettings.GetValue("Password", typeof(string)))) + ";";
                sourcePath = "data source=" + ((string)(AppSettings.GetValue("HostName", typeof(string)))) + ";Initial Catalog=" + ((string)(AppSettings.GetValue("DatabaseName", typeof(string)))) + ";user id=" + ((string)(AppSettings.GetValue("UserID", typeof(string)))) + ";password=" + ((string)(AppSettings.GetValue("Password", typeof(string)))) + ";";
                dataSet = new DataSet();
                sqlCon = new SqlConnection(sourcePath);
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlDa = new SqlDataAdapter(sqlCmd);

                sqlDa.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
            finally
            { sqlCon.Close(); }
        }
        # endregion ExecuteToDataSet
    }
}
