$(document).ready(function () {

    var packagesTable = $('#Tbl-PricingPackage').DataTable
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
                "url": "/PricingPacks/GetAllPackagesList",
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
                { "mData": "planName" },
                { "mData": "description" },
                { "mData": "billingPeroid" },
                { "mData": "amount" },
                { "mData": "features" },
                { "mData": "planType" },
                {
                    "mData": "isActive",
                    "mRender": function (data, type, full, index) {
                        if (data === true)
                            return '<input type="checkbox"  value="' + data + '" data-index="' + (index.row) + '"  checked class="isActive">';
                        else
                            return '<input type="checkbox"  value="' + data + '" data-index="' + (index.row) + '"  class="isActive">';
                    }
                },
                { "mData": "createdDate"},
                { "mData": "modifiedDate" },
                {
                    "mData": null,
                    "mRender": function (data, type, full, index) {
                        return '<a  class="btn btn-info btn-sm activated" href="EditPackage?Id=' + data['id'] + '"><i class="fa fa-pencil"></i></a> <a  data-index="' + (index.row) + '"   data-id="' + data.id + '" class="btn btn-danger btn-sm activated deletePackage"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });


    $(".planType").on("change", function (event) {
        var isFree = $(this).val();
        if (isFree === "Free") {
            $("#Amount").val("0");
            $("#Amount").attr("readonly", "true");
        }
        else {
            $("#Amount").removeAttr("readonly");
            $("#Amount").val("");
        }
    });

    $("#createPackageForm").submit(function (event) {
        event.preventDefault();
        var form = $(this); 
        $.ajax({
            url: event.currentTarget.action,
            type: "POST",
            data: form.serialize(),
            success: function (result) {
                if (result.status)
                    toastr.success("Plan successfully created.");
                else
                    toastr.error("Failed");
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


    });

     
    $(document).on("change", ".isActive", function () {
        
        var _isActive = $(this).is(":checked");
        var rowIndex = $(this).attr("data-index");
        var rowData = packagesTable.row(rowIndex).data();
        rowData.isActive = !_isActive;
        var PricingPack = {};
        PricingPack.id = rowData.id
        PricingPack.PlanName = rowData.planName;
        PricingPack.Description = rowData.description;
        PricingPack.BillingPeroid = rowData.billingPeroid;
        PricingPack.Amount = rowData.amount;
        PricingPack.Features = rowData.features;
        PricingPack.CreateDate = rowData.createDate;
        PricingPack.PlanType = rowData.planType;
        PricingPack.IsActive = _isActive;
        if (PricingPack != null) {
            $.ajax({
                type: "POST",
                url: "/PricingPacks/Update",
                data: PricingPack,
                success: function (result) {
                    if (result.status) {
                        toastr.success("Plan successfully updated.");
                        packagesTable.draw();
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
        }
    });

   
    $(document).on("click", ".deletePackage", function () { 
        var rowIndex = $(this).attr("data-index");
        var rowData = packagesTable.row(rowIndex).data(); 
        var PricingPack = {};
        PricingPack.id = rowData.id
        PricingPack.PlanName = rowData.planName;
        PricingPack.Description = rowData.description;
        PricingPack.BillingPeroid = rowData.billingPeroid;
        PricingPack.Amount = rowData.amount;
        PricingPack.Features = rowData.features
        PricingPack.CreateDate = rowData.createDate;
        PricingPack.PlanType = rowData.planType;
        PricingPack.IsActive = rowData.isActive;
        PricingPack.IsDelete = true;
        if (PricingPack != null) {
            $.ajax({
                type: "POST",
                url: "/PricingPacks/Update",
                data: PricingPack,
                success: function (result) {
                    if (result.status) {
                        toastr.success("Plan successfully deleted.");
                        packagesTable.draw();
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
        }
    });

    $("#updatePackageForm").submit(function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: event.currentTarget.action,
            type: "POST",
            data: form.serialize(),
            success: function (result) {
                if (result.status) {
                    toastr.success("Plan successfully updated.");
                    window.location.href = "Index";
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