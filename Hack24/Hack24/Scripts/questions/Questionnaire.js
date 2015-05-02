$(function () {
	var questionContainer = $("#question");
	var currentQuestionId = null;
	var populateQuestion = function(question) {
		debugger;
		questionContainer.empty();
		if (!question) {
			currentQuestionId = null;
			questionContainer.text("All out of questions!");
			return;
		}

		currentQuestionId = question.Id;
		var questionDiv = $("<div class='question'></div>");
		$.each(question.Answers, function() {
			var answer = this;
			questionDiv.append($("<div class='answer'></div>").text(answer.Text).data('id', answer.Id).on('click', submitAnswer));
		});

		questionContainer.append(questionDiv);
	}

	var submitAnswer = function() {
		var answerId = $(this).data('id');
		$.ajax("/questionnaire/question", { data: { lastQuestionId: currentQuestionId, lastAnswerId: answerId } }).done(populateQuestion);
	};

	$.ajax("/questionnaire/question").done(populateQuestion);
});