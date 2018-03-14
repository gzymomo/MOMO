using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOMO.APP;

namespace MOMO.Web.Controllers
{
    public class UserController : Controller
    {
        public UserService _userService;

        // GET: User
        public ActionResult Index()
        {
            var userlist = _userService.GetUserList();
            return View(userlist);
        }
 
    }
}