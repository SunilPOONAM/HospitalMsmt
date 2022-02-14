$(document).ready(function () {
    var cityTable = $('#tblPatient').DataTable
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
                "url": "/Doctor/PatientList",
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
                        return '<a data-Id="' + data['id'] + '" class="" href="AddPrescription?patientId=' + data.id + '"> Prescription</a>';
                    }
                },
                {
                    "mData": null,
                    "mRender": function (data, type, full) {
                        return '<a data-Id="' + data['id'] + '" class="" href="#"> view</a>';
                    }
                }
            ]
        });

});