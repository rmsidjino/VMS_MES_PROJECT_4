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
    public class ProductDAC
    {
        //string conn = string.Empty;
        SqlConnection conn;

        public ProductDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public List<ProductVO> GetAllProduct()
        {
            string sql = @"select PRODUCT_ID, PRODUCT_TYPE, PRODUCT_NAME, PROCESS_ID, LOT_SIZE, INPUT_BATCH_SIZE, MODIFIER, MODIFIED_DATE 
from PRODUCT";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    return Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader()); ;
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool InsertProduct(ProductVO product)
        {
            string sql = @"insert into [PRODUCT] (PRODUCT_ID, PRODUCT_TYPE, PRODUCT_NAME, PROCESS_ID, LOT_SIZE, INPUT_BATCH_SIZE, MODIFIER, MODIFIED_DATE)
values(@PRODUCT_ID, @PRODUCT_TYPE, @PRODUCT_NAME, @PROCESS_ID, @LOT_SIZE, @INPUT_BATCH_SIZE, @MODIFIER, @MODIFIED_DATE)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@PRODUCT_ID", product.PRODUCT_ID);
                cmd.Parameters.AddWithValue("@PRODUCT_TYPE", product.PRODUCT_TYPE);
                cmd.Parameters.AddWithValue("@PRODUCT_NAME", product.PRODUCT_NAME);
                cmd.Parameters.AddWithValue("@PROCESS_ID", product.PROCESS_ID);
                cmd.Parameters.AddWithValue("@LOT_SIZE", product.LOT_SIZE);
                cmd.Parameters.AddWithValue("@INPUT_BATCH_SIZE", product.INPUT_BATCH_SIZE);
                cmd.Parameters.AddWithValue("@MODIFIER", product.MODIFIER);
                cmd.Parameters.AddWithValue("@MODIFIED_DATE", product.MODIFIED_DATE);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool DeleteProduct(string productID)
        {
            string sql = @"Delete from PRODUCT where PRODUCT_ID = @PRODUCT_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@PRODUCT_ID", productID);

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

        public ProductVO GetProductInfo(string productID)
        {
            string sql = @"select PRODUCT_ID, PRODUCT_TYPE, PRODUCT_NAME, PROCESS_ID, LOT_SIZE, INPUT_BATCH_SIZE, MODIFIER, MODIFIED_DATE
                                    from PRODUCT where PRODUCT_ID=@PRODUCT_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PRODUCT_ID", productID);

                    cmd.Connection.Open();
                    List<ProductVO> list = Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
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