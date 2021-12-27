using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MES_WEB_API.Models;
using MESDTO;

namespace MES_WEB_API.Controllers
{
    [RoutePrefix("api/Setup")]
    public class SetupController : ApiController
    {
        //https://localhost:44322/api/Setup/Setups
        [Route("Setups")]
        public List<SetupVO> GetAllSetup()
        {
            SetupDAC db = new SetupDAC();
            return db.GetAllSetup();
        }

        [HttpPost]
        [Route("InsertSetup")]
        public IHttpActionResult InsertSetup(SetupVO setup)
        {
            Message msg = new Message();

            SetupDAC db = new SetupDAC();
            bool result = db.InsertSetup(setup);

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

        [HttpGet]
        [Route("DelSetup/{id}")]
        public IHttpActionResult DeleteSetup(string siteID)
        {
            Message msg = new Message();

            SetupDAC db = new SetupDAC();
            bool result = db.DeleteSetup(siteID);

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

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetSetupInfo(string siteID)
        {
            Message<SetupVO> msg = new Message<SetupVO>();

            SetupDAC db = new SetupDAC();
            SetupVO setup = db.GetSetupInfo(siteID);

            if (setup != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = setup;
            }
            else
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "해당하는 셋업정보가 없습니다.";
                msg.Data = null;
            }
            return Ok(msg);
        }
    }
}
