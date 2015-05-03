$(function () {
	var currentBadges = null;
	var checkBadges = function() {
		$.ajax("/badges/mybadges").done(function(badges) {
			if (!badges)
				return;

			if (currentBadges != null) {
				var newBadges = [];
				for (var i = 0; i < badges.length; i++) {
					if ($.inArray(badges[i], currentBadges) == -1) {
						newBadges.push(badges[i]);
					}
				}

				if (newBadges.length) {
					var badgeDiv = $("<div class='badgeAlert'></div>");
					$.each(newBadges, function() {
						badgeDiv.append($("<div class='badgeTitle'></div>").text(window.badgeTitles[this]));
						badgeDiv.append($("<div class='badgeDescription'></div>").text(window.badgeDescriptions[this]));
					});
					$("body > div").append(badgeDiv);
					setTimeout(function() {
						badgeDiv.remove();
						checkBadges();
					}, 5000);
				} else {
					setTimeout(checkBadges, 1000);
				}
			} else {
				setTimeout(checkBadges, 1000);
			}
			currentBadges = badges;
			
		});
	};
	setTimeout(checkBadges, 1000);
});