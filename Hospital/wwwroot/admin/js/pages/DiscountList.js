$(document).ready(function () {


   

    $('#DiscountGrid').DataTable
        ({
            
          
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            
            "ajax":
            {
                "url": "/Admin/DiscountsList",                
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "from"                   
                },
                {
                    "mData": "to"
                },
                {
                    "mData": "discountPercent"
                } 
                 
                ,
                //{
                //    "mData": null,
                //    "mRender": function (data, type, full) {
                //        if (data['isActive'] === false)
                //            return '<a data-UserID="' + data['id'] + '" data-Status="' + data['isActive'] + '" class="btn btn-info btn-sm decativate" onclick="ChangeUserActivateStatus(this)">' + 'Deactivate' + '</a>';
                //        if (data['isActive'] === true)
                //            return '<a data-UserID="' + data['id'] + '" data-Status="' + data['isActive'] + '" class="btn btn-info btn-sm activated" onclick="ChangeUserActivateStatus(this)">' + 'Activate' + '</a>';
                //    }
                //},
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a href="/Admin/AddDiscount?id=' + escape(data['encryptedID']) + '" class="btn btn-info btn-sm"  >' + 'Edit' + '</a> <a href="/Admin/DeleteDiscount?id=' + escape(data['encryptedID'])  + '" class="btn btn-info btn-sm"  >' + 'Delete' + '</a>';
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