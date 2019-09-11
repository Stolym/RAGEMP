var Active = false;
var Offset = null;


$(function () {
    Offset = $(".Contain").offset();
    ACTIVE_SPLITER(Active);
    $(".SpliterInput").on("change", CHANGE_EVENT_SPLITER);
});

function CHANGE_EVENT_SPLITER() 
{
    Active = !Active;
    ACTIVE_SPLITER(Active);
}

function CHANGE_SPLITER_POSITION(position)
{
    $(".Spliter").css("top", position.y - Offset.top);
    $(".Spliter").css("left", position.x - Offset.left);
}

function CHANGE_SPLITER(bool)
{
    Active = bool;
    ACTIVE_SPLITER(Active);
}

function ACTIVE_SPLITER(bool)
{
    if (bool == true)
        $(".Spliter").show();
    else if (bool == false)
        $(".Spliter").hide();
    $(".SpliterInput").val("");
}

