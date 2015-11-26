window.onresize = function (event)
{
	SetPageSize();
}

function SetPageSize()
{
	var height = $(window).height();
	var width = $(window).width();

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
	}).done(function (data)
	{
		if (data.Refresh)
		{
			window.location.reload();
		};
	}).fail(function (xhr)
	{
		alert("Problem to retrieve browser size.");
	});

}

$(function ()
{
	SetPageSize();
});