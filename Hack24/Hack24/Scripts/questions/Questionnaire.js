$(function () {

	$(".answer").click(function () {
		$(".answer").removeClass("selected not-selected");

		$(this).addClass("selected");
		$(this).siblings().addClass("not-selected");

		window.bus.pub("question answered", $(this).closest("ul").data("questionid"), $(this).data("answerid"));
	});

	window.bus.sub("question answered", function(questionId, answerId) {
		console.log("Answered", questionId, answerId);
	});
});