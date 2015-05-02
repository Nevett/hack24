$(function () {
	var currentQuestion = 0;


	$(".answer").click(function () {
		$(".answer").removeClass("selected not-selected");

		$(this).addClass("selected");
		$(this).siblings().addClass("not-selected");

		window.bus.pub("question answered", $(this).closest("ul").data("questionid"));
	});

	window.bus.sub("question answered", function(num) {
		console.log("Answered", num);
	});
});