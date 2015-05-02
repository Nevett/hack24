window.bus = {
	eventListeners: {},
	pub: function (event) {
		if(this.eventListeners[event])
			for (var listener in this.eventListeners[event]) {
				this.eventListeners[event][listener].apply(null, [].splice.call(arguments, 1));
			}
	},
	sub: function(event, func) {
		if (!this.eventListeners[event])
			this.eventListeners[event] = [];
		this.eventListeners[event].push(func);
	}
}