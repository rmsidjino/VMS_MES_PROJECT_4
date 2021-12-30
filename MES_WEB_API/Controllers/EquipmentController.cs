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
    [RoutePrefix("api/Equipment")]
    public class EquipmentController : ApiController
    {
        // GET: https://localhost:44332/api/Equipment/Equipments
        [HttpGet]
        [Route("Equipments")]
        public List<EquipmentVO> GetAllEquipment()
        {
            EquipmentDAC db = new EquipmentDAC();
            return db.GetAllEquipment();
        }

        //Post : https://localhost:44332/api/Equipment/InsertEquipment/{id}
        [HttpPost]
        [Route("InsertEquipment/{id}")]
        public IHttpActionResult InsertEquipment(EquipmentVO equipment)
        {
            Message msg = new Message();

            EquipmentDAC db = new EquipmentDAC();
            bool result = db.InsertEquipment(equipment);

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
        //GET : https://localhost:44332/api/Equipment/DeleteEquipment/{id}
        [HttpGet]
        [Route("DeleteEquipment/{id}")]
        public IHttpActionResult DeleteEquipment(string id)
        {
            Message msg = new Message();

            EquipmentDAC db = new EquipmentDAC();
            bool result = db.DeleteEquipment(id);

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
        //GET : https://localhost:44332/api/Equipment/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetEquipmentInfo(string id)
        {
            Message<EquipmentVO> msg = new Message<EquipmentVO>();

            EquipmentDAC db = new EquipmentDAC();
            EquipmentVO product = db.GetEquipmentInfo(id);

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

    }
}