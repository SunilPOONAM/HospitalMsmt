function buyPlan(id) {
    debugger;
    $.ajax({
        url: '/Home/SubscribePlan',
        data: { "Id": id },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (data) {
            debugger;
            var data = data;
            if (data.status == 1) {
                 swal("Subscribe!", "Plan Subscribe Successfuly", "success");
            } else
                if (data.status == 2) {
                     swal("Oops...", "You don't need to buy a plan", "info");
                } else
                    if (data.status == 0) {
                       
                    }
            
        }
    });
}