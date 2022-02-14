$(document).ready(function () {
    debugger;
    var tblPatient = $('#tblPatient').DataTable
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
                "url": "/HospitalAdmin/HospitalPatientsLit",
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
                { "mData": "patientName" },
                { "mData": "age" },
                { "mData": "email" },
                { "mData": "phone" },
                { "mData": "isActive" }, 
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="" href="PatientDetails?id=' + data.id + '">GO</a>';
                    }
                },
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="" href="EditPatient?id=' + data.id + '"><i class="fa fa-pencil"></i></a> <a data-Id="' + data['id'] + '" class="btn-delete" href="#"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });


    $(document).on("click", ".btn-delete", function (event) {
        event.preventDefault();
        var rowIndex = $(this).attr("data-index");
        var rowData = tblPatient.row(rowIndex).data();
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
                        url: "/HospitalAdmin/DeletePatient",
                        data: rowData,
                        success: function (result) {
                            if (result.status) {
                                Swal.fire({
                                    title: 'Patient Successfully Deleted.',
                                    text: "",
                                    icon: 'success',
                                    showCancelButton: false,
                                    confirmButtonColor: '#3085d6',
                                    cancelButtonColor: '#d33',
                                    confirmButtonText: 'OK',
                                    onClose: function () {
                                        $(this).addClass('selected');
                                        tblPatient.row('.selected').remove().draw(false);
                                    }
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        $(this).addClass('selected');
                                        tblPatient.row('.selected').remove().draw(false);
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

});