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
    }
}