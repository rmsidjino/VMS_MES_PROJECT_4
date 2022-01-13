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
   

        [RoutePrefix("api/EquipmentPlan")]
        public class EquipmentPlanController : ApiController
        {
            // GET: https://localhost:44332/api/EquipmentPlan/EquipmentPlans
            [HttpGet]
            [Route("EquipmentPlans")]
            public List<Equipment_PlanVO> GetAllEquipmentPlan()
            {
                Equipment_PlanDAC db = new Equipment_PlanDAC();
                return db.GetAllEquipmentPlan();
            }

        //Post : https://localhost:44332/api/EquipmentPlan/InsertEquipmentPlan
        [HttpPost]
            [Route("InsertEquipmentPlan")]
            public IHttpActionResult InsertEquipmentPlan(Equipment_PlanVO equipmentplan)
            {
                Message msg = new Message();

                Equipment_PlanDAC db = new Equipment_PlanDAC();
                bool result = db.InsertEquipmentPlan(equipmentplan);

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
        //GET : https://localhost:44332/api/EquipmentPlan/DelEquipmentPlan/{id}
        [HttpGet]
            [Route("DelEquipmentPlan/{id}")]
            public IHttpActionResult DelEquipmentPlan(string id)
            {
                Message msg = new Message();

                Equipment_PlanDAC db = new Equipment_PlanDAC();
                bool result = db.DelEquipmentPlan(id);

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



        //GET : https://localhost:44332/api/EquipmentPlan/SearchEquipmentPlan/{productID}
        [HttpGet]
            [Route("SearchEquipmentPlan/{productID}")]
            public IHttpActionResult SearchEquipmentPlan(string productID = "")
            {
                productID = (productID) ?? "";
                
                Message<List<Equipment_PlanVO>> msg = new Message<List<Equipment_PlanVO>>();

                Equipment_PlanDAC db = new Equipment_PlanDAC();
                List<Equipment_PlanVO> equipmentplan = db.SearchEquipmentPlan(productID.Trim());

                if (equipmentplan != null)
                {
                    msg.IsSuccess = true;
                    msg.ResultMessage = "성공적으로 조회되었습니다.";
                    msg.Data = equipmentplan;
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
