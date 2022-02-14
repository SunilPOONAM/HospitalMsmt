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
                    "targets": [0, 1, 2]
                }],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "url": "/Admin/PricingPlanFeatures",
                "data": { PlanId: $("#PlanId").val() },
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "feature"
                },
                {
                    "mData": "quantity"
                },                
                {
                    "mData": "createdDate",
                    "render": function (data) {
                        var date = new Date(data);
                        var month = date.getMonth() + 1;
                        var day = date.getDate();
                        return (month.toString().length > 1 ? month : "0" + month) + "/" + (day.toString().length > 1 ? day : "0" + day) + "/" + date.getFullYear();
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
    window.location.href = '/Features/EditFeature/' + id;
}
var DeleteFeature = function (obj) {
    var id = $(obj).attr('data-Id');
    window.location.href = '/Features/DeleteFeature/' + id;
}