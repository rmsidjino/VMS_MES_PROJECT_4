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

        //Post : https://localhost:44332/api/Equipment/InsertEquipment
        [HttpPost]
        [Route("InsertEquipment")]
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
        //GET : https://localhost:44332/api/Equipment/DelEquipment/{id}
        [HttpGet]
        [Route("DelEquipment/{id}")]
        public IHttpActionResult DelEquipment(string id)
        {
            Message msg = new Message();

            EquipmentDAC db = new EquipmentDAC();
            bool result = db.DelEquipment(id);

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


        //api/Equipment/SearchEquipment/{cboLineID.SelectedItem}/{cboSiteID.SelectedItem}
        //GET : https://localhost:44332/api/Equipment/SearchEquipment/{siteID}/{lineID}
        [HttpGet]
        [Route("SearchEquipment/{siteID}/{lineID}")] //https://localhost:44332/api/Equipment/SearchEquipment/SITE01/LINE01
        public IHttpActionResult SearchEquipment(string siteID="", string lineID="")
        {
            lineID = (lineID) ?? "";
            siteID = (siteID) ?? "";
            Message<List<EquipmentVO>> msg = new Message<List<EquipmentVO>>();

            EquipmentDAC db = new EquipmentDAC();
            List<EquipmentVO> equipment = db.SearchEquipment(siteID.Trim(), lineID.Trim());

            if (equipment != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = equipment;
            }
            else
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "해당하는 제품이 없습니다.";
            }
            return Ok(msg);
        }
        //public IHttpActionResult SearchEquipment(string lineID, string siteID)
        //{
        //    Message<EquipmentVO> msg = new Message<EquipmentVO>();

        //    EquipmentDAC db = new EquipmentDAC();
        //    List<EquipmentVO> product = db.SearchEquipment(siteID, lineID);

        //    if (product != null)
        //    {
        //        msg.IsSuccess = true;
        //        msg.ResultMessage = "성공적으로 조회되었습니다.";
        //        //msg.Data = product();
        //    }
        //    else
        //    {
        //        msg.IsSuccess = true;
        //        msg.ResultMessage = "해당하는 제품이 없습니다.";
        //        msg.Data = null;
        //    }
        //    return Ok(msg);
        //}
    }
}