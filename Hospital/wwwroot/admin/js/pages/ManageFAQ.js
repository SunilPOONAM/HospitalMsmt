$(document).ready(function () {

    $('#FAQGrid').DataTable
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
                "url": "/Admin/GetFAQ",
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "question"
                },
                {
                    "mData": "answer"
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
                        return '<a data-Id="' + data['encryptedID'] + '" class="btn btn-info btn-sm activated" onclick="EditFAQ(this)">Edit</a>'; 
                    },
                }
                ,
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['encryptedID'] + '" class="btn btn-info btn-sm activated" onclick="DeleteFAQ(this)">Delete</a>';
                    }
                }
            ]
        });

});

var EditFAQ = function (obj) {
    var id = $(obj).attr('data-Id');
    window.location.href = '/FAQ/EditFAQ?id=' + id;
}
var DeleteFAQ = function (obj) {
    var id = $(obj).attr('data-Id');
    window.location.href = '/FAQ/DeleteFAQ?id=' + id;
};
var convertUTCDateToLocalDate = function (date) {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
};