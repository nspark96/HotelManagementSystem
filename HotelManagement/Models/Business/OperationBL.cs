using HotelManagement.Models.Data;
using HotelManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Business
{
    public class OperationBL
    {
        private OperationDL operationDL = new OperationDL();
        public List<RoomReservation> GetRoomReservationList(RoomReservation roomReservation)
        {
            return operationDL.GetRoomReservationList(roomReservation);
        }
        public List<HallBookings> GetHallReservationList(HallBookings hallBookings)
        {
            return operationDL.GetHallReservationList(hallBookings);
        }
        public List<FoodOrders> GetFoodOrdersList(FoodOrders foodOrders)
        {
            return operationDL.GetFoodOrdersList(foodOrders);
        }
        public RoomReservation GetRoomReservationByID(RoomReservation roomReservation)
        {
            return operationDL.GetRoomReservationByID(roomReservation);
        }

        public HallBookings GetHallReservationByID(HallBookings hallBookings)
        {
            return operationDL.GetHallReservationByID(hallBookings);
        }
        public FoodOrders GetFoodOrdersByID(FoodOrders foodOrders)
        {
            return operationDL.GetFoodOrdersByID(foodOrders);
        }
        public List<Customer> GetCustomerList(Customer customer)
        {
            return operationDL.GetCustomerList(customer);
        }
        public List<Status> GetReseravationstatusList(Status status)
        {
            return operationDL.GetReseravationstatusList(status);
        }
        public RoomReservation UpdateRoomReservationDetails(RoomReservation roomReservation)
        {
            return operationDL.UpdateRoomReservationDetails(roomReservation);
        }
        public bool DeleteRoomReservationDetails(RoomReservation roomReservation)
        {
            return operationDL.DeleteRoomReservationDetails(roomReservation);
        }
        public HallBookings UpdateHallReservationDetails(HallBookings hallBookings)
        {
            return operationDL.UpdateHallReservationDetails(hallBookings);
        }
        public bool DeleteHallReservationDetails(HallBookings hallBookings)
        {
            return operationDL.DeleteHallReservationDetails(hallBookings);
        }


        public List<FoodBeverages> GetFoodBeveragesList(FoodBeverages foodBeverages)
        {
            return operationDL.GetFoodBeveragesList(foodBeverages);
        }
        public List<User> GetEmployeeManagementList(User user)
        {
            return operationDL.GetEmployeeManagementList(user);
        }
        public List<Room> GetRoomList(Room room)
        {
            return operationDL.GetRoomList(room);
        }
        public RoomReservation InsertRoomReservation(RoomReservation roomReservation)
        {
            return operationDL.InsertRoomReservation(roomReservation);
        }
        public List<Hall> GetHallList(Hall hall)
        {
            return operationDL.GetHallList(hall);
        }
        public HallBookings InsertHallReservation(HallBookings hallBookings)
        {
            return operationDL.InsertHallReservation(hallBookings);
        }
        public User InsertEmployee(User user)
        {
            return operationDL.InsertEmployee(user);
        }
        
    }
}