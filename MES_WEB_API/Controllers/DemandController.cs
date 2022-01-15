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
    [RoutePrefix("api/Demand")]
    public class DemandController : ApiController
    {
        //GET : https://localhost:44332/api/Demand/Demands
        [HttpGet]
        [Route("Demands")]
        public List<DemandVO> GetAllDemand()
        {
            DemandDAC db = new DemandDAC();
            return db.GetAllDemand();
        }

        //Post : https://localhost:44332/api/Demand/InsertDemand
        [HttpPost]
        [Route("InsertDemand")]
        public IHttpActionResult InsertDemand(DemandVO demand)
        {
            Message msg = new Message();

            DemandDAC db = new DemandDAC();
            bool result = db.InsertDemand(demand);

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

        //GET : https://localhost:44332/api/Demand/DeleteDemand/{id}
        [HttpGet]
        [Route("DeleteDemand/{id}")]
        public IHttpActionResult DeleteDemand(string id)
        {
            Message msg = new Message();

            DemandDAC db = new DemandDAC();
            bool result = db.DeleteDemand(id);

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


        //GET : https://localhost:44332/api/Demand/SearchDemandList?demandVer={demandVer}&productID={productID}
        [HttpGet]
        [Route("SearchDemandList")]
        public List<DemandVO> SearchDemandList(string demand_ver = "", string productID = "")
        {
            DemandDAC db = new DemandDAC();
            return db.SearchDemandList(demand_ver, productID);
        }

        //GET : https://localhost:44332/api/Demand/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetDemandInfo(string id)
        {
            Message<DemandVO> msg = new Message<DemandVO>();

            DemandDAC db = new DemandDAC();
            DemandVO demand = db.GetDemandInfo(id);

            if (demand != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = demand;
            }
            else
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "해당하는 제품이 없습니다.";
                msg.Data = null;
            }
            return Ok(msg);
        }

        //GET : https://localhost:44332/api/Demand/UpdateDemand
        [HttpPost]
        [Route("UpdateDemand")]
        public IHttpActionResult UpdateDemand(DemandVO demand)
        {
            Message msg = new Message();

            DemandDAC db = new DemandDAC();
            bool result = db.UpdateDemand(demand);

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
