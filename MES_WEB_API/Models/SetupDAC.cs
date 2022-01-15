using MESDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MES_WEB_API.Models
{
    public class SetupDAC : IDisposable
    {
        SqlConnection conn;
        public SetupDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }
        public List<SetupVO> GetAllSetup()
        {
            string sql = @"select SITE_ID, LINE_ID, EQP_GROUP, STEP_ID, TIME, MODIFIER,MODIFIED_DATE 
                                    from SETUP_TIME";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<SetupVO>(cmd.ExecuteReader()); ;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertSetup(SetupVO setup)
        {
            string sql = @"insert into [SETUP_TIME] (SITE_ID, LINE_ID, EQP_GROUP, STEP_ID, TIME, MODIFIER, MODIFIED_DATE)
values(@SITE_ID,@LINE_ID,@EQP_GROUP,@STEP_ID,@TIME,@MODIFIER,@MODIFIED_DATE)";

            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@SITE_ID", setup.SITE_ID);
                cmd.Parameters.AddWithValue("@LINE_ID", setup.LINE_ID);
                cmd.Parameters.AddWithValue("@EQP_GROUP", setup.EQP_GROUP);
                cmd.Parameters.AddWithValue("@STEP_ID", setup.STEP_ID);
                cmd.Parameters.AddWithValue("@TIME", setup.TIME);
                cmd.Parameters.AddWithValue("@MODIFIER", setup.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIED_DATE", setup.MODIFIED_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteSetup(string stepID)
        {
            string sql = @"Delete from SETUP_TIME where STEP_ID = @STEP_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@STEP_ID", stepID);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public bool UpdateSetup(SetupVO setup)
        {
            string sql = @"update SETUP_TIME set SITE_ID=@SITE_ID, LINE_ID=@LINE_ID, EQP_GROUP=@EQP_GROUP, TIME=@TIME, MODIFIER=@MODIFIER, MODIFIED_DATE=@MODIFIED_DATE where STEP_ID=@STEP_ID";


            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@SITE_ID", setup.SITE_ID);
                cmd.Parameters.AddWithValue("@LINE_ID", setup.LINE_ID);
                cmd.Parameters.AddWithValue("@EQP_GROUP", setup.EQP_GROUP);
                cmd.Parameters.AddWithValue("@STEP_ID", setup.STEP_ID);
                cmd.Parameters.AddWithValue("@TIME", setup.TIME);
                cmd.Parameters.AddWithValue("@MODIFIER", setup.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIED_DATE", setup.MODIFIED_DATE);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public List<SetupVO> SearchSetup(string siteID="", string stepID="")
        {
            string sql = @"select SITE_ID, LINE_ID, EQP_GROUP, STEP_ID, TIME, MODIFIER,MODIFIED_DATE 
                                    from SETUP_TIME where 1 = 1";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (siteID != null && siteID.Trim().Length > 0)
                    {
                        sql += " and SITE_ID=@SITE_ID";
                        cmd.Parameters.AddWithValue("@SITE_ID", siteID);
                    }

                    if (stepID != null && stepID.Trim().Length > 0)
                    {
                        sql += " and STEP_ID=@STEP_ID";
                        cmd.Parameters.AddWithValue("@STEP_ID", stepID);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<SetupVO> list = Helper.DataReaderMapToList<SetupVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();

                    return list;
                }
            }

            catch (Exception err)
            {
                return null;
            }
        }
    }
}