$(function () {
	var $questions = $("ul");
	var questions = [];

	for (var i = 0; i < $questions.length; i++) {
		questions.push({ id: $($questions[i]).data("questionid"), answerId: null });
	}
	$(".answer").click(function () {
		$(".answer").removeClass("selected not-selected");

		$(this).addClass("selected");
		$(this).siblings().addClass("not-selected");

		window.bus.pub("question answered", $(this).closest("ul").data("questionid"), $(this).data("answerid"));
	});

	window.bus.sub("question answered", function (questionId, answerId) {
		var nextQuestion;

		for (var i = 0; i < questions.length; i++) {
			if (questions[i].id == questionId)
				questions[i].answerId = answerId;
			else if (questions[i].answerId == null && nextQuestion == null)
				nextQuestion = questions[i].id;
		}

		if (nextQuestion == null)
			window.bus.pub("questionnaire finish", questions);
		else
			window.bus.pub("question goto", nextQuestion);
	});

	window.bus.sub("question goto", function (questionId) {
		var $target = $("ul[data-questionid='" + questionId + "']").closest(".question");
		$("body").animate({ scrollTop: $target.offset().top });
	});

	window.bus.sub("questionnaire finish", function (answers) {
		var $target = $(".finishBlock");

		$(".question").hide();
		$target.show();

		$("body").animate({ scrollTop: $target.offset().top });

		console.log("Questionnaire finish", answers);
	});
});