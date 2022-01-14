using MES_WEB_API.Models;
using MESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MES_WEB_API.Controllers
{
    [RoutePrefix("api/Common")]
    public class CommonController : ApiController
    {
        //https://localhost:44332/api/Common/{category}
        [HttpGet]
        [Route("{category}")]
        public List<CommonVO> GetCommonCode(string category)
        {
            CommonDAC db = new CommonDAC();
            return db.GetCodeList(category);
        }

        //https://localhost:44332/api/Common/All
        [HttpGet]
        [Route("All")]
        public List<CommonVO> GetCommonCode()
        {
            CommonDAC db = new CommonDAC();
            return db.GetCodeList();
        }

        //https://localhost:44332/api/Common/Commons
        [HttpGet]
        [Route("Commons")]
        public List<CommonVO> GetAllCommon()
        {
            CommonDAC db = new CommonDAC();
            return db.GetCommonList();
        }

        //https://localhost:44332/api/Common/InsertCommon
        [HttpPost]
        [Route("InsertCommon")]
        public IHttpActionResult InsertCommon(CommonVO com)
        {
            Message msg = new Message();

            CommonDAC db = new CommonDAC();
            bool result = db.InsertCommon(com);

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

        //https://localhost:44332/api/Common/DelCommon/{id}
        [HttpGet]
        [Route("DelCommon/{id}")]
        public IHttpActionResult DeleteCommon(string id)
        {
            Message msg = new Message();

            CommonDAC db = new CommonDAC();
            bool result = db.DeleteCommon(id);

            if (result)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 삭제되었습니다.";
            }
            else
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "삭제 중 오류가 발생했습니다.";
            }
            return Ok(msg);
        }

        //https://localhost:44332/api/Common/UpdateCommon
        [HttpPost]
        [Route("UpdateCommon")]
        public IHttpActionResult UpdateCommon(CommonVO com)
        {
            Message msg = new Message();

            CommonDAC db = new CommonDAC();
            bool result = db.UpdateCommon(com);

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
