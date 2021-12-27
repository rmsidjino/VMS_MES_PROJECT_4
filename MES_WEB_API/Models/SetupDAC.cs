using MESDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public bool DeleteSetup(string siteID)
        {
            string sql = @"Delete from SETUP_TIME where SITE_ID = @SITE_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@SITE_ID", siteID);

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

        public SetupVO GetSetupInfo(string siteID)
        {
            string sql = @"select SITE_ID, LINE_ID, EQP_GROUP, STEP_ID, TIME, MODIFIER,MODIFIED_DATE 
                                    from SETUP_TIME where SITE_ID=@SITE_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SITE_ID", siteID);

                    cmd.Connection.Open();
                    List<SetupVO> list = Helper.DataReaderMapToList<SetupVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();

                    if (list != null && list.Count > 0)
                        return list[0];
                    else
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}