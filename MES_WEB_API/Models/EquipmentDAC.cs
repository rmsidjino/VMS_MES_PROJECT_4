﻿using MESDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace MES_WEB_API.Models
{
    public class EquipmentDAC : IDisposable
    {
        SqlConnection conn;
        public EquipmentDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }
        public List<EquipmentVO> GetAllEquipment()
        {
            string sql = @"select SITE_ID, LINE_ID, EQP_ID, EQP_MODEL, EQP_GROUP, SIM_TYPE, 
PRESET_ID, DISPATCHER_ID, EQP_STATE, EQP_STATE_CODE, STATE_CHANGE_TIME, AUTOMATION, MODIFIER, MODIFIER_DATE 
                                    from EQUIPMENT";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<EquipmentVO>(cmd.ExecuteReader()); ;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertEquipment (EquipmentVO equipment)
        {
            string sql = @"insert into [EQUIPMENT] (SITE_ID, LINE_ID, EQP_ID, EQP_MODEL, EQP_TYPE,EQP_GROUP, SIM_TYPE, 
PRESET_ID, DISPATCHER_ID, EQP_STATE, EQP_STATE_CODE, STATE_CHANGE_TIME, AUTOMATION, MODIFIER, MODIFIED_DATE)
values(@SITE_ID, @LINE_ID, @EQP_ID, @EQP_MODEL, @EQP_TYPE, @EQP_GROUP, @SIM_TYPE, 
@PRESET_ID, @DISPATCHER_ID, @EQP_STATE, @EQP_STATE_CODE, @STATE_CHANGE_TIME, @AUTOMATION, @MODIFIER, @MODIFIER_DATE)";

            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@SITE_ID", equipment.SITE_ID);
                cmd.Parameters.AddWithValue("@LINE_ID", equipment.LINE_ID);
                cmd.Parameters.AddWithValue("@EQP_ID", equipment.EQP_ID);
                cmd.Parameters.AddWithValue("@EQP_MODEL", equipment.EQP_MODEL);
                cmd.Parameters.AddWithValue("@EQP_TYPE", equipment.EQP_TYPE);
                cmd.Parameters.AddWithValue("@EQP_GROUP", equipment.EQP_GROUP);
                cmd.Parameters.AddWithValue("@SIM_TYPE", equipment.SIM_TYPE);
                cmd.Parameters.AddWithValue("@PRESET_ID", equipment.PRESET_ID);
                cmd.Parameters.AddWithValue("@DISPATCHER_ID", equipment.DISPATCHER_ID);
                cmd.Parameters.AddWithValue("@EQP_STATE", equipment.EQP_STATE);
                cmd.Parameters.AddWithValue("@EQP_STATE_CODE", equipment.EQP_STATE_CODE);
                cmd.Parameters.AddWithValue("@STATE_CHANGE_TIME", equipment.STATE_CHANGE_TIME);
                cmd.Parameters.AddWithValue("@AUTOMATION", equipment.AUTOMATION);
                cmd.Parameters.AddWithValue("@MODIFIER", equipment.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", equipment.MODIFIER_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteEquipment(string eqpID)
        {
            string sql = @"Delete from EQUIPMENT where EQP_ID = @EQP_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@EQP_ID", eqpID);

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

        public EquipmentVO GetEquipmentInfo(string eqpID)
        {
            string sql = @"select SITE_ID, LINE_ID, EQP_ID, EQP_MODEL, EQP_GROUP, SIM_TYPE, 
PRESET_ID, DISPATCHER_ID, EQP_STATE, EQP_STATE_CODE, STATE_CHANGE_TIME, AUTOMATION, MODIFIER, MODIFIER_DATE 
                                    from EQUIPMENT where EQP_ID=@EQP_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EQP_ID", eqpID);

                    cmd.Connection.Open();
                    List<EquipmentVO> list = Helper.DataReaderMapToList<EquipmentVO>(cmd.ExecuteReader());
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