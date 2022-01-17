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
    [RoutePrefix("api/Std_step_info")]
    public class StdStepInfoController : ApiController
    {
        //GET : https://localhost:44332/api/Std_step_info/Std_step_infos
        [HttpGet]
        [Route("Std_step_infos")]
        public List<StdStepInfoVO> GetAllStd_step_info()
        {
            StdStepInfoDAC db = new StdStepInfoDAC();
            return db.GetAllStd_step_info();
        }

        //Post : https://localhost:44332/api/Std_step_info/InsertStd_step_info
        [HttpPost]
        [Route("InsertStd_step_info")]
        public IHttpActionResult InsertStd_step_info(StdStepInfoVO std_step_info)
        {
            Message msg = new Message();

            StdStepInfoDAC db = new StdStepInfoDAC();
            bool result = db.InsertStd_step_info(std_step_info);

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

        //GET : https://localhost:44332/api/Std_step_info/SearchStdStepInfoList?std_step_ID={std_step_ID}
        [HttpGet]
        [Route("SearchStdStepInfoList")]
        public List<StdStepInfoVO> SearchStdStepInfoList(string std_step_ID = "")
        {
            StdStepInfoDAC db = new StdStepInfoDAC();
            return db.SearchStdStepInfoList(std_step_ID);
        }

        //GET : https://localhost:44332/api/Std_step_info/DeleteStd_step_info/{id}
        [HttpGet]
        [Route("DeleteStd_step_info/{id}")]
        public IHttpActionResult DeleteStd_step_info(string id)
        {
            Message msg = new Message();

            StdStepInfoDAC db = new StdStepInfoDAC();
            bool result = db.DeleteStd_step_info(id);

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

        //GET : https://localhost:44332/api/Std_step_info/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetStd_step_infoInfo(string id)
        {
            Message<StdStepInfoVO> msg = new Message<StdStepInfoVO>();

            StdStepInfoDAC db = new StdStepInfoDAC();
            StdStepInfoVO std_step_info = db.GetStd_step_infoInfo(id);

            if (std_step_info != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = std_step_info;
            }
            else
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "해당하는 제품이 없습니다.";
                msg.Data = null;
            }
            return Ok(msg);
        }
        //GET : https://localhost:44332/api/Std_step_info/UpdateStd_step_info
        [HttpPost]
        [Route("UpdateStd_step_info")]
        public IHttpActionResult UpdateStd_step_info(StdStepInfoVO std_step_info)
        {
            Message msg = new Message();

            StdStepInfoDAC db = new StdStepInfoDAC();
            bool result = db.UpdateStd_step_info(std_step_info);

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
