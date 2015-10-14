function changeItemList(idControl, route, room, device) {
    var id = "#" + idControl;
    var selDeviceId = $(id).val();

    document.forms["form1"].action = route + "/" + room + "/" + device + "/" + selDeviceId;
    document.forms["form1"].method = "Post";
    document.forms["form1"].submit();

    //submitform(controller, action, selDeviceId);
}

function changeItemList1(idControl) {
    var id = "#" + idControl;
    var selDeviceId = $(id).val();

    document.forms["form1"].action = "/Home/Devices/" + selDeviceId;
    document.forms["form1"].method = "Post";
    document.forms["form1"].submit();

    //submitform(controller, action, selDeviceId);
}

function submitform(controller, action, value) {
    document.forms["form1"].action = "/" + controller + "/" + action +"/" + value;
    document.forms["form1"].method = "Post";
    document.forms["form1"].submit();
}