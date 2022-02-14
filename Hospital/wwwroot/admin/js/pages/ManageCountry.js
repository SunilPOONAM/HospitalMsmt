$(document).ready(function () {
    var stateTable = $('#Tbl_CountryMaster').DataTable
        ({
            "columnDefs": [
                {
                    "width": "5%",
                    "targets": [0]
                },
                {
                    "className": "text-center custom-middle-align"
                }],
            "language":
            {
                "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
            },
            "processing": true,
            "serverSide": true,
            "ajax":
            {
                "url": "/Admin/CountryList",
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": null,
                    "render": function (row, type, full, index) {
                        return index.row + 1;
                    }
                },
                {
                    "mData": "countryName"
                }
                ,
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="btn btn-info btn-sm activated" href="UpdateCountry?Id=' + data['id'] + '"><i class="fa fa-pencil"></i></a> <a data-Id="' + data['id'] + '" data-countryName="' + data['countryName'] + '" class="btn btn-success btn-sm activated deleteState"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });

    $("#manageCountryForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var isValid = $("#CountryName").val();
        if (isValid != "") {
            $.ajax({
                url: event.currentTarget.action,
                type: "POST",
                data: form.serialize(),
                success: function (result) {
                    if (result.status)
                        toastr.success(result.message);
                    else
                        toastr.error(result.message);
                    stateTable.draw();
                    form[0].reset();
                },
                error: function (result) {
                    debugger;
                    if (result.status === 200) {
                        toastr.success("Success");
                        form[0].reset();
                    }
                    else
                        toastr.error("Request failed");
                }
            });
        }
    });



});