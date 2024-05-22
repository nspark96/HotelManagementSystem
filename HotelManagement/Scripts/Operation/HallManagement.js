﻿// A $( document ).ready() block.
$(document).ready(function () {
    $("#HoteL_Management_Hall_Reservation").DataTable();

    LoadHallResercation();

    $("#Hotel_Hall_Reservation_Model_close").click(function () {
        $("#Hotel_Hall_Reservation_Model").hide();
    });
     $("#Hotel_Hall_Reservation_Model_EDIT_Submit").click(function () {
        UpdateHallReservation();
     });
       $("#EDIT_Hotel_Hall_Reservation").click(function () {
           
           $("#Hotel_Hall_Reservation_Model_EDIT_DIV").show();
     });
    $("#Delete_Hotel_Hall_Reservation").click(function () {
        DeleteReservation();
     });
       $("#Hotel_Hall_Reservation_Model_Add_Submit").click(function () {
           InsertHallReservation();
       });

    $("#Hotel_Hall_Reservation_Model_Add_close").click(function () {
           $("#Hotel_Hall_Reservation_Add_Model").hide();
     });
});

function LoadHallResercation()
{
 $.ajax({
        url: "../Operation/GetHallReservationList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        BindHallReservationList(data);

    });
}

function BindHallReservationList(data) {
    $("#HoteL_Management_Hall_Reservation").DataTable({
        data: data,
        destroy: true,
        "aaSorting": [],
        columns: [
            {
                'data': 'Hall', 'width': '15%',
                'render': function (Hall, type, full, meta) {
                    return Hall.Hall_Title;
                }
            },
            {
                'data': 'Customer', 'width': '15%',
                'render': function (Customer, type, full, meta) {
                    return Customer.First_Name;
                }
            },

            {
                'data': 'Date', 'width': '15%',
                'render': function (Date, type, full, meta) {
                    return Date;
                }
            },
            {
                'data': 'Status', 'width': '15%',
                'render': function (Status, type, full, meta) {
                    return Status.Name;
                }
            },

            {
                'data': 'ID', 'width': '5%',
                'render': function (ID, type, full, meta) {
                    return '<a onclick=ViewHallReservationDetails(' + ID + ') class="btn btn primary"><i class="fa fa-eye" style="color:#001D6E;"></i></a>';

                }
            },
        ]
    })
}

function ViewHallReservationDetails(id) {


    var HallReseravation = {
        ID: id,
    }

    $.ajax({
        url: "../Operation/GetHallReservationByID",
        type: "POST",
        datatype: "json",
        data: HallReseravation
    }).done(function (data) {

        $("#Hotel_Hall_Reservation_ID_Hidden").val(data.ID);
        $("#Hotel_Hall_Reservation_Model_Customer").html(data.Customer.First_Name);
        $("#Hotel_Hall_Reservation_Model_Hall").html(data.Hall.Hall_Title);
        $("#Hotel_Hall_Reservation_Model_Date").html(data.Date);
        $("#Hotel_Hall_Reservation_Model_Status").html(data.Status.Name);
        GetCustomerList();
        GetReservationStatusList();
        $("#Hotel_Hall_Reservation_Model").show();

    });





}


function GetCustomerList() {
    $.ajax({
        url: "../Operation/GetCustomerList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Hall_Reservation_Model_EDIT_Customer').empty();
        $('#Hotel_Hall_Reservation_Model_Add_Customer').empty();
        var Options = '<option value="">- Select customer -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].First_Name + ' ' + data[i].Surname + '</option>';
        }
        $('#Hotel_Hall_Reservation_Model_EDIT_Customer').append(Options);
        $('#Hotel_Hall_Reservation_Model_Add_Customer').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}

function GetReservationStatusList() {
    $.ajax({
        url: "../Operation/GetReseravationstatusList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Hall_Reservation_Model_EDIT_Status').empty();
        var Options = '<option value="">- Select status -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
        }
        $('#Hotel_Hall_Reservation_Model_EDIT_Status').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}



function UpdateHallReservation() {
     var reservationID = $('#Hotel_Hall_Reservation_ID_Hidden').val()
     var customerID = $('#Hotel_Hall_Reservation_Model_EDIT_Customer').val()
     var statusID = $('#Hotel_Hall_Reservation_Model_EDIT_Status').val()

    var customer = {
        ID: customerID
    };
    var status = {
        ID: statusID
    };
    var reservation = {
        ID: reservationID,
        Customer: customer,
        Status:status

    };



    $.ajax({
        url: "../Operation/UpdateHallReservationDetails",
        type: "POST",
        datatype: "json",
        data: reservation
    }).done(function (data) {
        $("#Hotel_Hall_Reservation_Model_Customer").html(data.Customer.First_Name);
        $("#Hotel_Hall_Reservation_Model_Hall").html(data.Hall.Hall_Title);
        $("#Hotel_Hall_Reservation_Model_Date").html(data.Date);
        $("#Hotel_Hall_Reservation_Model_Status").html(data.Status.Name);
        $("#Hotel_Hall_Reservation_Model_EDIT_DIV").hide();
    });

}

function DeleteReservation() {
     var reservationID = $('#Hotel_Hall_Reservation_ID_Hidden').val()



    var reservation = {
        ID: reservationID,


    };



    $.ajax({
        url: "../Operation/DeleteHallReservationDetails",
        type: "POST",
        datatype: "json",
        data: reservation
    }).done(function (data) {
        $("#Hotel_Hall_Reservation_Model").hide();
        LoadHallResercation();
    });

}


function Addreservation()
{
    GetHallList(); 
    GetCustomerList();
     $('#Hotel_Hall_Reservation_Add_Model').show();
    
}


function GetHallList() {
        $.ajax({
        url: "../Operation/GetHallList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Hall_Reservation_Model_Add_Hall').empty();
        var Options = '<option value="">- Select Hall -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].Hall_Title + '</option>';
        }
        $('#Hotel_Hall_Reservation_Model_Add_Hall').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}


function InsertHallReservation()
{
      
     var HallID = $('#Hotel_Hall_Reservation_Model_Add_Hall').val()
     var customerID = $('#Hotel_Hall_Reservation_Model_Add_Customer').val()
     var date = $('#Hotel_Hall_Reservation_Model_Add_Date').val()

    var customer = {
        ID: customerID
    };
    var Hall = {
        ID: HallID
    };
    var reservation = {
        Date: date,
        Customer: customer,
        Hall:Hall

    };

    $.ajax({
        url: "../Operation/InsertHallReservation",
        type: "POST",
        datatype: "json",
        data: reservation
    }).done(function (data) {

        
        $("#Hotel_Hall_Reservation_Add_Model").hide();
        LoadHallResercation();


    });
}