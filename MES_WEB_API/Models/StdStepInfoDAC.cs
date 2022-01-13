using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using MESDTO;

namespace MES_WEB_API.Models
{
    public class StdStepInfoDAC
    {
        SqlConnection conn;

        public StdStepInfoDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public List<StdStepInfoVO> GetAllStd_step_info()
        {
            string sql = @"select STD_STEP_ID, STD_STEP_NAME, STEP_TAT, STEP_YIELD, STEP_SETUP, MODIFIER, MODIFIER_DATE 
from STD_STEP_INFO";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<StdStepInfoVO>(cmd.ExecuteReader()); ;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertStd_step_info(StdStepInfoVO std_step_info)
        {
            string sql = @"insert into [STD_STEP_INFO] (STD_STEP_ID, STD_STEP_NAME, STEP_TAT, STEP_YIELD, STEP_SETUP, MODIFIER, MODIFIER_DATE)
values(@STD_STEP_ID, @STD_STEP_NAME, @STEP_TAT, @STEP_YIELD, @STEP_SETUP, @MODIFIER, @MODIFIER_DATE)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@STD_STEP_ID", std_step_info.STD_STEP_ID);
                cmd.Parameters.AddWithValue("@STD_STEP_NAME", std_step_info.STD_STEP_NAME);
                cmd.Parameters.AddWithValue("@STEP_TAT", std_step_info.STEP_TAT);
                cmd.Parameters.AddWithValue("@STEP_YIELD", std_step_info.STEP_YIELD);
                cmd.Parameters.AddWithValue("@STEP_SETUP", std_step_info.STEP_SETUP);
                cmd.Parameters.AddWithValue("@MODIFIER", std_step_info.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", std_step_info.MODIFIER_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteStd_step_info(string id)
        {
            string sql = @"Delete from STD_STEP_INFO where STD_STEP_ID = @STD_STEP_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@STD_STEP_ID", id);

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

        public StdStepInfoVO GetStd_step_infoInfo(string id)
        {
            string sql = @"select STD_STEP_ID, STD_STEP_NAME, STEP_TAT, STEP_YIELD, STEP_SETUP, MODIFIER, MODIFIER_DATE
                                    from STD_STEP_INFO where STD_STEP_ID=@STD_STEP_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@STD_STEP_ID", id);

                    cmd.Connection.Open();
                    List<StdStepInfoVO> list = Helper.DataReaderMapToList<StdStepInfoVO>(cmd.ExecuteReader());
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

        public List<StdStepInfoVO> SearchStdStepInfoList(string std_step_ID = "")
        {
            string sql = @"select STD_STEP_ID, STD_STEP_NAME, STEP_TAT, STEP_YIELD, STEP_SETUP, MODIFIER, MODIFIER_DATE
                                    from STD_STEP_INFO where 1=1 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (std_step_ID != null && std_step_ID.Trim().Length > 0)
                    {
                        sql += " and STD_STEP_ID=@STD_STEP_ID";
                        cmd.Parameters.AddWithValue("@STD_STEP_ID", std_step_ID);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<StdStepInfoVO> list = Helper.DataReaderMapToList<StdStepInfoVO>(cmd.ExecuteReader());
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