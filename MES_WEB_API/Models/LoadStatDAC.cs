using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using MESDTO;

namespace MES_WEB_API.Models
{
    public class LoadStatDAC
    {
        //string conn = string.Empty;
        SqlConnection conn;
        DataTable dt = new DataTable();

        public LoadStatDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public List<LoadStatVO> GetAllLoadStat()
        {
            string sql = @"select VERSION_NO, LINE_ID, EQP_ID, TARGET_DATE, SETUP, BUSY, IDLERUN, IDLE, PM, DOWN, MODIFIER, MODIFIER_DATE
from LOAD_STAT";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<LoadStatVO> list = Helper.DataReaderMapToList<LoadStatVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertLoad_Stat(LoadStatVO load_stat)
        {
            string sql = @"insert into [LOAD_STAT] (VERSION_NO, LINE_ID, EQP_ID, TARGET_DATE, SETUP, BUSY, IDLERUN, IDLE, PM, DOWN, MODIFIER, MODIFIER_DATE)
values(@VERSION_NO, @LINE_ID, @EQP_ID, @TARGET_DATE, @SETUP, @BUSY, @IDLERUN, @IDLE, @PM, @DOWN, @MODIFIER, @MODIFIER_DATE)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@VERSION_NO", load_stat.VERSION_NO);
                cmd.Parameters.AddWithValue("@LINE_ID", load_stat.LINE_ID);
                cmd.Parameters.AddWithValue("@EQP_ID", load_stat.EQP_ID);
                cmd.Parameters.AddWithValue("@TARGET_DATE", load_stat.TARGET_DATE);
                cmd.Parameters.AddWithValue("@SETUP", load_stat.SETUP);
                cmd.Parameters.AddWithValue("@BUSY", load_stat.BUSY);
                cmd.Parameters.AddWithValue("@IDLERUN", load_stat.IDLERUN);
                cmd.Parameters.AddWithValue("@IDLE", load_stat.IDLE);
                cmd.Parameters.AddWithValue("@PM", load_stat.PM);
                cmd.Parameters.AddWithValue("@DOWN", load_stat.DOWN);
                cmd.Parameters.AddWithValue("@MODIFIER", load_stat.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIER_DATE", load_stat.MODIFIER_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteLoad_Stat(string id)
        {
            string sql = @"Delete from LOAD_STAT where VERSION_NO = @VERSION_NO";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@VERSION_NO", id);

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

        public LoadStatVO GetLoadStatInfo(string id)
        {
            string sql = @"select VERSION_NO, LINE_ID, EQP_ID, TARGET_DATE, SETUP, BUSY, IDLERUN, IDLE, PM, DOWN, MODIFIER, MODIFIER_DATE
                                    from LOAD_STAT where VERSION_NO=@VERSION_NO";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VERSION_NO", id);

                    cmd.Connection.Open();
                    List<LoadStatVO> list = Helper.DataReaderMapToList<LoadStatVO>(cmd.ExecuteReader());
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

        public List<LoadStatVO> SearchLoad_StatList(string lineID = "", string eqpID = "")
        {
            string sql = @"select VERSION_NO, LINE_ID, EQP_ID, TARGET_DATE, SETUP, BUSY, IDLERUN, IDLE, PM, DOWN, MODIFIER, MODIFIER_DATE
                                    from LOAD_STAT where 1=1 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (lineID != null && lineID.Trim().Length > 0)
                    {
                        sql += " and LINE_ID=@LINE_ID";
                        cmd.Parameters.AddWithValue("@LINE_ID", lineID);
                    }

                    if (eqpID != null && eqpID.Trim().Length > 0)
                    {
                        sql += " and EQP_ID=@EQP_ID";
                        cmd.Parameters.AddWithValue("@EQP_ID", eqpID);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    List<LoadStatVO> list = Helper.DataReaderMapToList<LoadStatVO>(cmd.ExecuteReader());
                    cmd.Connection.Close();

                    return list;
                }
            }

            catch (Exception err)
            {
                return null;
            }
        }

        public List<LoadStat> GetLoadStat()
        {
            string sql = @"select LINE_ID,EQP_GROUP, TARGET_DATE, ROUND(avg(BUSY),2) as BUSY from

(select LINE_ID, CASE WHEN SUBSTRING(EQP_ID,4,1) =1 THEN 'PRESS'

WHEN SUBSTRING(EQP_ID,4,1) =2 THEN 'PAINT'

WHEN SUBSTRING(EQP_ID,4,1) =3 THEN 'FINISH' END as EQP_GROUP, TARGET_DATE, BUSY from LOAD_STAT) a group by LINE_ID,EQP_GROUP,TARGET_DATE order by EQP_GROUP,TARGET_DATE";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    List<LoadStat> list = Helper.DataReaderMapToList<LoadStat>(cmd.ExecuteReader());
                    Dispose();
                    return list;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public DataTable GetLoadStatByStep(string dtFrom, string dtTo)
        {
            string sql = "SP_PivotLoadStat";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_StartDT", dtFrom);
                    cmd.Parameters.AddWithValue("@P_EndDT", dtTo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                    //return DataTableToJsonObj(dt);
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}