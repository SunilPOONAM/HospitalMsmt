function deleteAction(id) {
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
                $.ajax({
                    url: '/HospitalAdmin/StaffDelete',
                    data: { "id": id },
                    type: "POST",
                    dataType: "json",
                    success: function (data) {
                        swal("Poof! Your record has been deleted!", {
                            icon: "success",
                        });
                    },
                    error: function () {
                        swal({
                            title: 'Opps...',
                            text: data.message,
                            type: 'error',
                            timer: '1500'
                        })
                    }
                })
            } else {
                swal("Your record is safe!");
            }
        });
}