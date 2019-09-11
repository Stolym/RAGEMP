$(function () {
    $(".InventoryMoney").click(MONEY_EXTRACTION);

});

function MONEY_EXTRACTION(e)
{
    CHANGE_SPLITER(true);
    CHANGE_SPLITER_POSITION({ x: e.pageX, y: e.pageY});
}