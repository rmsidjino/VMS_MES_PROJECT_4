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
    public class DemandDAC
    {
        //string conn = string.Empty;
        SqlConnection conn;

        public DemandDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public List<DemandVO> GetAllDemand()
        {
            string sql = @"select DEMAND_VER, DEMAND_ID, PRODUCT_ID, CUSTOMER_ID, DUE_DATE, DEMAND_QTY, MODIFIER, MODIFIER_DATE 
from DEMAND";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<DemandVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertDemand(DemandVO demand)
        {
            string sql = @"insert into [DEMAND] (DEMAND_VER, DEMAND_ID, PRODUCT_ID, CUSTOMER_ID, DUE_DATE, DEMAND_QTY, MODIFIER, MODIFIER_DATE)
values(@DEMAND_VER, @DEMAND_ID, @PRODUCT_ID, @CUSTOMER_ID, @DUE_DATE, @DEMAND_QTY, @MODIFIER, @MODIFIER_DATE)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@DEMAND_VER", demand.DEMAND_VER);
                cmd.Parameters.AddWithValue("@DEMAND_ID", demand.DEMAND_ID);
                cmd.Parameters.AddWithValue("@PRODUCT_ID", demand.PRODUCT_ID);
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", demand.CUSTOMER_ID);
                cmd.Parameters.AddWithValue("@DUE_DATE", demand.DUE_DATE);
                cmd.Parameters.AddWithValue("@DEMAND_QTY", demand.DEMAND_QTY);
                cmd.Parameters.AddWithValue("@MODIFIER", demand.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", demand.MODIFIER_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteDemand(string id)
        {
            string sql = @"Delete from DEMAND where DEMAND_VER = @DEMAND_VER ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@DEMAND_VER", id);

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

        public DemandVO GetDemandInfo(string id)
        {
            string sql = @"select DEMAND_VER, DEMAND_ID, PRODUCT_ID, CUSTOMER_ID, DUE_DATE, DEMAND_QTY, MODIFIER, MODIFIER_DATE 
from DEMAND where DEMAND_VER=@DEMAND_VER";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DEMAND_VER", id);

                    cmd.Connection.Open();
                    List<DemandVO> list = Helper.DataReaderMapToList<DemandVO>(cmd.ExecuteReader());
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

        public List<DemandVO> SearchDemandList(string demand_ver = "", string productID = "")
        {
            string sql = @"select DEMAND_VER, DEMAND_ID, PRODUCT_ID, CUSTOMER_ID, DUE_DATE, DEMAND_QTY, MODIFIER, MODIFIER_DATE 
from DEMAND where 1=1 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (demand_ver != null && demand_ver.Trim().Length > 0)
                    {
                        sql += " and DEMAND_VER=@DEMAND_VER";
                        cmd.Parameters.AddWithValue("@DEMAND_VER", demand_ver);
                    }

                    if (productID != null && productID.Trim().Length > 0)
                    {
                        sql += " and PRODUCT_ID=@PRODUCT_ID";
                        cmd.Parameters.AddWithValue("@PRODUCT_ID", productID);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<DemandVO> list = Helper.DataReaderMapToList<DemandVO>(cmd.ExecuteReader());
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