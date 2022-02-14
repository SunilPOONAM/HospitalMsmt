$(document).ready(function () {
    dataTable();
});
var month = (new Date()).getMonth() + 1;
var year = (new Date()).getFullYear();
var dataTable = function () {
   
    $('#Report').DataTable
        ({
            dom: 'lfrtBp',
            buttons: [
                'excel', 'print'
            ],
            initComplete: function () {
                $('<label>Year<select id="year" class="form-control input-sm"></select></label>').appendTo($("#Report_wrapper").find("#Report_length")).on('change', function () {
                    getReport();
                });
                getYears();
                $('<label>Month<select id="month" class="form-control input-sm">' +
                    '<option value = "1" > January</option>' +
                    '<option value="2">February</option>' +
                    '<option value="3">March</option>' +
                    '<option value="4">April</option>' +
                    '<option value="5">May</option>' +
                    '<option value="6">June</option>' +
                    '<option value="7">July</option>' +
                    '<option value="8">August</option>' +
                    '<option value="9">September</option>' +
                    '<option value="10">October</option>' +
                    '<option value="11">November</option>' +
                    '<option value="12">December</option>' +
                    '</select></label>').appendTo($("#Report_wrapper").find("#Report_length")).on('change', function () {
                        getReport();
                    });
                $("#month").find('option[value=' + month.toString() + ']').attr('selected', 'selected');
            },
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
                "url": "/Admin/TransactionReport",
                "data": function (d) {
                    d.year = GetYear();
                    d.month = GetMonth();
                },
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": "date",
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
                    "mData": "totalSale"
                },
                {
                    "mData": "countUser"
                }]
        });
};


var GetMonth = function () {
    return month;
};

var GetYear = function () {
    return year;



};
var getYears = function () {
    var noofyears = 100; // Change to whatever you want
    var thisYear = (new Date()).getFullYear();
    for (var i = 0; i <= noofyears; i++) {
        var year = thisYear - i;
        $('<option>', { value: year, text: year }).appendTo("#year");
    }
};
var getReport = function () {
    var table = $('#Report').DataTable();
    month = $("#month").val();
    year = $("#year").val();
    table.ajax.reload();
};

var convertUTCDateToLocalDate = function (date) {
    return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
};