$(document).ready(function () {
    debugger;
    var tblPrescription = $('#tblPrescription').DataTable
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
                "url": "/Doctor/PrescriptionList",
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
                { "mData": "prescription" },
                {
                    "mData": "isRead",
                    "mRender": function (data, type, full) {
                        return data == false ? '<i class="fa fa-close"></i>' : '<i class="fa fa-close"></i>';
                    }
                },
                { "mData": "createdDate" },
                {
                    "mData": null,
                    "mRender": function (data, type, full, index) { 
                        return ' <a  data-index="' + (index.row) + '"   data-id="' + data.id + '" class="edit-prescription"><i class="fa fa-pencil"></i></a>';

                    }
                }
            ]
        });


    $("#addPrescriptionForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var isValid = $("#prescription").val();
        if (isValid != "") {
            $.ajax({
                url: event.currentTarget.action,
                type: "POST",
                data: form.serialize(),
                success: function (result) {
                    if (result.status) {
                        form[0].reset();
                        Swal.fire({
                            title: 'Prescription Successfully Added',
                            text: "",
                            icon: 'success',
                            showCancelButton: false,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'OK',
                            onClose: function () {
                                tblPrescription.draw();
                            }
                        }).then((result) => {
                            if (result.isConfirmed) {
                                tblPrescription.draw(); 
                            }
                        });
                    }
                    else {
                        toastr.error(result.message);
                    }

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


    $(document).on('click', ".edit-prescription", function () { 
        event.preventDefault();
        var rowIndex = $(this).attr("data-index");
        var rowData = tblPrescription.row(rowIndex).data();
        $("#edit-prescription").val(rowData.prescription);
        $("#hdnRowIndex").val(rowIndex);
        $("#editPrescriptionModal").modal();
    });

    $(document).on("click", "#btnUpdatePrescription", function () {
        let btn = $(this);
        btn.text("Processing..")
        var rowIndex = $("#hdnRowIndex").val();
        var rowData = tblPrescription.row(rowIndex).data();
        if (rowData != null && rowData != undefined) {
            rowData.prescription = $("#edit-prescription").val();
            $.ajax({
                type: "POST",
                url: "/Doctor/UpdatePrescription",
                data: rowData,
                success: function (httpResponse) {
                    btn.text("Save changes");
                    tblPrescription.draw(); 
                    $("#editPrescriptionModal").modal('hide');
                },
                error: function () {
                    btn.text("Save changes");
                }
            })
        }
    });
});