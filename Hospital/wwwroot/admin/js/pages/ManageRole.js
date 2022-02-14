
$(document).ready(function () {
   var roleTable= $('#tblRoleMaster').DataTable
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
                "url": "/Admin/RoleList",
                "type": "POST",
                "dataType": "JSON"
            },
            "aoColumns": [
                {
                    "mData": null,
                    "render": function (row,type,full,index) { 
                        return index.row + 1;
                    }
                },
                {
                    "mData": "role"
                }
                ,
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="btn btn-info btn-sm activated" href="UpdateRole?Id=' + data['id'] + '"><i class="fa fa-pencil"></i></a> <a data-Id="' + data['id'] + '" data-role="' + data['role'] + '" class="btn btn-success btn-sm activated deleteRole"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });

    $("#CreateRole").submit(function (event) {
        event.preventDefault(); 
        var form = $(this);
        var isValid = $("#Role").val();
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
                    roleTable.draw();
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

    $("#updateRole").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        var isValid = $("#role").val();
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
                    window.location.href = "CreateRole";
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


    $(document).on("click", ".deleteRole", function () {
        var RoleMaster = {};
        RoleMaster.Id = $(this).attr("data-id");
        RoleMaster.isActive = true;
        RoleMaster.isDelete = true;
        RoleMaster.Role = $(this).attr("data-role");;
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
                    url: "/Admin/CreateRole",
                    data: RoleMaster,
                    success: function (data) {
                        Swal.fire('Deleted!', 'Your file has been deleted.', 'success');
                        $(this).addClass('selected');
                        roleTable.row('.selected').remove().draw(false); 
                    },
                    error: function (data) {
                        Swal.fire('Failed!', 'Faild', 'error');
                    }
                });
            }
        });
    })
});

