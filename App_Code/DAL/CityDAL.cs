﻿using Addressbook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;

/// <summary>
/// Summary description for CityDAL
/// </summary>

namespace Addressbook.DAL
{
    public class CityDAL : DatabaseConfig
    {
        #region constructor
        public CityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Local Variables : Message
        protected String _Message;
        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variables : Message

        #region SelectAll
        //Get City List
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectAllByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepared Command

                        #region ReadData & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData & Set Control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        internal bool DeleteCity(CityENT entCity)
        {
            throw new NotImplementedException();
        }
        #endregion SelectAll

        #region SelectByPK
        //Get City BY ID
        public CityENT SelectByPK(SqlInt32 CityID, SqlInt32 UserID)
        {
            //SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepared Command

                        #region ReadData & Set Control
                        CityENT entCity = new CityENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entCity.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entCity.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entCity.CityID = Convert.ToInt32(objSDR["CityID"]);
                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                    entCity.CityName = Convert.ToString(objSDR["CityName"]);
                                if (!objSDR["STDCode"].Equals(DBNull.Value))
                                    entCity.STDCode = Convert.ToString(objSDR["STDCode"]);
                                if (!objSDR["PINCode"].Equals(DBNull.Value))
                                    entCity.PINCode = Convert.ToString(objSDR["PINCode"]);
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    entCity.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString());
                                break;
                            }
                        }
                        return entCity;
                        #endregion ReadData & Set Control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByPK

        /*  #region Select SelectForDropDownList Country
        public DataTable SelectForDropDownListCountry(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectForDropDownList";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepared Command & Set Parameters

                        #region ReadData & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData & Set Control

                    }
                    catch (SqlException sqlex)
                    {

                        Message = sqlex.InnerException.Message.ToString();
                        return null;

                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Select SelectForDropDownList Country

        #region SelectForDropDownList State by CountryID
        public DataTable SelectForDropDownListStateByCountryID(SqlInt32 UserID, SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectByCountryID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion Prepared Command & Set Parameters

                        #region ReadData & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData & Set Control

                    }
                    catch (SqlException sqlex)
                    {

                        Message = sqlex.InnerException.Message.ToString();
                        return null;

                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectForDropDownList State by CountryID*/

        #region Get City For DropDown
        public DataTable GetCityDropDown(SqlInt32 UserID, SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        if (objConn.State != ConnectionState.Open)
                            objConn.Open();
                        DataTable dt = new DataTable();
                        #region Create Command and Bind Data
                       
                        objCmd.CommandType = CommandType.StoredProcedure;

                        if (!StateID.IsNull)
                        {

                            objCmd.CommandText = "PR_City_SelectByStateID";
                            objCmd.Parameters.AddWithValue("@StateID", StateID);
                        }
                        else
                        {
                            objCmd.CommandText = "PR_City_SelectForDropDownList";
                        }

                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        dt.Load(objSDR);

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                        return dt;

                        #endregion Create Command and Bind Data

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Get City For DropDown

        #region Insert City
        public Boolean InsertCity(CityENT entCity)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entCity.CountryID);
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@PINCode", entCity.PINCode);

                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("Violation of UNIQUE KEY constraint "))
                        {
                            _Message = "This City already exist";
                            return false;
                        }
                        else
                        {
                            Message = sqlex.InnerException.Message.ToString();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Insert City

        #region Update City
        public Boolean UpdateCity(CityENT entCity)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_UpdateByPK";

                        objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entCity.CountryID);
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@PINCode", entCity.PINCode);

                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command & Set Parameters

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("Violation of UNIQUE KEY constraint"))
                        {
                            _Message = "This City already exist";
                            return false;
                        }
                        else
                        {
                            Message = sqlex.InnerException.Message.ToString();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Update City

        #region Delete City
        public Boolean DeleteCity(SqlInt32 CityID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepared Command & Set Parameters
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_DeleteByPK";

                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        objCmd.ExecuteNonQuery();

                        #endregion Prepared Command & Set Parameters

                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        if (sqlex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            _Message = "This City contain some records, So please delete these record, If you want to delete this City.";
                            return false;
                        }
                        else
                        {
                            _Message = sqlex.Message;
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Delete City

      

    }
}