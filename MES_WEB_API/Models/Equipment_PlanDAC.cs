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
    public class Equipment_PlanDAC
    {
        string strConn = string.Empty;
        SqlConnection conn;
        public Equipment_PlanDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }
        public List<Equipment_PlanVO> GetAllEquipmentPlan()
        {
            string sql = @"select VERSION_NO,LINE_ID,EQP_ID,LOT_ID,PRODUCT_ID,PROCESS_ID,STEP_ID,PROCESS_QTY,CONVERT(CHAR(19), DISPATCH_IN_TIME, 20) DISPATCH_IN_TIME , CONVERT(CHAR(19), START_TIME, 20) START_TIME,CONVERT(CHAR(19), END_TIME, 20) END_TIME,MACHINE_STATE,DUE_DATE,MODIFIER,MODIFIER_DATE
                                    from EQP_PLAN";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<Equipment_PlanVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertEquipmentPlan(Equipment_PlanVO equipmentplan)
        {
            string sql = @"insert into [EQP_PLAN] (VERSION_NO,LINE_ID,EQP_ID,LOT_ID,PRODUCT_ID,PROCESS_ID,STEP_ID,PROCESS_QTY,DISPATCH_IN_TIME,START_TIME,END_TIME,MACHINE_STATE,DUE_DATE,MODIFIER,MODIFIER_DATE)
values(@VERSION_NO,@LINE_ID,@EQP_ID,@LOT_ID,@PRODUCT_ID,@PROCESS_ID,@STEP_ID,@PROCESS_QTY,@DISPATCH_IN_TIME,@START_TIME,@END_TIME,@MACHINE_STATE,@DUE_DATE,@MODIFIER,@MODIFIER_DATE)";

            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@VERSION_NO", equipmentplan.VERSION_NO);
                cmd.Parameters.AddWithValue("@LINE_ID", equipmentplan.LINE_ID);
                cmd.Parameters.AddWithValue("@EQP_ID", equipmentplan.EQP_ID);
                cmd.Parameters.AddWithValue("@LOT_ID", equipmentplan.LOT_ID);
                cmd.Parameters.AddWithValue("@PRODUCT_ID", equipmentplan.PRODUCT_ID);
                cmd.Parameters.AddWithValue("@PROCESS_ID", equipmentplan.PROCESS_ID);
                cmd.Parameters.AddWithValue("@STEP_ID", equipmentplan.STEP_ID);
                cmd.Parameters.AddWithValue("@PROCESS_QTY", equipmentplan.PROCESS_QTY);
                cmd.Parameters.AddWithValue("@DISPATCH_IN_TIME", equipmentplan.DISPATCH_IN_TIME);
                cmd.Parameters.AddWithValue("@START_TIME", equipmentplan.START_TIME);
                cmd.Parameters.AddWithValue("@END_TIME", equipmentplan.END_TIME);
                cmd.Parameters.AddWithValue("@MACHINE_STATE", equipmentplan.MACHINE_STATE);
                cmd.Parameters.AddWithValue("@DUE_DATE", equipmentplan.DUE_DATE);
                cmd.Parameters.AddWithValue("@MODIFIER", equipmentplan.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", equipmentplan.MODIFIER_DATE);



                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DelEquipmentPlan(string id)
        {
            string sql = @"Delete from EQP_PLAN where PRODUCT_ID = @PRODUCT_ID ";

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

        public List<Equipment_PlanVO> SearchEquipmentPlan(string productID)
        {

            string sql = @"select VERSION_NO,LINE_ID,EQP_ID,LOT_ID,PRODUCT_ID,PROCESS_ID,STEP_ID,PROCESS_QTY,DISPATCH_IN_TIME,START_TIME,END_TIME,MACHINE_STATE,DUE_DATE,MODIFIER,MODIFIER_DATE 
                                    from EQP_PLAN where 1=1 ";


            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (productID != null && productID.Trim().Length > 0)
                    {
                        sql += " and PRODUCT_ID=@PRODUCT_ID";
                        cmd.Parameters.AddWithValue("@PRODUCT_ID", productID);
                    }

                   
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<Equipment_PlanVO> list = Helper.DataReaderMapToList<Equipment_PlanVO>(cmd.ExecuteReader());
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