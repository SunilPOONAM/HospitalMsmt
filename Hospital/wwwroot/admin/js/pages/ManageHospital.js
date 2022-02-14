
$(document).ready(function () {

    var tbl_Hospital = $('#tbl_Hospital').DataTable
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
                "url": "/Admin/GetHospitalsList",
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
                    "mData": "hospitalName",
                    "mRender": function (data, type, full, index) {
                        return ' <a  href="#" data-index="' + (index.row) + '"   data-id="true" class="">' + data + '</a>';
                    }
                },
                { "mData": "contactNo" },
                { "mData": "contactPersone" },
                { "mData": "email" },
                { "mData": "stateName" },
                { "mData": "cityName" },
                { "mData": "address" },
                {
                    "mData": "emailConfirmed",
                    "mRender": function (data, type, full, index) { 
                        if(data==true)
                            return ' <a  href="#" data-index="' + (index.row) + '"   data-id="true" class="">YES</i></a>';
                        else
                            return ' <a  href="#" data-index="' + (index.row) + '"   data-id="false" class="">NO</a>';


                    }
                },
                {
                    "mData": "isActive",
                    "mRender": function (data, type, full, index) {
                        if (data == true)
                            return ' <a  href="#" data-index="' + (index.row) + '"   data-id="true" class="delete-isActive"><i class="fa fa-check"></i></a>';
                        else
                            return ' <a  href="#" data-index="' + (index.row) + '"   data-id="false" class="delete-isActive"><i class="fa fa-close"></i></a>';


                    }
                },
                { "mData": "createDate" },
                { "mData": "modifiedDate" },
                {
                    "mData": null,
                    "mRender": function (data, type, full, index) {
                        
                        return '<a  class="btn btn-info btn-sm activated" href="EditHospital?Id=' + data.id + '"  data-index="' + (index.row) + '" ><i class="fa fa-pencil"></i></a> <a  data-index="' + (index.row) + '"   data-id="' + data.id + '" class="btn btn-danger btn-sm activated delete-hospital"><i class="fa fa-trash"></i></a>';
                       
                    }
                }
            ]
        });


    $("#StateId").change(function () {
        var _StateId = $(this).val();
        $.ajax({
            type: "POST",
            url: "/Admin/GetCityByState",
            data: { "StateId": _StateId },
            success: function (data) {

                $("#CityId").empty().append('<option selected="selected" value="0">Please select</option>');
                $.each(data, function (index) {
                    $("#CityId").append($("<option></option>").val(data[index].id).html(data[index].cityName));
                });
            },
            error: function (data) {
                Swal.fire('Failed!', 'Faild', 'error');
            }
        });
    });


    $(document).on("click", ".delete-hospital", function (event) {
        event.preventDefault(); 
        var rowIndex = $(this).attr("data-index");
        var rowData = tbl_Hospital.row(rowIndex).data();
        rowData.isDeleted = true;
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
                if (rowData != undefined) {
                    $.ajax({
                        type: "POST",
                        url: "/Admin/EditHospital",
                        data: rowData,
                        success: function (result) {
                            if (result.status) {
                                Swal.fire({
                                    title: 'Hospital successfully Deleted.',
                                    text: "",
                                    icon: 'success',
                                    showCancelButton: false,
                                    confirmButtonColor: '#3085d6',
                                    cancelButtonColor: '#d33',
                                    confirmButtonText: 'OK',
                                    onClose: function () {
                                        $(this).addClass('selected');
                                        tbl_Hospital.row('.selected').remove().draw(false);
                                    }
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        $(this).addClass('selected');
                                        tbl_Hospital.row('.selected').remove().draw(false);
                                    }
                                });
                            }
                            else {
                                toastr.error('failed');
                            }
                        },
                        error: function () {
                            toastr.error('failed');
                        },
                    });
                }
            }
        });
        
        
    });

    $(document).on("click", ".delete-isActive", function (event) {
        event.preventDefault();
        var isActive = $(this).attr("data-id");
        var rowIndex = $(this).attr("data-index");
        var rowData = tbl_Hospital.row(rowIndex).data();
        rowData.isActive = isActive == 'false' ? true : false;
        Swal.fire({
            title: 'Are you sure?',
            text: "You would be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes please!'
        }).then((result) => {
            if (result.isConfirmed) {
                if (rowData != undefined) {
                    $.ajax({
                        type: "POST",
                        url: "/Admin/EditHospital",
                        data: rowData,
                        success: function (result) {
                            if (result.status) {
                                Swal.fire({
                                    title: 'Hospital successfully' + isActive=='true'?"De-activated":"activated"+".",
                                    text: "",
                                    icon: 'success',
                                    showCancelButton: false,
                                    confirmButtonColor: '#3085d6',
                                    cancelButtonColor: '#d33',
                                    confirmButtonText: 'OK',
                                    onClose: function () {
                                        $(this).addClass('selected');
                                        tbl_Hospital.row('.selected').remove().draw(false);
                                    }
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        $(this).addClass('selected');
                                        tbl_Hospital.row('.selected').remove().draw(false);
                                    }
                                });
                            }
                            else {
                                toastr.error('failed');
                            }
                        },
                        error: function () {
                            toastr.error('failed');
                        },
                    });
                }
            }
        });


    });


    $("#createHospitalForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: event.currentTarget.action,
            type: "POST",
            data: form.serialize(),
            success: function (result) {
                if (result.status)
                    toastr.success("Hospital successfully created");
                else
                    toastr.error("Failed");
                console.log(form);
                form[0].reset();
            },
            error: function (result) {
                console.log(form)
                if (result.status === 200) {
                    toastr.success("Success");
                    form[0].reset();
                }
                else
                    toastr.error(result.responseText);
            }
        });


    });

    $("#updateHospitalForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: event.currentTarget.action,
            type: "POST",
            data: form.serialize(),
            success: function (result) {
                if (result.status)
                { 
                    Swal.fire({
                        title: 'Hospital successfully updated',
                        text: "",
                        icon: 'success',
                        showCancelButton: false,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'OK',
                        onClose: function () {
                            window.location.href = "ManageHospital";
                        }
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = "ManageHospital";
                        }
                    });
                }
                else
                    toastr.error("Failed");
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


    });
});