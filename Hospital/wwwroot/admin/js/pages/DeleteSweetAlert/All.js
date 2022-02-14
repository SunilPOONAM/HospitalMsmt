// Doctor section
function DeleteDoctorAction(id) {
    debugger;
    //var csrf_token = $('meta[name="csrf_token"]').attr('content');
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                debugger
                $.ajax({
                    url: '/HospitalAdmin/DoctorDelete',
                    data: { "id": id },
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        debugger
                        swal("Poof! Your record has been deleted!", {
                            icon: "success",
                        });

                        window.location.href = "/HospitalAdmin/DoctorList";
                    },
                    error: function (data) {
                        debugger

                        window.location.href = "/HospitalAdmin/DoctorList";
                        swal({
                            title: 'Opps...',
                            //text: data.message,
                            type: 'error',
                            timer: '1500'
                        })
                        window.location.href = "/HospitalAdmin/DoctorList";
                    }
                })
            } else {
                swal("Your record is safe!");
            }
        });
}

//Nurse section
function DeleteNurseAction(id) {
    debugger;
    //var csrf_token = $('meta[name="csrf_token"]').attr('content');
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this Record!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                debugger
                $.ajax({
                    url: '/HospitalAdmin/NurseDelete',
                    data: { "id": id },
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        debugger
                        swal("Poof! Your record has been deleted!", {
                            icon: "success",
                        });

                        window.location.href = "/HospitalAdmin/NurseList";
                    },
                    error: function (data) {
                        debugger

                        window.location.href = "/HospitalAdmin/NurseList";
                        swal({
                            title: 'Opps...',
                            //text: data.message,
                            type: 'error',
                            timer: '1500'
                        })
                        window.location.href = "/HospitalAdmin/NurseList";
                    }
                })
            } else {
                swal("Your record is safe!");
            }
        });
}

// Staff section
function DeleteStaffAction(id) {
    debugger;
    //var csrf_token = $('meta[name="csrf_token"]').attr('content');
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                debugger
                $.ajax({
                    url: '/HospitalAdmin/StaffDelete',
                    data: { "id": id },
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        debugger
                        swal("Poof! Your record has been deleted!", {
                            icon: "success",
                        });
                      
                        window.location.href = "/HospitalAdmin/StaffList";
                    },
                    error: function (data) {
                        debugger
                       
                        window.location.href = "/HospitalAdmin/StaffList";
                        swal({
                            title: 'Opps...',
                            //text: data.message,
                            type: 'error',
                            timer: '1500'
                        })
                        window.location.href = "/HospitalAdmin/StaffList";
                    }
                })
            } else {
                swal("Your record is safe!");
            }
        });
}

function DeletePatientAction(id) {
    debugger;
    //var csrf_token = $('meta[name="csrf_token"]').attr('content');
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                debugger
                $.ajax({
                    url: '/HospitalAdmin/DeletePatient',
                    data: { "id": id },
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        debugger
                        swal("Poof! Your record has been deleted!", {
                            icon: "success",
                        });

                        window.location.href = "/HospitalAdmin/PatientList";
                    },
                    error: function (data) {
                        debugger

                        window.location.href = "/HospitalAdmin/PatientList";
                        swal({
                            title: 'Opps...',
                            //text: data.message,
                            type: 'error',
                            timer: '1500'
                        })
                        window.location.href = "/HospitalAdmin/PatientList";
                    }
                })
            } else {
                swal("Your record is safe!");
            }
        });
}
