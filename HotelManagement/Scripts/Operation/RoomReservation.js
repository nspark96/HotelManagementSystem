// A $( document ).ready() block.
$(document).ready(function () {
    $("#HoteL_Management_Room_Reservation").DataTable();

    LoadRoomResercation();

    $("#Hotel_Room_Reservation_Model_close").click(function () {
        $("#Hotel_Room_Reservation_Model").hide();
    });
     $("#Hotel_Room_Reservation_Model_EDIT_Submit").click(function () {
        UpdateRoomReservation();
     });
       $("#EDIT_Hotel_Room_Reservation").click(function () {
           
           $("#Hotel_Room_Reservation_Model_EDIT_DIV").hide();
     });
    $("#Delete_Hotel_Room_Reservation").click(function () {
        DeleteReservation();
    });
    $("#Hotel_Room_Reservation_Model_Add_Submit").click(function () {
           InsertRoomReservation();
     });
  $("#Hotel_Room_Reservation_Model_Add_close").click(function () {
           $("#Hotel_Room_Reservation_Add_Model").hide();
     });
});

function LoadRoomResercation()
{
 $.ajax({
        url: "../Operation/GetRoomReservationList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        BindRoomReservationList(data);

    });
}

function BindRoomReservationList(data) {
    $("#HoteL_Management_Room_Reservation").DataTable({
        data: data,
        destroy: true,
        "aaSorting": [],
        columns: [
            {
                'data': 'Room', 'width': '15%',
                'render': function (Room, type, full, meta) {
                    return Room.Room_Title;
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
                    return '<a onclick=ViewRoomReservationDetails(' + ID + ') class="btn btn primary"><i class="fa fa-eye" style="color:#001D6E;"></i></a>';

                }
            },
        ]
    })
}

function ViewRoomReservationDetails(id) {


    var roomReseravation = {
        ID: id,
    }

    $.ajax({
        url: "../Operation/GetRoomReservationByID",
        type: "POST",
        datatype: "json",
        data: roomReseravation
    }).done(function (data) {

        $("#Hotel_Room_Reservation_ID_Hidden").val(data.ID);
        $("#Hotel_Room_Reservation_Model_Customer").html(data.Customer.First_Name);
        $("#Hotel_Room_Reservation_Model_Room").html(data.Room.Room_Title);
        $("#Hotel_Room_Reservation_Model_Date").html(data.Date);
        $("#Hotel_Room_Reservation_Model_Status").html(data.Status.Name);
        GetCustomerList();
        GetReservationStatusList();
        $("#Hotel_Room_Reservation_Model").show();

    });





}


function GetCustomerList() {
    $.ajax({
        url: "../Operation/GetCustomerList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Room_Reservation_Model_EDIT_Customer').empty();
        $('#Hotel_Room_Reservation_Model_Add_Customer').empty();
        var Options = '<option value="">- Select customer -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].First_Name + ' ' + data[i].Surname + '</option>';
        }
        $('#Hotel_Room_Reservation_Model_EDIT_Customer').append(Options);
        $('#Hotel_Room_Reservation_Model_Add_Customer').append(Options);
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
        $('#Hotel_Room_Reservation_Model_EDIT_Status').empty();
        var Options = '<option value="">- Select status -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
        }
        $('#Hotel_Room_Reservation_Model_EDIT_Status').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}








function UpdateRoomReservation() {
     var reservationID = $('#Hotel_Room_Reservation_ID_Hidden').val()
     var customerID = $('#Hotel_Room_Reservation_Model_EDIT_Customer').val()
     var statusID = $('#Hotel_Room_Reservation_Model_EDIT_Status').val()

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
        url: "../Operation/UpdateRoomReservationDetails",
        type: "POST",
        datatype: "json",
        data: reservation
    }).done(function (data) {
        $("#Hotel_Room_Reservation_Model_Customer").html(data.Customer.First_Name);
        $("#Hotel_Room_Reservation_Model_Room").html(data.Room.Room_Title);
        $("#Hotel_Room_Reservation_Model_Date").html(data.Date);
        $("#Hotel_Room_Reservation_Model_Status").html(data.Status.Name);
        $("#Hotel_Room_Reservation_Model_EDIT_DIV").hide();
    });

}

function DeleteReservation() {
     var reservationID = $('#Hotel_Room_Reservation_ID_Hidden').val()



    var reservation = {
        ID: reservationID,


    };



    $.ajax({
        url: "../Operation/DeleteRoomReservationDetails",
        type: "POST",
        datatype: "json",
        data: reservation
    }).done(function (data) {
        $("#Hotel_Room_Reservation_Model").hide();
        LoadRoomResercation();
    });

}



function Addreservation()
{
    GetRoomList(); 
    GetCustomerList();
     $('#Hotel_Room_Reservation_Add_Model').show();
    
}


function GetRoomList() {
        $.ajax({
        url: "../Operation/GetRoomList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Room_Reservation_Model_Add_Room').empty();
        var Options = '<option value="">- Select room -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].Room_Title + '</option>';
        }
        $('#Hotel_Room_Reservation_Model_Add_Room').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}


function InsertRoomReservation()
{
      
     var roomID = $('#Hotel_Room_Reservation_Model_Add_Room').val()
     var customerID = $('#Hotel_Room_Reservation_Model_Add_Customer').val()
     var date = $('#Hotel_Room_Reservation_Model_Add_Date').val()

    var customer = {
        ID: customerID
    };
    var room = {
        ID: roomID
    };
    var reservation = {
        Date: date,
        Customer: customer,
        Room:room

    };

    $.ajax({
        url: "../Operation/InsertRoomReservation",
        type: "POST",
        datatype: "json",
        data: reservation
    }).done(function (data) {

        
        $("#Hotel_Room_Reservation_Add_Model").hide();
        LoadRoomResercation();


    });
}