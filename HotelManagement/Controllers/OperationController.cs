using HotelManagement.Models.Business;
using HotelManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class OperationController : Controller
    {

        private OperationBL operationBL = new OperationBL();
        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RoomReservation()
        {
            return View();
        }
        public ActionResult Hallmanagement()
        {
            return View();
        }
        public ActionResult InventoryManagement()
        {
            return View();
        }
        public ActionResult Restaurants()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        public JsonResult GetRoomReservationList(RoomReservation roomReservation)
        {
            return Json(operationBL.GetRoomReservationList(roomReservation));
        }
        public JsonResult GetHallReservationList(HallBookings hallBookings)
        {
            return Json(operationBL.GetHallReservationList(hallBookings));
        }
        public JsonResult GetFoodOrdersList(FoodOrders foodOrders)
        {
            return Json(operationBL.GetFoodOrdersList(foodOrders));
        }


        public JsonResult GetRoomReservationByID(RoomReservation roomReservation)
        {
            return Json(operationBL.GetRoomReservationByID(roomReservation));
        }
        public JsonResult GetHallReservationByID(HallBookings hallBookings)
        {
            return Json(operationBL.GetHallReservationByID(hallBookings));
        }
        public JsonResult GetCustomerList(Customer customer)
        {
            return Json(operationBL.GetCustomerList(customer));
        }

        public JsonResult GetReseravationstatusList(Status status)
        {
            return Json(operationBL.GetReseravationstatusList(status));
        }

        public JsonResult UpdateRoomReservationDetails(RoomReservation roomReservation)
        {
            return Json(operationBL.UpdateRoomReservationDetails(roomReservation));
        }
        public JsonResult DeleteRoomReservationDetails(RoomReservation roomReservation)
        {
            return Json(operationBL.DeleteRoomReservationDetails(roomReservation));
        }
        public JsonResult UpdateHallReservationDetails(HallBookings hallBookings)
        {
            return Json(operationBL.UpdateHallReservationDetails(hallBookings));
        }
        public JsonResult DeleteHallReservationDetails(HallBookings hallBookings)
        {
            return Json(operationBL.DeleteHallReservationDetails(hallBookings));
        }
        public JsonResult GetFoodBeveragesList(FoodBeverages foodBeverages)
        {
            return Json(operationBL.GetFoodBeveragesList(foodBeverages));
        }




        public JsonResult GetEmployeeManagementList(User user)
        {
            return Json(operationBL.GetEmployeeManagementList(user));
        }
        public JsonResult GetRoomList(Room room)
        {
            return Json(operationBL.GetRoomList(room));
        }
        public JsonResult GetHallList(Hall hall)
        {
            return Json(operationBL.GetHallList(hall));
        }
        public JsonResult InsertRoomReservation(RoomReservation roomReservation)
        {
            return Json(operationBL.InsertRoomReservation(roomReservation));
        }
        public JsonResult InsertHallReservation(HallBookings hallBookings)
        {
            return Json(operationBL.InsertHallReservation(hallBookings));
        }
        public JsonResult InsertEmployee(User user)
        {
            return Json(operationBL.InsertEmployee(user));
        }

        
        //public JsonResult GetMenuItemList(MenuItems menuitems)
        //{
        //    return Json(operationBL.GetMenuItemList(menuitems));
        //}
        //public JsonResult Create_Menu_Items(MenuItems menuitems)
        //{
        //    return Json(operationBL.Create_Menu_Items(menuitems));
        //}
        //public JsonResult Update_Menu_Items(MenuItems menuitems)
        //{
        //    return Json(operationBL.Update_Menu_Items(menuitems));
        //}
        //public JsonResult Delete_Menu_Items(MenuItems menuitems)
        //{
        //    return Json(operationBL.Delete_Menu_Items(menuitems));
        //}
    }
}