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
        //https://localhost:44332/api/Setup/Setups
        [HttpGet]
        [Route("Setups")]
        public List<SetupVO> GetAllSetup()
        {
            SetupDAC db = new SetupDAC();
            return db.GetAllSetup();
        }
        //https://localhost:44332/api/Setup/InsertSetup
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

        //https://localhost:44332/api/Setup/DelSetup/{id}
        [HttpGet]
        [Route("DelSetup/{id}")]
        public IHttpActionResult DeleteSetup(string id)
        {
            Message msg = new Message();

            SetupDAC db = new SetupDAC();
            bool result = db.DeleteSetup(id);

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

        //https://localhost:44332/api/Setup/SearchSetup/{siteID}/{stepID}
        [HttpGet]
        [Route("SearchSetup/{siteID}/{stepID}")]
        public IHttpActionResult GetSetupInfo(string siteID ="", string stepID = "") 
        {
            
            siteID = (siteID) ?? "";
            stepID = (stepID) ?? "";
            Message<List<SetupVO>> msg = new Message<List<SetupVO>>();

            SetupDAC db = new SetupDAC();
            List<SetupVO> setup = db.SearchSetup(siteID.Trim(), stepID.Trim());

            if (setup != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = setup;
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
