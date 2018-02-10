function SetActivePage(page) {
    var pages = ["Browse", "Cart", "OrderHistory", "Account"];
    var navTabClass = "NavTab";
    var bg1Class = "bg1";
    $("#td" + page).addClass(navTabClass);
    $("#td" + page).removeClass(bg1Class);
    for (var i = 0; i < pages.length; i++) {
        if (page !== pages[i]) {
            $("#td" + pages[i]).addClass(bg1Class);
            $("#td" + pages[i]).removeClass(navTabClass);
        }
    }
}