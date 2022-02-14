var checkFeatures = function (input) {
    if ($(input).hasClass('selected')) {
        $(input).removeClass('selected');
    }
    else {
        $(input).addClass('selected');
    }
};

$(".createplan-btn").click(function (e) {
    e.preventDefault();
    var inputs = $(".selected");
    var checkboxes = '';
    $.each(inputs, function (i, val) {
        if (i === 0)
            checkboxes = val.value;
        else
            checkboxes = checkboxes + "," + val.value;
    });
    $("#featureId").val(checkboxes);
    $("form").submit();
});