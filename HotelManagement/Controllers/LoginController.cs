using HotelManagement.Models.Business;
using HotelManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class LoginController : Controller
    {
        UserBL UBL = new UserBL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLoginCheck(User user)
        {
            try
            {
                
                User CheckedUser = new User();

                CheckedUser = UBL.UserLoginCheck(user);
                if (CheckedUser.Password == user.Password)
                {
                    if (CheckedUser.Username == user.Username)
                    {
                        Session["UserID"] = CheckedUser.ID;
                        Session["Staff_ID"] = CheckedUser.Staff_ID;
                        //Session["Image"] = CheckedUser.ImageName;
                        Session["FirstName"] = CheckedUser.First_Name;
                        Session["LastName"] = CheckedUser.Surname;
                        Session["Designation"] = CheckedUser.Designation;
                        TempData["Login_Message"] = "Login Success";
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        TempData["Login_Message"] = "";
                        TempData["Login_Message"] = "Login Failed";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["Login_Message"] = "";
                    TempData["Login_Message"] = "Login Failed";
                    return RedirectToAction("Index", "Home");
                }


            }
            catch (Exception ex)
            {
                var x = ex;
                TempData["Login_Message"] = "";
                TempData["Login_Message"] = "Login Failed";
                return RedirectToAction("Index", "Home");
            }

        }
    }
}