$(document).ready(function () {


   

    $('#UserGrid').DataTable
        ({
            dom: "<'row'<'col-sm-12 col-md-8'l><'col-sm-12 col-md-4'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            buttons: [
                'excel', 'print'
            ],
            "columnDefs": [
                {
                    "width": "5%",
                    "targets": [0]
                },
                {
                    "className": "text-center custom-middle-align",
                    "targets": [0, 1, 2, 3, 4, 5,6]
                }],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            initComplete: function () {
                $('<label>From <input type="date" class="form-control" id="startDate" onchange="filterRecord()"></label>').appendTo($("#UserGrid_wrapper").find("#UserGrid_length"));
                
                $('<label>To <input type="date" class="form-control" id="endDate" onchange="filterRecord()"></label>').appendTo($("#UserGrid_wrapper").find("#UserGrid_length"));
               
            },
            "ajax":
            {
                "url": "/Admin/UsersAll",
                "data": function (d) {
                    d.from = ($('#startDate').val() === null || $('#startDate').val() === undefined || $('#startDate').val().length===0 ? $('#hdnStartDate').val() : $('#startDate').val());
                    d.to = ($('#endDate').val() === null || $('#endDate').val() === undefined || $('#endDate').val().length === 0 ? $('#hdnEndDate').val() : $('#endDate').val());
                },
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "userName",
                    "mRender": function (data, type, full) {
                        return '<a href="javascript:;" onclick="GoToUserDetails(this)" data-UserID="' + full['id'] + '" data-Status="' + full['activateUSer'] + '">' + data + '</a>';
                    }
                },
                {
                    "mData": "firstName"
                },
                {
                    "mData": "lastName"
                },
                {
                    "mData": "phoneNumber"
                },
                
                {
                    "mData": "createdDate",
                    "render": function (data) {
                        var date = convertUTCDateToLocalDate(new Date(data));
                        var month = date.getMonth() + 1;
                        var day = date.getDate();
                        var hours = date.getHours();
                        var minutes = date.getMinutes();
                        return (month.toString().length > 1 ? month : "0" + month) + "/" + (day.toString().length > 1 ? day : "0" + day) + "/" + date.getFullYear() + " " + (hours.toString().length > 1 ? hours : "0" + hours) + ":" + (minutes.toString().length > 1 ? minutes : "0" + minutes);
                    }
                },
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        if (data['activateUSer'] === false)
                            return '<a data-UserID="' + data['id'] + '" data-Status="' + data['activateUSer'] + '" class="btn btn-info btn-sm decativate" onclick="ChangeUserActivateStatus(this)">' + 'Deactivate' + '</a>';
                        if (data['activateUSer'] === true)
                            return '<a data-UserID="' + data['id'] + '" data-Status="' + data['activateUSer'] + '" class="btn btn-info btn-sm activated" onclick="ChangeUserActivateStatus(this)">' + 'Activate' + '</a>';
                    }
                },
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-UserID="' + data['id'] + '" data-Status="' + data['activateUSer'] + '" class="btn btn-info btn-sm"  onclick="GoToUserSubsription(this)">' + 'View Subscription' + '</a>';
                    }
                }]
        });

    $(".alert-danger").show();
    setTimeout(function () {
        $(".alert-danger").hide(500);
    }, 5000);



});


var filterRecord = function () {
    var table = $('#UserGrid').DataTable();
    table.draw();
};
var ChangeUserActivateStatus = function (obj) {
    var table = $('#UserGrid').DataTable();
    var rowIndex = $(obj).parent().parent().index();
    var userid = $(obj).attr('data-UserID');
    var status = false;
    if ($(obj).attr('data-Status') === "false") {
        status = true;
    }
    $.ajax({
        url: '/Admin/ChangeUserStatus',
        type: 'POST',
        data: { userid: userid, status: status },
        dataType: 'json',
        success: function (data) {
            if (data !== null)
                table.row(rowIndex).data(data).draw();
        }
    });

};
var GoToUserDetails = function (obj) {
    var id = $(obj).attr("data-UserID");
    window.location.href = "/Admin/UserDetail?Id=" + id;
};
var GoToUserSubsription = function (obj) {
    var id = $(obj).attr("data-UserID");
    window.location.href = "/Admin/UserSubscription?Id=" + id;
};
var convertUTCDateToLocalDate = function (date) {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
};