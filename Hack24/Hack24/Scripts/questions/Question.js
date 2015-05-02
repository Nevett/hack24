$(function () {
	$(".answer").click(function () {
		$(".answer").removeClass("selected not-selected");

		$(this).addClass("selected");
		$(this).siblings().addClass("not-selected");
	});
});