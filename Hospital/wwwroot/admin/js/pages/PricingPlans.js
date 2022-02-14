$(document).ready(function () {

    $('#PricingPlanGrid').DataTable
        ({
            "columnDefs": [
                {
                    "width": "5%",
                    "targets": [0]
                },
                {
                    "className": "text-center custom-middle-align",
                    "targets": [0, 1, 2, 3,4]
                }],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "url": "/Admin/PricingPlanList",
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [                
                {
                    "mData": "planName"
                },
                {
                    "mData": "frequencyName"
                },
                {
                    "mData": "amount"
                },
                {
                    "mData": "createdDate",
                    "render": function (data) {

                        var date = convertUTCDateToLocalDate(new Date(data));
                        var month = date.getMonth() + 1;
                        var day = date.getDate();
                        var hours = date.getHours();
                        var minutes = date.getMinutes();
                        return (month.toString().length > 1 ? month : "0" + month) + "/" + (day.toString().length > 1 ? day : "0" + day) + "/" + date.getFullYear() + " " + (hours.toString().length > 1 ? hours : "0" + hours) + ":" + (minutes.toString().length > 1 ? minutes : "0" + minutes) ;
                    }
                },                
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        if (data['isActive'] === false)
                            return '<a data-ID="' + data['id'] + '" data-Status="' + data['isActive'] + '" onclick="ChangePlanActivateStatus(this)" class="btn btn-info btn-sm activated">' + 'Activate' + '</a>';
                        if (data['isActive'] === true)
                            return '<a data-ID="' + data['id'] + '" data-Status="' + data['isActive'] + '" onclick="ChangePlanActivateStatus(this)" class="btn btn-info btn-sm decativate">' + 'Deactivate' + '</a>';
                    }
                },
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                       
                        return '<a href="/Admin/PlanFeatures?PlanId=' + data['encryptedID'] + '" class="btn btn-info btn-sm activated">' + 'View Features' + '</a> <a href="/Admin/EditPlan?PlanId=' + data['encryptedID'] + '" class="btn btn-info btn-sm activated">' + 'Edit' + '</a> <a href="/Admin/DeletePlan?id=' + data['encryptedID'] + '" class="btn btn-info btn-sm activated">' + 'Delete' + '</a>';
                    }
                }]
        });

});

var ChangePlanActivateStatus = function (obj) {
    var table = $('#PricingPlanGrid').DataTable();
    var rowIndex = $(obj).parent().parent().index();
    var PlanID = $(obj).attr('data-ID');
    var status = false;
    if ($(obj).attr('data-Status') === "false") {
        status = true;
    }
    $.ajax({
        url: '/Admin/ChangePlanStatus',
        type: 'POST',
        data: { id: PlanID, status: status },
        dataType: 'json',
        success: function (data) {
            if (data !== null)
                table.column(5).data(data).draw();
        }
    });

};

var convertUTCDateToLocalDate = function (date) {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
};