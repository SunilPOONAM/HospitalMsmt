function getStates(id) {
    document.getElementById("statelist").innerHTML = "";
    $.ajax({
        url: '/HospitalAdmin/getstates',
        data: { "Id": id },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (data) {
            var statelist = '<option selected></option>';
            $.each(data, function (index, value) {
                var statelist = '<option value="'+value.id+'">' + value.stateName + '</option>';
                $('#statelist').append(statelist);
            });
        },
    });
}

function getCity(id) {
    debugger;
    document.getElementById("citylist").innerHTML = "";
    $.ajax({
        url: '/HospitalAdmin/getcity',
        data: { "Id": id },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (data) {
            debugger;
            var citylist = '<option selected></option>';
            $.each(data, function (index, value) {
                var citylist = '<option value="' + value.id +'">' + value.cityName + '</option>';
                $('#citylist').append(citylist);
            });
        },
    });
}