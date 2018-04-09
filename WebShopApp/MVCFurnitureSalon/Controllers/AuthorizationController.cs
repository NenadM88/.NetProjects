using MVCFurnitureSalon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCFurnitureSalon.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        static string path = @"~/Users.txt";

        //Login
        public ActionResult Login(Login user)
        {
            AllMethods allMet = new AllMethods();
            List<User> users = allMet.GetAllUser();

            foreach (var item in users)
            {
                //proverava username i password i na osnovu toga formira se cookie
                if (item.UserName.Equals(user.UserName) && item.Password.Equals(user.Password))
                {
                    var identity = new ClaimsIdentity(new[]{
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Surname, user.Password),
                            new Claim(ClaimTypes.Role, item.Role)
                        },
                    "21345678908765432");

                    var auth = Request.GetOwinContext();
                    var authManager = auth.Authentication;
                    authManager.SignIn(identity);
                    return RedirectToAction("Index", "Furniture");
                }
            }

            return View(user);
        }

        //Registration
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration regUser)
        {
            AllMethods allMet = new AllMethods();
            List<User> users = allMet.GetAllUser();

            if (users.Exists(x => x.UserName.Equals(regUser.UserName)))
            {
                return RedirectToAction("Login", "Authorization");
            }
            else
            {
                User user = new User();
                user.UserName = regUser.UserName;
                user.Password = regUser.Password;
                user.Name = regUser.Name;
                user.LastName = regUser.LastName;
                user.Role = regUser.Role;
                user.Number = regUser.Number;
                user.Email = regUser.Email;
                users.Add(user);
            }

            using (StreamWriter sw = new StreamWriter(Server.MapPath(path)))
            {
                foreach (var item in users)
                {
                    sw.WriteLine(item.UserName + "," + item.Password + "," + item.Name + "," + item.LastName + "," + item.Role + "," + item.Number + "," + item.Email);
                }
            }
            return RedirectToAction("Login", "Authorization");
        }

        //Logout
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("21345678908765432");
            return RedirectToAction("Login", "Authorization");
        }
    }
}