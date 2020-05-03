function SetPageSize()
{
	var width = $(window).width();
	var height = $(window).height();

	$.ajax
	({
		url: "Services/PageSize.ashx",
		data:
		{
			'Height': height,
			'Width': width
		},
		contentType: "application/json; charset=utf-8",
		dataType: "json"
	}).success(function (data)
	{
		if (data.Refresh)
		{
			window.location = window.location;
		}
	}).error(function (xhr) {
		console.log("Problem to retrieve browser size");
	});
}

var waitForFinalEvent = (function () {
	var timers = {};

	return function (callback, ms, uniqueId) {
		if (!uniqueId) {
			uniqueId = "window.resize";
		}

		if (timers[uniqueId]) {
			clearTimeout(timers[uniqueId]);
		}

		timers[uniqueId] = setTimeout(callback, ms);
	};
})();

$(document).ready
(
	function () {
		$(window).resize(function () {
			waitForFinalEvent(function () {
				SetPageSize();
			}, 500, "window.resize");
		});
	}
);