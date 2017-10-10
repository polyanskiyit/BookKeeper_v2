$(window).load(function () {
    var height = $(window).height();
    $(".footerFixed").css('top', (height / 100) * 89);
    $(".footerFixed").css('width', '100%');
    $(".footerFixed").css("position", "fixed");
});