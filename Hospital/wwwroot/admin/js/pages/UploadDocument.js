function SendDocument() {
    debugger;
    var val1 = document.getElementById("editor").innerHTML;

    $.ajax({
        url: '/Doctor/uploadDocument',
        data: { "Description": val1 },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (data) {
            debugger;
            var statelist = '<option selected></option>';
            $.each(data, function (index, value) {
                var statelist = '<option value="' + value.id + '">' + value.stateName + '</option>';
                $('#statelist').append(statelist);
            });
        },
    });
}