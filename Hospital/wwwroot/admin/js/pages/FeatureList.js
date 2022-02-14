$(document).ready(function () {

    $('#FeatureGrid').DataTable
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
                "url": "/Admin/FeatureList",
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "featureName"
                },
                {
                    "mData": "description"
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
                        if (data['isActive'] === false)
                            return '<a data-Id="' + data['id'] + '" data-Status="' + data['isActive'] +'" class="btn btn-info btn-sm activated" onclick="PlanActiveDeactive(this)">' + 'Activate' + '</a>';
                        if (data['isActive'] === true)
                            return '<a data-Id="' + data['id'] + '" data-Status="' + data['isActive'] +'" class="btn btn-info btn-sm decativate" onclick="PlanActiveDeactive(this)">' + 'Deactivate' + '</a>';
                    }
                },
                {   
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['encryptedID'] + '" class="btn btn-info btn-sm activated" onclick="EditFeature(this)">Edit</a>'; 
                    }
                }
                ,
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['encryptedID'] + '" class="btn btn-info btn-sm activated del_button" onclick="DeleteFeature(this)">Delete</a>';
                    }
                }
            ]
        });

});
var PlanActiveDeactive = function (obj) {
    var table = $('#FeatureGrid').DataTable();
    var rowIndex = $(obj).parent().parent().index();
    var id = $(obj).attr('data-Id');
    var status = false;
    if ($(obj).attr('data-Status') === "false") {
        status = true;
    }
    $.ajax({
        url: '/Features/FeatureActivateDecativate',
        type: 'POST',
        data: { id: id, status: status },
        dataType: 'json',
        success: function (data) {
            if (data !== null)
                table.row(rowIndex).data(data).draw();
        }
    });

};
var EditFeature = function (obj) {
    var id = $(obj).attr('data-Id');
    window.location.href = '/Features/EditFeature?id=' +  id;
}
var DeleteFeature = function (obj) {
    var id = $(obj).attr('data-Id');
    window.location.href = '/Features/DeleteFeature?id=' + id;
}
var convertUTCDateToLocalDate = function (date) {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
};