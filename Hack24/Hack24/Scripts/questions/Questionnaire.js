$(function () {
	var questionContainer = $("#question");
	var currentQuestionId = null;
	var populateQuestion = function(question) {
		questionContainer.empty();
		if (!question) {
			currentQuestionId = null;
			questionContainer.text("All out of questions!");
			return;
		}

		currentQuestionId = question.Id;
		var questionDiv = $("<div class='question'></div>");
		questionDiv.append($("<div class='question-text'></div>").text(question.Text));
		if (question.ImageUrl)
			questionDiv.append($("<img/>").attr("src", question.ImageUrl));
		var $answersDiv = $("<div/>").addClass("answers");

		questionDiv.append($answersDiv);

		$.each(question.Answers, function() {
			var answer = this;
			var answerDiv = $("<div class='answer'></div>").data('id', answer.Id).on('click', submitAnswer);
			if (answer.ImageUrl)
				answerDiv.append($("<img/>").attr("src", answer.ImageUrl));
			answerDiv.append($("<span/>").text(answer.Text));
			$answersDiv.append(answerDiv);
		});

		questionContainer.append(questionDiv);
	}

	var submitAnswer = function() {
		var answerId = $(this).data('id');
		$.ajax("/questionnaire/question", { data: { lastQuestionId: currentQuestionId, lastAnswerId: answerId } }).done(populateQuestion);
	};

	$.ajax("/questionnaire/question").done(populateQuestion);

	$(window).resize(function () {
		$(".answer").height($(".answer").width() + 20);
		$(".answer img").height($(".answer img").width() + 20);
	});
});