function SetActivePage(Page) {
	var Pgs = ["Browse", "Cart", "OrderHistory", "Account"];
	var PgsLength = Pgs.length;
	var NavTab = "NavTab", bg1 = "bg1";
	$('#td' + Page).addClass(NavTab);
	$('#td' + Page).removeClass(bg1);
	for (var i = 0; i < PgsLength; i++) {
		if (Page !== Pgs[i]) { $('#td' + Pgs[i]).addClass(bg1); $('#td' + Pgs[i]).removeClass(NavTab); }
	}
}

