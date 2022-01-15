using MESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using MES_WEB_API.Models;

namespace MES_WEB_API.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: User

        [HttpPost]
        [Route("Check")]
        public IHttpActionResult CheckUser(UserVO user)
        {
            Message<UserVO> msg = new Message<UserVO>();

            UserDAC db = new UserDAC();
            UserVO u = db.CheckUser(user);

            if (u != null)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 로그인되었습니다.";
                msg.Data = u;
            }
            else
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "로그인에 실패하셨습니다.";
                msg.Data = null;
            }
            return Ok(msg);
        }


        [HttpPost]
        [Route("CheckID")]
        public IHttpActionResult CheckID(UserVO user)
        {
            Message msg = new Message();

            UserDAC db = new UserDAC();
            int checkID = db.CheckID(user.Email);

            if (checkID ==0)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "아이디를 사용할 수 있습니다.";
            }
            else
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "아이디가 존재합니다.";
            }
            return Ok(msg);
        }

        //https://localhost:44332/api/User/Users
        [HttpGet]
        [Route("Users")]
        public List<UserVO> GetAllUser()
        {
            UserDAC db = new UserDAC();
            return db.GetUserList();
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult CreateUser(UserVO user)
        {
            Message msg = new Message();

            UserDAC db = new UserDAC();
            bool result = db.CreateUser(user);

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

        //https://localhost:44332/api/User/DelUser/{id}
        [HttpGet]
        [Route("DelUser/{ID}")]
        public IHttpActionResult DeleteUser(string ID)
        {
            Message msg = new Message();

            UserDAC db = new UserDAC();
            bool result = db.DeleteUser(ID);

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

        //https://localhost:44332/api/User/UpdateUser
        [HttpPost]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser(UserVO com)
        {
            Message msg = new Message();

            UserDAC db = new UserDAC();
            bool result = db.UpdateUser(com);

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