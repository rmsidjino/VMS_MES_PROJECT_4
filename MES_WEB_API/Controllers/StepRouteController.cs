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
    [RoutePrefix("api/StepRoute")]
    public class StepRouteController : ApiController
    {
        //GET : https://localhost:44332/api/StepRoute/StepRoutes
        [HttpGet]
        [Route("StepRoutes")]
        public List<StepRouteVO> GetAllStepRoute()
        {
            StepRouteDAC db = new StepRouteDAC();
            return db.GetAllStepRoute();
        }

        //Post : https://localhost:44332/api/StepRoute/InsertStepRoute
        [HttpPost]
        [Route("InsertStepRoute")]
        public IHttpActionResult InsertStepRoute(StepRouteVO step_route)
        {
            Message msg = new Message();

            StepRouteDAC db = new StepRouteDAC();
            bool result = db.InsertStepRoute(step_route);

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

        //GET : https://localhost:44332/api/StepRoute/DeleteStepRoute/{id}
        [HttpGet]
        [Route("DeleteStepRoute/{id}")]
        public IHttpActionResult DeleteStepRoute(string id)
        {
            Message msg = new Message();

            StepRouteDAC db = new StepRouteDAC();
            bool result = db.DeleteStepRoute(id);

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


        //GET : https://localhost:44332/api/StepRoute/SearchStepRouteList?processID={processID}&stepID={stepID}
        [HttpGet]
        [Route("SearchStepRouteList")]
        public List<StepRouteVO> SearchStepRouteList(string processID = "", string stepID = "")
        {
            StepRouteDAC db = new StepRouteDAC();
            return db.SearchStepRouteList(processID, stepID);
        }

        //GET : https://localhost:44332/api/StepRoute/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetStepRouteInfo(string id)
        {
            Message<StepRouteVO> msg = new Message<StepRouteVO>();

            StepRouteDAC db = new StepRouteDAC();
            StepRouteVO step_route = db.GetStepRouteInfo(id);

            if (step_route != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = step_route;
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
