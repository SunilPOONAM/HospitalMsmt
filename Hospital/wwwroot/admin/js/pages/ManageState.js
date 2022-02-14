
$(document).ready(function () {
   var stateTable= $('#Tbl_StateMaster').DataTable
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
                "url": "/Admin/StateList",
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": null,
                    "mData": null,
                    "render": function (row,type,full,index) { 
                        return index.row + 1;
                    }
                },
                {
                    "mData": "countryName",
                    "mData": "stateName"
                }
                ,
                {
                    "mData": null,
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="btn btn-info btn-sm activated" href="UpdateState?Id=' + data['id'] + '"><i class="fa fa-pencil"></i></a> <a data-Id="' + data['id'] + '" data-stateName="' + data['stateName'] + '" class="btn btn-success btn-sm activated deleteState"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });

    $("#manageStateForm").submit(function (event) {
        event.preventDefault(); 
        var form = $(this);
        var isValid = $("#StateName").val();
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

    $("#updateState").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var isValid = $("#StateName").val();
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
                    window.location.href = "ManageState";
                },
                error: function (result) {
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


    $(document).on("click", ".deleteState", function () {
        var StateMaster = {};
        StateMaster.Id = $(this).attr("data-id");
        StateMaster.isActive = false;
        StateMaster.StateName = $(this).attr("data-stateName");;
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
                    type:"POST",
                    url: "/Admin/ManageState",
                    data: StateMaster,
                    success: function (data) {
                        Swal.fire('Deleted!', 'Your file has been deleted.', 'success');
                        $(this).addClass('selected');
                        stateTable.row('.selected').remove().draw(false); 

                    },
                    error: function (data) {
                        Swal.fire('Failed!', 'Faild', 'error');
                    }
                });
            }
        });
    })
});

