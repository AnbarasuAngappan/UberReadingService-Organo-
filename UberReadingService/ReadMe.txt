//graph.Add(new Graph()
//{
//    _societyID = datarowItem[columnItem].ToString()
//});

https://stackoverflow.com/questions/15569860/passing-parameter-to-stored-procedure-in-c-sharp

https://social.msdn.microsoft.com/Forums/vstudio/en-US/dc5f5b05-ff50-48dc-bf17-b39e60575af1/wcf-error-the-server-was-unable-to-process-the-request-due-to-an-internal-error?forum=wcf

foreach (DataRow datarowItem in dt.Rows)
{
    foreach (DataColumn columnItem in dt.Columns)
    {                                
        if (datarowItem[columnItem] != null)
        {
            var _houseID = datarowItem[columnItem].ToString();
            var _soceityID = datarowItem[4].ToString();
            var _meterID = datarowItem[columnItem].ToString();
            var _ipAddress = datarowItem[columnItem].ToString();
            var _meterType = datarowItem[columnItem].ToString();

            //if (_houseID !=null && _meterType != null)
            //{
            //    if (_meterType == "ModBus")
            //        ReadModbus(_ipAddress, 502, 40009, 0);
            //    else if (_meterType == "RS232")
            //        ReadDLMX();
            //}
        }                                 
    }
}

public void ReadHousedetails(string _societyID)
        {
            using (SqlConnection con = new SqlConnection("Data Source= IB-ANBARASU; Integrated Security=true;Initial Catalog= designdb; uid=sa; Password=utl@123;"))
            using (SqlCommand cmd = new SqlCommand())
                try
                {
                    //var graph = new ObservableCollection<Graph>();
                    if (con != null && cmd != null)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * From Graphs Where SocietyID = @SocietyID";
                        cmd.Parameters.Add("@SocietyID", _societyID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("HouseDetails");
                            da.Fill(dt);
                            int columnIndex = dt.Columns.Count;
                            foreach (DataRow datarowItem in dt.Rows)
                            {
                                var _houseID = datarowItem.Field<string>("HouseID");
                                var _soceityID = datarowItem.Field<string>("SocietyID");
                                var _meterID = datarowItem.Field<string>("MeterID");
                                var _ipAddress = datarowItem.Field<string>("IPAddress");
                                var _port = datarowItem.Field<string>("Port");
                                int _intPort = Convert.ToInt32(_port);
                                var _meterType = "ModBus";
                               
                                if (_houseID != null && _meterType != null)
                                {
                                    if (_meterType == "ModBus")
                                        ReadModbus(_ipAddress, _intPort, 40009, 1);
                                    else if (_meterType == "RS232")
                                        ReadDLMX();
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }

                    if (con != null)
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
}