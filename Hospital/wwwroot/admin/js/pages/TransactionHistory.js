$(document).ready(function () {
    var sPageURL = window.location.search.substring(1);
    var param = sPageURL.split('&');
    var userId = param[0];
    //const URLparams = new URLSearchParams(Object.entries(params))
    //urlParams.toString()
    $('#TransactionHistoryGrid').DataTable
        ({
            "columnDefs": [
                {
                    "width": "5%",
                    "targets": [0]
                },
                {
                    "className": "text-center custom-middle-align",
                    "targets": [0, 1, 2, 3, 4]
                }],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "url": "/Admin/TransactionHistoryView",
                "type": "POST",
                "data": { 'UserId': userId },
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "transactionDate",
                    "render": function (data) {
                        var date = new Date(data);
                        var month = date.getMonth() + 1;
                        var day = date.getDate();
                        return (month.toString().length > 1 ? month : "0" + month) + "/" + (day.toString().length > 1 ? day : "0" + day) + "/" + date.getFullYear();
                    }
                },
                {
                    "mData": "transactionAmount"
                },
                {
                    "mData": "transactionStatus"
                },
                {
                    "mData": null,
                    "mRender": function (data, Type, full) {
                        return data["pricingPlansMaster"]["planName"];
                    }
                }
                ,
                //{
                //    "mData": "features"
                //},
                {
                    "mData": "dueDate",
                    "render": function (data) {
                        var date = new Date(data);
                        var month = date.getMonth() + 1;
                        var day = date.getDate();
                        return (month.toString().length > 1 ? month : "0" + month) + "/" + (day.toString().length > 1 ? day : "0" + day) + "/" + date.getFullYear();
                    }
                }]
        });

});