$(document).ready(function () {
    var cityTable = $('#Tbl_CityMaster').DataTable
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
                "url": "/Admin/CityList",
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
                { "mData": "countryName" },
                { "mData": "stateName" },
                {"mData": "cityName" }
                ,
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="btn btn-info btn-sm activated" href="UpdateCity?Id=' + data['id'] + '"><i class="fa fa-pencil"></i></a> <a data-Id="' + data['id'] + '" data-cityName="' + data['cityName'] + '" data-StateId="' + data['stateId'] + '" class="btn btn-success btn-sm activated deleteCity"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });


    $("#addCityForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var isValid = $("#CityName").val();
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
                    cityTable.draw();
                    form[0].reset();
                },
                error: function (result) {
                    if (result.status === 200) {
                        toastr.success("Success");
                        form[0].reset();
                    }
                    else
                        toastr.error(result.responseText);
                }
            });
        }


    });

    $("#updateCityForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var isValid = $("#CityName").val();
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
                    window.location.href = "AddCity";
                },
                error: function (result) {
                    if (result.status === 200) {
                        toastr.success("Success");
                        form[0].reset();
                    }
                    else
                        toastr.error(result.responseText);
                }
            });
        }


    });


    $(document).on("click", ".deleteCity", function () {
        var CityMaster = {};
        CityMaster.Id = $(this).attr("data-id");
        CityMaster.isActive = false;
        CityMaster.CityName = $(this).attr("data-cityName");
        CityMaster.StateId = $(this).attr("data-StateId");
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: "/Admin/AddCity",
                    data: CityMaster,
                    success: function (data) {
                        Swal.fire('Deleted!', 'Your file has been deleted.', 'success');
                        $(this).addClass('selected');
                        cityTable.row('.selected').remove().draw(false);

                    },
                    error: function (data) {
                        Swal.fire('Failed!', 'Faild', 'error');
                    }
                });
            }
        });
    })
});