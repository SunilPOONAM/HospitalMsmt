$(document).ready(function () {
    debugger;
    var packagesTable = $('#prescriptionList').DataTable
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
                "url": "/Doctor/PrescriptionListAsync",
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
                { "mData": "patientId" },
                { "mData": "doctorId" },
                { "mData": "VisitingFees" },
                { "mData": "createdDate" },
                
                {
                    "mData": null,
                    "mRender": function (data, type, full, index) {
                        return '<a  class="btn btn-info btn-sm activated" href="EditPackage?Id=' + data['id'] + '"><i class="fa fa-pencil"></i></a> <a  data-index="' + (index.row) + '"   data-id="' + data.id + '" class="btn btn-danger btn-sm activated deletePackage"><i class="fa fa-trash"></i></a>';
                    }
                }
            ]
        });


});