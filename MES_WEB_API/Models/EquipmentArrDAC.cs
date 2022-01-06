using MESDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace MES_WEB_API.Models
{
    public class EquipmentArrDAC:IDisposable
    {
        string strConn = string.Empty;
        SqlConnection conn;
        public EquipmentArrDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }
        public List<EquipmentArrVO> GetAllEquipmentArr()
        {
            string sql = @"select PRODUCT_ID,PROCESS_ID,STEP_ID,EQP_ID,TACT_TIME,PROC_TIME,EFF_START_DATE,EFF_END_DATE,MODIFIER, MODIFIER_DATE
                                    from EQP_ARRANGE";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<EquipmentArrVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertEquipmentArr(EquipmentArrVO equipmentarr)
        {
            string sql = @"insert into [EQP_ARRANGE] (PRODUCT_ID,PROCESS_ID,STEP_ID,EQP_ID,TACT_TIME,PROC_TIME,EFF_START_DATE,EFF_END_DATE,MODIFIER,MODIFIER_DATE)
values(@PRODUCT_ID,@PROCESS_ID,@STEP_ID,@EQP_ID,@TACT_TIME,@PROC_TIME,@EFF_START_DATE,@EFF_END_DATE,@MODIFIER,@MODIFIER_DATE)";

            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@PRODUCT_ID", equipmentarr.PRODUCT_ID);
                cmd.Parameters.AddWithValue("@PROCESS_ID", equipmentarr.PROCESS_ID);
                cmd.Parameters.AddWithValue("@STEP_ID", equipmentarr.STEP_ID);
                cmd.Parameters.AddWithValue("@EQP_ID", equipmentarr.EQP_ID);
                cmd.Parameters.AddWithValue("@TACT_TIME", equipmentarr.TACT_TIME);
                cmd.Parameters.AddWithValue("@PROC_TIME", equipmentarr.PROC_TIME);
                cmd.Parameters.AddWithValue("@EFF_START_DATE", equipmentarr.EFF_START_DATE);
                cmd.Parameters.AddWithValue("@EFF_END_DATE", equipmentarr.EFF_END_DATE);
                cmd.Parameters.AddWithValue("@MODIFIER", equipmentarr.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", equipmentarr.MODIFIER_DATE);
                
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DelEquipmentArr(string id)
        {
            string sql = @"Delete from EQP_ARRANGE where PRODUCT_ID = @PRODUCT_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@PRODUCT_ID", id);

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

        public List<EquipmentArrVO> SearchEquipmentArr(string productID, string processID)
        {

            string sql = @"select PRODUCT_ID,PROCESS_ID,STEP_ID,EQP_ID,TACT_TIME,PROC_TIME,EFF_START_DATE,EFF_END_DATE, MODIFIER, MODIFIER_DATE 
                                    from EQP_ARRANGE where 1=1 ";


            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (productID != null && productID.Trim().Length > 0)
                    {
                        sql += " and PRODCUCT_ID=@PRODCUCT_ID";
                        cmd.Parameters.AddWithValue("@PRODCUCT_ID", productID);
                    }

                    if (processID != null && processID.Trim().Length > 0)
                    {
                        sql += " and PROCESS_ID=@PROCESS_ID";
                        cmd.Parameters.AddWithValue("@PROCESS_ID", processID);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<EquipmentArrVO> list = Helper.DataReaderMapToList<EquipmentArrVO>(cmd.ExecuteReader());
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
