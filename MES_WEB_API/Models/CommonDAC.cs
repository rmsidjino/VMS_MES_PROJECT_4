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
    public class CommonDAC
    {
        SqlConnection conn;

        public CommonDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<CommonVO> GetCodeList(string[] categories)
        {
            string category = string.Join("','", categories);

            //수정
            string sql = $@"select CCODE, CNAME, CCATEGORY 
from vw_codeList 
where category in ('{category}')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            List<CommonVO> list;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                list = Helper.DataReaderMapToList<CommonVO>(reader);
                //Helper.DataReaderMapToList()메서드를 실행하고
                //에러가 나지 않았는데, list = null로 경우

                while (reader.Read())
                {
                    CommonVO item = new CommonVO();
                    item.CCODE = reader["CCODE"].ToString();
                    item.CNAME = reader["CNAME"].ToString();
                    item.CCATEGORY = reader["CCATEGORY"].ToString();

                    list.Add(item);
                }
            }
            return list;
        }

        public List<CommonVO> GetCodeList(string category)
        {
            string sql = $@"select CCODE, CNAME, CCATEGORY from vw_codeList where CCATEGORY =@CCATEGORY";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CCATEGORY", category);
                    return Helper.DataReaderMapToList<CommonVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<CommonVO> GetCodeList()
        {
            string sql = $@"select CCODE, CNAME, CCATEGORY from vw_codeList";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<CommonVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<CommonVO> GetCommonList()
        {
            string sql = $@"select CCODE, CNAME, CCATEGORY from Common_Code";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<CommonVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool InsertCommon(CommonVO com)
        {
            string sql = @"insert into COMMON_CODE (CCODE,CNAME,CCATEGORY) values(@CCODE,@CNAME,@CCATEGORY)";

            try
            {

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@CCODE", com.CCODE);
                    cmd.Parameters.AddWithValue("@CNAME", com.CNAME);
                    cmd.Parameters.AddWithValue("@CCATEGORY", com.CCATEGORY);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteCommon(string ccode)
        {
            string sql = @"Delete from COMMON_CODE where CCODE = @CCODE ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@CCODE", ccode);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool UpdateCommon(CommonVO com)
        {
            string sql = "Update COMMON_CODE set CNAME=@CNAME, CCATEGORY=@CCATEGORY where CCODE=@CCODE";

            try
            {
                
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CCODE", com.CCODE);
                cmd.Parameters.AddWithValue("@CNAME", com.CNAME);
                cmd.Parameters.AddWithValue("@CCATEGORY", com.CCATEGORY);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}