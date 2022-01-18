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
    [RoutePrefix("api/LoadStat")]
    public class LoadStatController : ApiController
    {
        //GET : https://localhost:44332/api/Load_Stat/Load_Stats
        [HttpGet]
        [Route("Load_Stats")]
        public List<LoadStatVO> GetAllLoadStat()
        {
            LoadStatDAC db = new LoadStatDAC();
            return db.GetAllLoadStat();
        }

        //Post : https://localhost:44332/api/Load_Stat/InsertLoad_Stat
        [HttpPost]
        [Route("InsertLoad_Stat")]
        public IHttpActionResult InsertLoad_Stat(LoadStatVO load_stat)
        {
            Message msg = new Message();

            LoadStatDAC db = new LoadStatDAC();
            bool result = db.InsertLoad_Stat(load_stat);

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

        //GET : https://localhost:44332/api/Load_Stat/DeleteLoad_Stat/{id}
        [HttpGet]
        [Route("DeleteLoad_Stat/{id}")]
        public IHttpActionResult DeleteLoad_Stat(string id)
        {
            Message msg = new Message();

            LoadStatDAC db = new LoadStatDAC();
            bool result = db.DeleteLoad_Stat(id);

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


        //GET : https://localhost:44332/api/Load_Stat/SearchLoad_StatList?lineID={lineID}&eqpID={eqpID}
        [HttpGet]
        [Route("SearchLoad_StatList")]
        public List<LoadStatVO> SearchLoad_StatList(string lineID = "", string eqpID = "")
        {
            LoadStatDAC db = new LoadStatDAC();
            return db.SearchLoad_StatList(lineID, eqpID);
        }

        //GET : https://localhost:44332/api/Load_Stat/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetLoadStatInfo(string id)
        {
            Message<LoadStatVO> msg = new Message<LoadStatVO>();

            LoadStatDAC db = new LoadStatDAC();
            LoadStatVO load_stat = db.GetLoadStatInfo(id);

            if (load_stat != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 조회되었습니다.";
                msg.Data = load_stat;
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
