function selectedChat(id) {
    debugger;
    document.getElementById("msgeChatsender").innerHTML = "";
    $.ajax({
        url: '/Doctor/SelectedUserChat',
        data: { "id": id },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (data) {
            debugger;
            $("#ChatUserName").text(data.data.firstName);
            $("#recieverId").val(data.data.id);
            var logId = data.loginId;
            debugger;
            $.each(data.chat, function (index, value) {
                if (value.senderID == logId) {
                    var newdiv = '<div class="d-flex justify-content-end mb-4"><div class="msg_cotainer_send">' + value.message + '<span class="msg_time_send"> 9:05 AM, Today</span></div></div>';
                } else {
                    var newdiv = ' <div class="d-flex justify-content-start mb-4"><div class="msg_cotainer">' + value.message +'<span class="msg_time">8:40 AM, Today</span></div></div >';
                }
                $('#msgeChatsender').append(newdiv);
            });
            $("#msgeChatsender").stop().animate({ scrollTop: $("#msgeChatsender")[0].scrollHeight }, 1000);
        },

    });
}


function ChatMessage() {
    var reciverId = document.getElementById("recieverId").value;
    var message = document.getElementById("msg").value;
    document.getElementById("msg").value = "";
    $.ajax({
        url: '/Doctor/SendChatMessage',
        data: { "RecieverID": reciverId, "Message": message },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (data) {
            var newdiv = '<div class="d-flex justify-content-end mb-4"><div class="msg_cotainer_send">' + data.message + '<span class="msg_time_send"> 9:05 AM, Today</span></div></div>';
            $('#msgeChatsender').append(newdiv);
            $("#msgeChatsender").stop().animate({ scrollTop: $("#msgeChatsender")[0].scrollHeight }, 1000);
        },

    });
}