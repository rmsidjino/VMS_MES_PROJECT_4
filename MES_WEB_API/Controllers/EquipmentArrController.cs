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

    
    [RoutePrefix("api/EquipmentArr")]
        public class EquipmentArrController : ApiController
        {
        // GET: https://localhost:44332/api/EquipmentArr/EquipmentArrs
        [HttpGet]
            [Route("EquipmentArrs")]
            public List<EquipmentArrVO> GetAllEquipmentArr()
            {
                EquipmentArrDAC db = new EquipmentArrDAC();
                return db.GetAllEquipmentArr();
            }

        //Post : https://localhost:44332/api/EquipmentArr/InsertEquipmentArr
        [HttpPost]
            [Route("InsertEquipmentArr")]
            public IHttpActionResult InsertEquipment(EquipmentArrVO equipmentarr)
            {
                Message msg = new Message();

                EquipmentArrDAC db = new EquipmentArrDAC();
                bool result = db.InsertEquipmentArr(equipmentarr);

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
        //GET : https://localhost:44332/api/EquipmentArr/DelEquipmentArr/{id}
        [HttpGet]
            [Route("DelEquipmentArr/{id}")]
            public IHttpActionResult DelEquipmentArr(string id)
            {
                Message msg = new Message();

                EquipmentArrDAC db = new EquipmentArrDAC();
                bool result = db.DelEquipmentArr(id);

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


        
        //GET : https://localhost:44332/api/EquipmentArr/SearchEquipmentArr/{productID}/{processID}
        [HttpGet]
            [Route("SearchEquipmentArr/{productID}/{processID}")] 
            public IHttpActionResult SearchEquipmentArr(string productID = "", string processID = "")
            {
                productID = (productID) ?? "";
                processID = (processID) ?? "";
                Message<List<EquipmentArrVO>> msg = new Message<List<EquipmentArrVO>>();

                EquipmentArrDAC db = new EquipmentArrDAC();
                List<EquipmentArrVO> equipmentarr = db.SearchEquipmentArr(productID.Trim(), processID.Trim());

                if (equipmentarr != null)
                {
                    msg.IsSuccess = true;
                    msg.ResultMessage = "성공적으로 조회되었습니다.";
                    msg.Data = equipmentarr;
                }
                else
                {
                    msg.IsSuccess = false;
                    msg.ResultMessage = "해당하는 제품이 없습니다.";
                }
                return Ok(msg);
            }
        }
}