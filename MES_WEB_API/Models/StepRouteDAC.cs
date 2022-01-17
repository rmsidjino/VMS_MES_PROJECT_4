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
    public class StepRouteDAC
    {
        //string conn = string.Empty;
        SqlConnection conn;

        public StepRouteDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public List<StepRouteVO> GetAllStepRoute()
        {
            string sql = @"select PROCESS_ID, STEP_ID, STEP_SEQ, STD_STEP_ID, STEP_TYPE, PROCESS_TYPE, IN_STOCK, OUT_STOCK, MODIFIER, MODIFIER_DATE
from STEP_ROUTE";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<StepRouteVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertStepRoute(StepRouteVO step_route)
        {
            string sql = @"insert into [STEP_ROUTE] (PROCESS_ID, STEP_ID, STEP_SEQ, STD_STEP_ID, STEP_TYPE, PROCESS_TYPE, IN_STOCK, OUT_STOCK, MODIFIER, MODIFIER_DATE)
values(@PROCESS_ID, @STEP_ID, @STEP_SEQ, @STD_STEP_ID, @STEP_TYPE, @PROCESS_TYPE, @IN_STOCK, @OUT_STOCK, @MODIFIER, @MODIFIER_DATE)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@PROCESS_ID", step_route.PROCESS_ID);
                cmd.Parameters.AddWithValue("@STEP_ID", step_route.STEP_ID);
                cmd.Parameters.AddWithValue("@STEP_SEQ", step_route.STEP_SEQ);
                cmd.Parameters.AddWithValue("@STD_STEP_ID", step_route.STD_STEP_ID);
                cmd.Parameters.AddWithValue("@STEP_TYPE", step_route.STEP_TYPE);
                cmd.Parameters.AddWithValue("@PROCESS_TYPE", step_route.PROCESS_TYPE);
                cmd.Parameters.AddWithValue("@IN_STOCK", step_route.IN_STOCK);
                cmd.Parameters.AddWithValue("@OUT_STOCK", step_route.OUT_STOCK);
                cmd.Parameters.AddWithValue("@MODIFIER", step_route.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", step_route.MODIFIER_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteStepRoute(string id)
        {
            string sql = @"Delete from STEP_ROUTE where PROCESS_ID = @PROCESS_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@PROCESS_ID", id);

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

        public StepRouteVO GetStepRouteInfo(string id)
        {
            string sql = @"select PROCESS_ID, STEP_ID, STEP_SEQ, STD_STEP_ID, STEP_TYPE, PROCESS_TYPE, IN_STOCK, OUT_STOCK, MODIFIER, MODIFIER_DATE
from STEP_ROUTE where PROCESS_ID=@PROCESS_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PROCESS_ID", id);

                    cmd.Connection.Open();
                    List<StepRouteVO> list = Helper.DataReaderMapToList<StepRouteVO>(cmd.ExecuteReader());
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

        public List<StepRouteVO> SearchStepRouteList(string processID = "", string stepID = "")
        {
            string sql = @"select PROCESS_ID, STEP_ID, STEP_SEQ, STD_STEP_ID, STEP_TYPE, PROCESS_TYPE, IN_STOCK, OUT_STOCK, MODIFIER, MODIFIER_DATE
from STEP_ROUTE where 1=1 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (processID != null && processID.Trim().Length > 0)
                    {
                        sql += " and PROCESS_ID=@PROCESS_ID";
                        cmd.Parameters.AddWithValue("@PROCESS_ID", processID);
                    }

                    if (stepID != null && stepID.Trim().Length > 0)
                    {
                        sql += " and STEP_ID=@STEP_ID";
                        cmd.Parameters.AddWithValue("@STEP_ID", stepID);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<StepRouteVO> list = Helper.DataReaderMapToList<StepRouteVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();

                    return list;
                }
            }

            catch (Exception err)
            {
                return null;
            }
        }
        public bool UpdateStepRoute(StepRouteVO step_route)
        {
            string sql = "Update StepRoute set STEP_SEQ=@STEP_SEQ, STD_STEP_ID=@STD_STEP_ID, STEP_TYPE=@STEP_TYPE, PROCESS_TYPE=@PROCESS_TYPE, IN_STOCK=@IN_STOCK, OUT_STOCK=@OUT_STOCK, MODIFIER=@MODIFIER, MODIFIER_DATE=@MODIFIER_DATE where PROCESS_ID=@PROCESS_ID and STEP_ID=@STEP_ID";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@PROCESS_ID", step_route.PROCESS_ID);
                cmd.Parameters.AddWithValue("@STEP_ID", step_route.STEP_ID);
                cmd.Parameters.AddWithValue("@STEP_SEQ", step_route.STEP_SEQ);
                cmd.Parameters.AddWithValue("@STD_STEP_ID", step_route.STD_STEP_ID);
                cmd.Parameters.AddWithValue("@STEP_TYPE", step_route.STEP_TYPE);
                cmd.Parameters.AddWithValue("@PROCESS_TYPE", step_route.PROCESS_TYPE);
                cmd.Parameters.AddWithValue("@IN_STOCK", step_route.IN_STOCK);
                cmd.Parameters.AddWithValue("@OUT_STOCK", step_route.OUT_STOCK);
                cmd.Parameters.AddWithValue("@MODIFIER", step_route.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", step_route.MODIFIER_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}