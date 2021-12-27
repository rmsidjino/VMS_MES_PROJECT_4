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
    }
}
