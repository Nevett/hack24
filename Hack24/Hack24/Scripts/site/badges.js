$(function () {
	var currentBadges = null;
	var checkBadges = function() {
		$.ajax("/badges/mybadges").done(function(badges) {
			if (!badges)
				return;

			if (currentBadges != null) {
				var newBadges = [];
				for (var i = 0; i < badges.length; i++) {
					if ($.inArray(badges[i], currentBadges) > -1) {
						newBadges.push(badges[i]);
					}
				}

				if (newBadges.length) {
					alert("New badge! " + badgeTitles[newBadges[0]]);
				}
			}
			currentBadges = badges;
			setTimeout(checkBadges, 1000);
		});
	};
	setTimeout(checkBadges, 1000);
});