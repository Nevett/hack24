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
		$.each(question.Answers, function() {
			var answer = this;
			var answerDiv = $("<div class='answer'></div>").text(answer.Text).data('id', answer.Id).on('click', submitAnswer);
			if (answer.ImageUrl)
				answerDiv.append($("<img/>").attr("src", answer.ImageUrl));
			questionDiv.append(answerDiv);
		});

		questionContainer.append(questionDiv);
	}

	var submitAnswer = function() {
		var answerId = $(this).data('id');
		$.ajax("/questionnaire/question", { data: { lastQuestionId: currentQuestionId, lastAnswerId: answerId } }).done(populateQuestion);
	};

	$.ajax("/questionnaire/question").done(populateQuestion);
});