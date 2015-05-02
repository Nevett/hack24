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
			questionDiv.append($("<img/>").attr("src", "/Assets/Images/Questions/" + question.ImageUrl));
		var $answersDiv = $("<div/>").addClass("answers");

		questionDiv.append($answersDiv);

		question.Answers.sort(function() { return Math.random() >= 0.5; });

		$.each(question.Answers, function() {
			var answer = this;
			var answerDiv = $("<div class='answer'></div>").data('id', answer.Id).on('click', submitAnswer);
			var $imgDiv = $("<div/>").addClass("imgBox");
			answerDiv.append($imgDiv);
			if (answer.ImageUrl)
				$imgDiv.append($("<img/>").attr("src", "/Assets/Images/Questions/" + answer.ImageUrl));
			answerDiv.append($("<span/>").text(answer.Text));
			$answersDiv.append(answerDiv);
		});

		questionContainer.append(questionDiv);

		windowResize();
	}

	var submitAnswer = function() {
		var answerId = $(this).data('id');
		$.ajax("/questionnaire/question", { data: { lastQuestionId: currentQuestionId, lastAnswerId: answerId } }).done(populateQuestion);
	};

	$.ajax("/questionnaire/question").done(populateQuestion);

	var windowResize = function () {
		$(".answer").height($(".answer").width() + 40);
	}

	$(window).resize(windowResize);
});