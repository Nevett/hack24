$(function() {
	var totalStats = 0;

	for (var stat in stats)
		totalStats++;

	var canvas = $("#reportShape")[0];
	var angle = Math.PI / (totalStats / 2);
	var current = 0;

	canvas.width = 400;
	canvas.height = 400;

	var context = canvas.getContext("2d");

	context.fillStyle = "#fff";
	context.fillRect(0, 0, 400, 400);

	for (var i = 5; i >= 1; i--) {
		context.beginPath();
		context.arc(200, 200, i * 30, 0, 2 * Math.PI, false);
		context.fillStyle = "#F5EBF1";
		context.strokeStyle = "#D9D0D6";
		context.closePath();
		context.fill();
		context.stroke();
	}

	context.beginPath();
	for (var stat in stats) {
		if (current == 0)
			context.moveTo(200, 200 - (stats[stat] * 30));
		else
			context.lineTo(200, 200 - (stats[stat] * 30));

		context.translate(200, 200);
		context.rotate(angle);
		context.translate(-200, -200);

		current++;
	}
	context.closePath();
	context.fillStyle = "#73686F";
	context.strokeStyle = "#544C51";
	context.fill();
	context.stroke();

	context.beginPath();
	for (var i = 0; i < totalStats; i++) {
		context.moveTo(200, 30);
		context.lineTo(200, 200);

		context.translate(200, 200);
		context.rotate(angle);
		context.translate(-200, -200);
	}
	context.closePath();
	context.strokeStyle = "#000";
	context.stroke();

	current = 0;

	context.font = "18px Arial";
	context.lineWidth = 3;
	context.strokeStyle = "#000";
	context.fillStyle = "#FFF";
	for (var stat in stats) {

		context.strokeText(stat, Math.floor(200 + (Math.sin(angle * current) * (5.5 * 30)) - (context.measureText(stat).width / 2)), Math.floor(200 - (Math.cos(angle * current) * (5.5 * 30))));
		context.fillText(stat, Math.floor(200 + (Math.sin(angle * current) * (5.5 * 30)) - (context.measureText(stat).width / 2)), Math.floor(200 - (Math.cos(angle * current) * (5.5 * 30))));

		current++;
	}

});