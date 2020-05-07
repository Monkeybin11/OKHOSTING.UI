function ajaxPostback()
{
	$.ajax
	({
		async: true,
		type: "POST",
		url: $("#form1").attr('action'),
		data: $("#form1").serializeArray(),
		success: function (data)
		{
			//get scroll
			var scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
				scrollTop = window.pageYOffset || document.documentElement.scrollTop;

			//refresh content
			document.open();
			document.write(data);
			document.close();

			//set scroll
			document.documentElement.scrollTop = document.body.scrollTop = scrollTop;
			document.documentElement.scrollLeft = document.body.scrollLeft = scrollLeft;
		},
		error: function (xhr)
		{
			console.log("Error creating ajax postback");
		},
	});
}

$(document).ready
(
	function ()
	{
		$("input[type='submit']").on("click", function (e)
		{
			e.preventDefault(); // cancel the actual submit
			ajaxPostback();
		});

		$('#form1').on("submit", function (e)
		{
			e.preventDefault(); // cancel the actual submit
			//ajaxPostback();
		});

		__doPostBack = function (eventTarget, eventArgument)
		{
			$("#__EVENTTARGET").val(eventTarget);
			$("#__EVENTARGUMENT").val(eventArgument);
			ajaxPostback();
		}
	}
);