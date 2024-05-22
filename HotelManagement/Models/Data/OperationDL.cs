using HotelManagement.Models.Model;
using NCHS_CRM.DataConnection;
using NLF_INTRANET.Comman.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Data
{
    public class OperationDL : DataAccessBase
    {

        public List<Room> GetRoomList(Room room)
        {

            try
            {
                Func<SqlCommand, List<Room>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<Room> RoomList = new List<Room>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Room = new Room
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),


                                Room_Title = rdr["Name"].ToString(),

                                Availability = rdr["Availability"].ToString(),


                            };
                            RoomList.Add(Room);
                        }
                    }

                    return RoomList;
                };
                return Data.SqlSpExecute("sp_GetRoomList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<Room> RoomList = new List<Room>();
                var Room = new Room
                {
                    ID = 0,

                };
                RoomList.Add(Room);
                return RoomList;
            }


        }


        public List<Hall> GetHallList(Hall hall)
        {

            try
            {
                Func<SqlCommand, List<Hall>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<Hall> HallList = new List<Hall>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Hall = new Hall
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),


                                Hall_Title = rdr["Name"].ToString(),
                                Availability = rdr["Availability"].ToString(),


                            };
                            HallList.Add(Hall);
                        }
                    }

                    return HallList;
                };
                return Data.SqlSpExecute("sp_GetHallList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<Hall> HallList = new List<Hall>();
                var Hall = new Hall
                {
                    ID = 0,

                };
                HallList.Add(Hall);
                return HallList;
            }


        }

        public List<FoodBeverages> GetFoodBeveragesnList(FoodBeverages foodBeverages)
        {

            try
            {
                Func<SqlCommand, List<FoodBeverages>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<FoodBeverages> FoodBeveragesList = new List<FoodBeverages>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var FoodBeverages = new FoodBeverages
                            {

                                ID = (rdr["TP_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["TP_ID"]),

                                Type = new Status
                                {
                                    ID = (rdr["Type_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Type_ID"]),
                                    Name = rdr["Type"].ToString(),


                                },

                                Name = rdr["Name"].ToString(),
                                Availability = rdr["Availability"].ToString(),


                            };
                            FoodBeveragesList.Add(FoodBeverages);
                        }
                    }

                    return FoodBeveragesList;
                };
                return Data.SqlSpExecute("sp_GetFoodBeveragesList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<FoodBeverages> FoodBeveragesList = new List<FoodBeverages>();
                var FoodBeverages = new FoodBeverages
                {
                    ID = 0,

                };
                FoodBeveragesList.Add(FoodBeverages);
                return FoodBeveragesList;
            }


        }
        //View
        public List<RoomReservation> GetRoomReservationList(RoomReservation roomReservation)
        {

            try
            {
                Func<SqlCommand, List<RoomReservation>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<RoomReservation> RoomReservationList = new List<RoomReservation>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var RoomReservation = new RoomReservation
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                                Customer = new Customer
                                {
                                    ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                    First_Name = rdr["First_Name"].ToString(),
                                    Surname = rdr["Surname"].ToString(),

                                },
                                Room = new Room
                                {
                                    ID = (rdr["Room_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Room_ID"]),
                                    Room_Title = rdr["Room_Title"].ToString(),


                                },
                                Status = new Status
                                {
                                    ID = (rdr["Status_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Status_ID"]),
                                    Name = rdr["Status"].ToString(),


                                },
                                Date = rdr["Date"].ToString(),
                                Availability = rdr["Availability"].ToString(),


                            };
                            RoomReservationList.Add(RoomReservation);
                        }
                    }

                    return RoomReservationList;
                };
                return Data.SqlSpExecute("sp_GetRoomReservationList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<RoomReservation> RoomReservationList = new List<RoomReservation>();
                var RoomReservation = new RoomReservation
                {
                    ID = 0,

                };
                RoomReservationList.Add(RoomReservation);
                return RoomReservationList;
            }


        }


        public List<HallBookings> GetHallReservationList(HallBookings hallBookings)
        {

            try
            {
                Func<SqlCommand, List<HallBookings>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<HallBookings> HallBookingsList = new List<HallBookings>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var HallBooking = new HallBookings
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                                Customer = new Customer
                                {
                                    ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                    First_Name = rdr["First_Name"].ToString(),
                                    Surname = rdr["Surname"].ToString(),

                                },
                                Hall = new Hall
                                {
                                    ID = (rdr["Hall_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Hall_ID"]),
                                    Hall_Title = rdr["Hall_Title"].ToString(),


                                },
                                Status = new Status
                                {
                                    ID = (rdr["Status_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Status_ID"]),
                                    Name = rdr["Status"].ToString(),


                                },
                                Date = rdr["Date"].ToString(),
                                Availability = rdr["Availability"].ToString(),


                            };
                            HallBookingsList.Add(HallBooking);
                        }
                    }

                    return HallBookingsList;
                };
                return Data.SqlSpExecute("sp_GetHallReservationList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<HallBookings> HallBookingsList = new List<HallBookings>();
                var HallBooking = new HallBookings
                {
                    ID = 0,

                };
                HallBookingsList.Add(HallBooking);
                return HallBookingsList;
            }


        }

        public List<FoodOrders> GetFoodOrdersList(FoodOrders foodOrders)
        {

            try
            {
                Func<SqlCommand, List<FoodOrders>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<FoodOrders> GetFoodOrdersList = new List<FoodOrders>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var FoodOrders = new FoodOrders
                            {

                                ID = (rdr["TP_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["TP_ID"]),
                                Customer = new Customer
                                {
                                    ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                    First_Name = rdr["First_Name"].ToString(),
                                    Surname = rdr["First_Name"].ToString(),

                                },
                                FoodBeverages = new FoodBeverages
                                {
                                    ID = (rdr["Hall_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Hall_ID"]),
                                    Name = rdr["Hall_Title"].ToString(),


                                },

                                Date = rdr["Date"].ToString(),
                                Availability = rdr["Item_Code"].ToString(),


                            };
                            GetFoodOrdersList.Add(FoodOrders);
                        }
                    }

                    return GetFoodOrdersList;
                };
                return Data.SqlSpExecute("sp_GetHallReservationList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<FoodOrders> GetFoodOrdersList = new List<FoodOrders>();
                var FoodOrders = new FoodOrders
                {
                    ID = 0,

                };
                GetFoodOrdersList.Add(FoodOrders);
                return GetFoodOrdersList;
            }


        }


        public RoomReservation GetRoomReservationByID(RoomReservation roomReservation)
        {
            Func<SqlCommand, RoomReservation> injector = cmd =>
            {
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = roomReservation.ID;
                RoomReservation pro = null;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pro = new RoomReservation
                        {
                            ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                            Customer = new Customer
                            {
                                ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),

                            },
                            Room = new Room
                            {
                                ID = (rdr["Room_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Room_ID"]),
                                Room_Title = rdr["Room_Title"].ToString(),


                            },
                            Status = new Status
                            {
                                ID = (rdr["Status_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Status_ID"]),
                                Name = rdr["Status"].ToString(),


                            },
                            Date = rdr["Date"].ToString(),
                            Availability = rdr["Availability"].ToString(),
                        };
                    }
                }

                return pro;
            };
            return Data.SqlSpExecute("sp_GetRoomReservationByID", injector);
        }
        public HallBookings GetHallReservationByID(HallBookings hallBookings)
        {
            Func<SqlCommand, HallBookings> injector = cmd =>
            {
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = hallBookings.ID;
                HallBookings pro = null;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pro = new HallBookings
                        {
                            ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                            Customer = new Customer
                            {
                                ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),

                            },
                            Hall = new Hall
                            {
                                ID = (rdr["Hall_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Hall_ID"]),
                                Hall_Title = rdr["Hall_Title"].ToString(),


                            },
                            Status = new Status
                            {
                                ID = (rdr["Status_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Status_ID"]),
                                Name = rdr["Status"].ToString(),


                            },
                            Date = rdr["Date"].ToString(),
                            Availability = rdr["Availability"].ToString(),
                        };
                    }
                }

                return pro;
            };
            return Data.SqlSpExecute("sp_GetHallReservationByID", injector);
        }

        public FoodOrders GetFoodOrdersByID(FoodOrders foodOrders)
        {
            Func<SqlCommand, FoodOrders> injector = cmd =>
            {
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = foodOrders.ID;
                FoodOrders pro = null;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pro = new FoodOrders
                        {
                            ID = (rdr["TP_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["TP_ID"]),
                            Customer = new Customer
                            {
                                ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["First_Name"].ToString(),

                            },
                            FoodBeverages = new FoodBeverages
                            {
                                ID = (rdr["FoodBeverages_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["FoodBeverages_ID"]),
                                Name = rdr["FoodBeverages_Name"].ToString(),


                            },

                            Date = rdr["Date"].ToString(),
                            Availability = rdr["Availability"].ToString(),
                        };
                    }
                }

                return pro;
            };
            return Data.SqlSpExecute("sp_GetFoodOrdersByID", injector);
        }


        public List<Customer> GetCustomerList(Customer customer)
        {

            try
            {
                Func<SqlCommand, List<Customer>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<Customer> CustomerList = new List<Customer>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var Customers = new Customer
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),


                            };
                            CustomerList.Add(Customers);
                        }
                    }

                    return CustomerList;
                };
                return Data.SqlSpExecute("sp_CustomerList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<Customer> CustomerList = new List<Customer>();
                var Customers = new Customer
                {
                    ID = 0,

                };
                CustomerList.Add(Customers);
                return CustomerList;
            }


        }

        public List<Status> GetReseravationstatusList(Status status)
        {

            try
            {
                Func<SqlCommand, List<Status>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<Status> StatusList = new List<Status>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var statuses = new Status
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                                Name = rdr["Status"].ToString(),



                            };
                            StatusList.Add(statuses);
                        }
                    }

                    return StatusList;
                };
                return Data.SqlSpExecute("sp_GetReseravationstatusList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<Status> StatusList = new List<Status>();
                var Statuses = new Status
                {
                    ID = 0,

                };
                StatusList.Add(Statuses);
                return StatusList;
            }


        }


        public RoomReservation UpdateRoomReservationDetails(RoomReservation roomReservation)
        {
            Func<SqlCommand, RoomReservation> injector = cmd =>
            {
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = roomReservation.ID;
                cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = roomReservation.Customer.ID;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = roomReservation.Status.ID;
                RoomReservation pro = null;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pro = new RoomReservation
                        {
                            ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                            Customer = new Customer
                            {
                                ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),

                            },
                            Room = new Room
                            {
                                ID = (rdr["Room_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Room_ID"]),
                                Room_Title = rdr["Room_Title"].ToString(),


                            },
                            Status = new Status
                            {
                                ID = (rdr["Status_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Status_ID"]),
                                Name = rdr["Status"].ToString(),


                            },
                            Date = rdr["Date"].ToString(),
                            Availability = rdr["Availability"].ToString(),
                        };
                    }
                }

                return pro;
            };
            return Data.SqlSpExecute("sp_UpdateRoomReservationDetails", injector);
        }



        public bool DeleteRoomReservationDetails(RoomReservation roomReservation)
        {
            bool isSuccess;
            try
            {
                Func<SqlCommand, bool> injector = cmd =>
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = roomReservation.ID;


                    cmd.ExecuteReader();

                    return true;
                };
                return Data.SqlSpExecute("sp_Delete_RoomReservation", injector);
            }
            catch (Exception e)
            {
                var x = e;
                isSuccess = false;
            }

            return isSuccess;

        }



        public HallBookings UpdateHallReservationDetails(HallBookings hallBookings)
        {
            Func<SqlCommand, HallBookings> injector = cmd =>
            {
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = hallBookings.ID;
                cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = hallBookings.Customer.ID;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = hallBookings.Status.ID;
                HallBookings pro = null;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        pro = new HallBookings
                        {
                            ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                            Customer = new Customer
                            {
                                ID = (rdr["Cus_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Cus_ID"]),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),

                            },
                            Hall = new Hall
                            {
                                ID = (rdr["Hall_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Hall_ID"]),
                                Hall_Title = rdr["Hall_Title"].ToString(),


                            },
                            Status = new Status
                            {
                                ID = (rdr["Status_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Status_ID"]),
                                Name = rdr["Status"].ToString(),


                            },
                            Date = rdr["Date"].ToString(),
                            Availability = rdr["Availability"].ToString(),
                        };
                    }
                }

                return pro;
            };
            return Data.SqlSpExecute("sp_UpdateHallReservationDetails", injector);
        }



        public bool DeleteHallReservationDetails(HallBookings hallBookings)
        {
            bool isSuccess;
            try
            {
                Func<SqlCommand, bool> injector = cmd =>
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = hallBookings.ID;


                    cmd.ExecuteReader();

                    return true;
                };
                return Data.SqlSpExecute("sp_Delete_HallReservation", injector);
            }
            catch (Exception e)
            {
                var x = e;
                isSuccess = false;
            }

            return isSuccess;

        }



        public List<FoodBeverages> GetFoodBeveragesList(FoodBeverages foodBeverages)
        {

            try
            {
                Func<SqlCommand, List<FoodBeverages>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<FoodBeverages> GetFoodBeveragesList = new List<FoodBeverages>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var foodBeverage = new FoodBeverages
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                                Name = rdr["FoodBeverages_Title"].ToString(),
                                Type = new Status
                                {

                                    ID = (rdr["Type_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Type_ID"]),
                                    Name = rdr["Type_Title"].ToString(),


                                },
                                Price = rdr["Price"].ToString(),
                                Availability = rdr["Availability"].ToString(),
                            };
                            GetFoodBeveragesList.Add(foodBeverage);
                        }
                    }

                    return GetFoodBeveragesList;
                };
                return Data.SqlSpExecute("sp_GetFoodBeveragesList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<FoodBeverages> GetFoodBeveragesList = new List<FoodBeverages>();
                var foodBeverage = new FoodBeverages
                {
                    ID = 0,

                };
                GetFoodBeveragesList.Add(foodBeverage);
                return GetFoodBeveragesList;
            }


        }


        public List<User> GetEmployeeManagementList(User user)
        {

            try
            {
                Func<SqlCommand, List<User>> injector = cmd =>
                {
                    //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


                    List<User> GetUserList = new List<User>();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var User = new User
                            {

                                ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
                                Staff_ID = rdr["Staff_ID"].ToString(),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),
                                Designation = rdr["Designation"].ToString(),
                                Department = new Status
                                {
                                    ID = (rdr["Dep_ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["Dep_ID"]),
                                    Name = rdr["Dep_Name"].ToString(),
                                },

                            };
                            GetUserList.Add(User);
                        }
                    }

                    return GetUserList;
                };
                return Data.SqlSpExecute("sp_GetEmployeeManagementList", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                List<User> GetUserList = new List<User>();
                var User = new User
                {
                    ID = 0,

                };
                GetUserList.Add(User);
                return GetUserList;
            }


        }




        public RoomReservation InsertRoomReservation(RoomReservation roomReservation)
        {
            try
            {
                Func<SqlCommand, RoomReservation> injector = cmd =>
                {
                    cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = roomReservation.Customer.ID;
                    cmd.Parameters.Add("@Room", SqlDbType.VarChar).Value = roomReservation.Room.ID;
                    cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = roomReservation.Date;
                    RoomReservation pro = null;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            pro = new RoomReservation
                            {

                                Room = new Room
                                {

                                    Room_Title = rdr["Room"].ToString(),


                                },

                            };
                        }
                    }

                    return pro;
                };
                return Data.SqlSpExecute("sp_InsertRoomReservation", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                RoomReservation pro = null;
                pro = new RoomReservation
                {

                    Room = new Room
                    {

                        Room_Title = "0",


                    },

                };
                return pro;
            }

        }

        public HallBookings InsertHallReservation(HallBookings hallBookings)
        {
            try
            {
                Func<SqlCommand, HallBookings> injector = cmd =>
                {
                    cmd.Parameters.Add("@Customer", SqlDbType.VarChar).Value = hallBookings.Customer.ID;
                    cmd.Parameters.Add("@Hall", SqlDbType.VarChar).Value = hallBookings.Hall.ID;
                    cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = hallBookings.Date;
                    HallBookings pro = null;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            pro = new HallBookings
                            {

                                Hall = new Hall
                                {

                                    Hall_Title = rdr["Room"].ToString(),


                                },

                            };
                        }
                    }

                    return pro;
                };
                return Data.SqlSpExecute("sp_InsertHallReservation", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                HallBookings pro = null;
                pro = new HallBookings
                {

                    Hall = new Hall
                    {

                        Hall_Title = "0",


                    },

                };
                return pro;
            }

        }


        public User InsertEmployee(User user)
        {
            try
            {
                Func<SqlCommand, User> injector = cmd =>
                {
                    cmd.Parameters.Add("@Staff_ID", SqlDbType.VarChar).Value = user.Staff_ID;
                    cmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = user.First_Name;
                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Cipher.AESEncrypt(user.Username);
                    cmd.Parameters.Add("@Designation", SqlDbType.VarChar).Value = user.Designation;
                    cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = user.Department.ID;
                    User pro = null;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            pro = new User
                            {



                                Staff_ID = rdr["Staff_ID"].ToString(),



                            };
                        }
                    }

                    return pro;
                };
                return Data.SqlSpExecute("sp_InsertEmployee", injector);
            }
            catch (Exception ex)
            {
                var x = ex;
                User pro = null;
                pro = new User
                {



                    ID = 0,




                };
                return pro;
            }

        }

        //public List<Room> GetRoomList(Room room)
        //{

        //    try
        //    {
        //        Func<SqlCommand, List<Room>> injector = cmd =>
        //        {
        //            //cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = MenuItems.Id;


        //            List<Room> RoomList = new List<Room>();
        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                while (rdr.Read())
        //                {
        //                    var Room = new Room
        //                    {

        //                        ID = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),
        //                        Room_Title = rdr["Room_Title"].ToString(),


        //                    };
        //                    RoomList.Add(Room);
        //                }
        //            }

        //            return RoomList;
        //        };
        //        return Data.SqlSpExecute("sp_GetRoomList", injector);
        //    }
        //    catch (Exception ex)
        //    {
        //        var x = ex;
        //        List<Room> RoomList = new List<Room>();
        //        var Room = new Room
        //        {
        //            ID = 0,

        //        };
        //        RoomList.Add(Room);
        //        return RoomList;
        //    }


        //}
        ////Create
        //public MenuItems Create_Menu_Items(MenuItems MenuItems)
        //{
        //    try
        //    {
        //        Func<SqlCommand, MenuItems> injector = cmd =>
        //        {
        //            cmd.Parameters.Add("@Item_Name", SqlDbType.VarChar).Value = MenuItems.Item_Name;
        //            cmd.Parameters.Add("@Item_Code", SqlDbType.VarChar).Value = MenuItems.Item_Code;

        //            MenuItems InsertedMenuItems = null;
        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                while (rdr.Read())
        //                {
        //                    InsertedMenuItems = new MenuItems
        //                    {
        //                        Id = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),


        //                    };
        //                }
        //            }

        //            return InsertedMenuItems;
        //        };
        //        return Data.SqlSpExecute("sp_Create_Main_Items", injector);
        //    }
        //    catch (Exception ex)
        //    {
        //        var x = ex;
        //        MenuItems InsertedMenuItems = null;
        //        InsertedMenuItems = new MenuItems
        //        {

        //            Error = new CommanType
        //            {
        //                ID = 2,
        //                Name = x.ToString(),
        //            },
        //        };
        //        return InsertedMenuItems;
        //    }

        //}


        ////Update
        //public MenuItems Update_Menu_Items(MenuItems MenuItems)
        //{
        //    try
        //    {
        //        Func<SqlCommand, MenuItems> injector = cmd =>
        //        {
        //            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = MenuItems.Id;
        //            cmd.Parameters.Add("@Item_Name", SqlDbType.VarChar).Value = MenuItems.Item_Name;
        //            cmd.Parameters.Add("@Item_Code", SqlDbType.VarChar).Value = MenuItems.Item_Code;

        //            MenuItems InsertedMenuItems = null;
        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                while (rdr.Read())
        //                {
        //                    InsertedMenuItems = new MenuItems
        //                    {
        //                        Id = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),


        //                    };
        //                }
        //            }

        //            return InsertedMenuItems;
        //        };
        //        return Data.SqlSpExecute("sp_Update_Menu_Items", injector);
        //    }
        //    catch (Exception ex)
        //    {
        //        var x = ex;
        //        MenuItems InsertedMenuItems = null;
        //        InsertedMenuItems = new MenuItems
        //        {

        //            Error = new CommanType
        //            {
        //                ID = 2,
        //                Name = x.ToString(),
        //            },
        //        };
        //        return InsertedMenuItems;
        //    }

        //}

        ////Delete
        //public MenuItems Delete_Menu_Items(MenuItems MenuItems)
        //{
        //    try
        //    {
        //        Func<SqlCommand, MenuItems> injector = cmd =>
        //        {
        //            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = MenuItems.Id;

        //            MenuItems InsertedMenuItems = null;
        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                while (rdr.Read())
        //                {
        //                    InsertedMenuItems = new MenuItems
        //                    {
        //                        Id = (rdr["ID"]) == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID"]),


        //                    };
        //                }
        //            }

        //            return InsertedMenuItems;
        //        };
        //        return Data.SqlSpExecute("sp_Delete_Menu_Items", injector);
        //    }
        //    catch (Exception ex)
        //    {
        //        var x = ex;
        //        MenuItems InsertedMenuItems = null;
        //        InsertedMenuItems = new MenuItems
        //        {

        //            Error = new CommanType
        //            {
        //                ID = 2,
        //                Name = x.ToString(),
        //            },
        //        };
        //        return InsertedMenuItems;
        //    }

        //}
    }
}