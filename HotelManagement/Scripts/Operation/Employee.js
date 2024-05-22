// A $( document ).ready() block.
$(document).ready(function () {
    $("#HoteL_Management_Employee_Management").DataTable();

    LoadEmployeeResercation();

    $("#Hotel_Employee_Management_Model_close").click(function () {
        $("#Hotel_Employee_Management_Model").hide();
    });
     $("#Hotel_Employee_Management_Model_EDIT_Submit").click(function () {
        UpdateEmployeeManagement();
     });
       $("#EDIT_Hotel_Employee_Management").click(function () {
           
           $("#Hotel_Employee_Management_Model_EDIT_DIV").hide();
     });
    $("#Delete_Hotel_Employee_Management").click(function () {
        DeleteManagement();
     });
    
});

function LoadEmployeeResercation()
{
 $.ajax({
        url: "../Operation/GetEmployeeManagementList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        BindEmployeeManagementList(data);

    });
}

function BindEmployeeManagementList(data) {
    $("#HoteL_Management_Employee_Management").DataTable({
        data: data,
        destroy: true,
        "aaSorting": [],
        columns: [
            {
                'data': 'First_Name', 'width': '15%',
                'render': function (First_Name, type, full, meta) {
                    return First_Name;
                }
            },
            {
                'data': 'Surname', 'width': '15%',
                'render': function (Surname, type, full, meta) {
                    return Surname;
                }
            },

            {
                'data': 'Designation', 'width': '15%',
                'render': function (Designation, type, full, meta) {
                    return Designation;
                }
            },
            {
                'data': 'Department', 'width': '15%',
                'render': function (Department, type, full, meta) {
                    return Department.Name;
                }
            },

            {
                'data': 'ID', 'width': '5%',
                'render': function (ID, type, full, meta) {
                    return '<a onclick=ViewEmployeeManagementDetails(' + ID + ') class="btn btn primary"><i class="fa fa-eye" style="color:#001D6E;"></i></a>';

                }
            },
        ]
    })
}

function ViewEmployeeManagementDetails(id) {


    var EmployeeReseravation = {
        ID: id,
    }

    $.ajax({
        url: "../Operation/GetEmployeeManagementByID",
        type: "POST",
        datatype: "json",
        data: EmployeeReseravation
    }).done(function (data) {

        $("#Hotel_Employee_Management_ID_Hidden").val(data.ID);
        $("#Hotel_Employee_Management_Model_Customer").html(data.Customer.First_Name);
        $("#Hotel_Employee_Management_Model_Employee").html(data.Employee.Employee_Title);
        $("#Hotel_Employee_Management_Model_Date").html(data.Date);
        $("#Hotel_Employee_Management_Model_Status").html(data.Status.Name);
        GetCustomerList();
        GetManagementStatusList();
        $("#Hotel_Employee_Management_Model").show();

    });





}


function GetCustomerList() {
    $.ajax({
        url: "../Operation/GetCustomerList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Employee_Management_Model_EDIT_Customer').empty();
        var Options = '<option value="">- Select customer -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].First_Name + ' ' + data[i].Surname + '</option>';
        }
        $('#Hotel_Employee_Management_Model_EDIT_Customer').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}

function GetManagementStatusList() {
    $.ajax({
        url: "../Operation/GetReseravationstatusList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Hotel_Employee_Management_Model_EDIT_Status').empty();
        var Options = '<option value="">- Select status -</option>';
        for (i = 0; i < data.length; i++) {
            Options += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
        }
        $('#Hotel_Employee_Management_Model_EDIT_Status').append(Options);
        //$('#SIMS_MULTIPLE_ADD_LECTURE_BRANCH').append(Options);

    });
}



function UpdateEmployeeManagement() {
     var ManagementID = $('#Hotel_Employee_Management_ID_Hidden').val()
     var customerID = $('#Hotel_Employee_Management_Model_EDIT_Customer').val()
     var statusID = $('#Hotel_Employee_Management_Model_EDIT_Status').val()

    var customer = {
        ID: customerID
    };
    var status = {
        ID: statusID
    };
    var Management = {
        ID: ManagementID,
        Customer: customer,
        Status:status

    };



    $.ajax({
        url: "../Operation/UpdateEmployeeManagementDetails",
        type: "POST",
        datatype: "json",
        data: Management
    }).done(function (data) {
        $("#Hotel_Employee_Management_Model_Customer").html(data.Customer.First_Name);
        $("#Hotel_Employee_Management_Model_Employee").html(data.Employee.Employee_Title);
        $("#Hotel_Employee_Management_Model_Date").html(data.Date);
        $("#Hotel_Employee_Management_Model_Status").html(data.Status.Name);
        $("#Hotel_Employee_Management_Model_EDIT_DIV").hide();
    });

}

function DeleteManagement() {
     var ManagementID = $('#Hotel_Employee_Management_ID_Hidden').val()



    var Management = {
        ID: ManagementID,


    };



    $.ajax({
        url: "../Operation/DeleteEmployeeManagementDetails",
        type: "POST",
        datatype: "json",
        data: Management
    }).done(function (data) {
        $("#Hotel_Employee_Management_Model").hide();
        LoadEmployeeResercation();
    });

}




function AddStaff()
{
 
     $('#Hotel_Employee_Add_Model').show();
    
}





function InsertStaff()
{
      
          
    var staffID = $('#Hotel_Employee_Model_Add_StaffID').val();
    var firstName = $('#Hotel_Employee_Model_Add_FName').val();
    var surname = $('#Hotel_Employee_Model_Add_SurName').val();
    var username = $('#Hotel_Employee_Model_Add_Username').val();
    var designation = $('#Hotel_Employee_Model_Add_Designation').val();
    var department = $('#Hotel_Hall_Reservation_Model_Add_Date').val();

    
    var Dep = {
        ID: department
    };
    var user = {
        StaffID: staffID,
        First_Name: firstName,
        Surname: Surname,
        Username: username,
        Designation: designation,
        Department:Dep

    };

    $.ajax({
        url: "../Operation/InsertEmployee",
        type: "POST",
        datatype: "json",
        data: user
    }).done(function (data) {

        
        $("#Hotel_Room_Reservation_Add_Model").hide();
        LoadRoomResercation();


    });
}