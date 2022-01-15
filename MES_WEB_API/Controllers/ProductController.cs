using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MESDTO;
using MES_WEB_API.Models;


namespace MES_WEB_API.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        //GET : https://localhost:44332/api/Product/Products
        [HttpGet]
        [Route("Products")]
        public List<ProductVO> GetAllProduct()
        {
            ProductDAC db = new ProductDAC();
            return db.GetAllProduct();
        }

        //Post : https://localhost:44332/api/Product/InsertProduct
        [HttpPost]
        [Route("InsertProduct")]
        public IHttpActionResult InsertProduct(ProductVO product)
        {
            Message msg = new Message();

            ProductDAC db = new ProductDAC();
            bool result = db.InsertProduct(product);

            if (result)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 등록되었습니다.";
            }
            else
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "등록 중 오류가 발생했습니다.";
            }
            return Ok(msg);
        }

        //GET : https://localhost:44332/api/Product/DeleteProduct/{id}
        [HttpGet]
        [Route("DeleteProduct/{id}")]
        public IHttpActionResult DeleteProduct(string id)
        {
            Message msg = new Message();

            ProductDAC db = new ProductDAC();
            bool result = db.DeleteProduct(id);

            if (result)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 삭제되었습니다.";
            }
            else
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "삭제 중 오류가 발생했습니다.";
            }
            return Ok(msg);
        }


        //GET : https://localhost:44332/api/Product/SearchProductList?productID={productID}&processID={processID}
        [HttpGet]
        [Route("SearchProductList")]
        public List<ProductVO> SearchProductList(string productID = "", string processID = "")
        {
            ProductDAC db = new ProductDAC();
            return db.SearchProductList(productID, processID);
        }

        //GET : https://localhost:44332/api/Product/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetProductInfo(string id)
        {
            Message<ProductVO> msg = new Message<ProductVO>();

            ProductDAC db = new ProductDAC();
            ProductVO product = db.GetProductInfo(id);

            if (product != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = product;
            }
            else
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "해당하는 제품이 없습니다.";
                msg.Data = null;
            }
            return Ok(msg);
        }

        //GET : https://localhost:44332/api/Product/UpdateProduct
        [HttpPost]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(ProductVO product)
        {
            Message msg = new Message();

            ProductDAC db = new ProductDAC();
            bool result = db.UpdateProduct(product);

            if (result)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 수정되었습니다.";
            }
            else
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "수정 중 오류가 발생했습니다.";
            }
            return Ok(msg);
        }
    }
}