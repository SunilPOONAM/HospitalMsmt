$(document).ready(function () {

    $('#SubUserGrid').DataTable
        ({
            "columnDefs": [
                {
                    "width": "5%",
                    "targets": [0]
                },
                {
                    "className": "text-center custom-middle-align",
                    "targets": [0, 1, 2, 3]
                }],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "url": "/Admin/SubUsersAll",
                "type": "POST",
                "data": {Id:$("#UserID").val()},
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "userName",
                    "mRender": function (data, type, full) {
                        return '<a href="javascript:;" onclick="GoToUserDetails("' + data['id'] + '")" data-UserID="' + data['id'] + '" data-Status="' + data['activateUSer'] + '">' + data + '</a>';
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
                }]
        });

});
var convertUTCDateToLocalDate = function (date) {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
};