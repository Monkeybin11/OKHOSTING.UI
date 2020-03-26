function OnDrag(e)
{
	e.dataTransfer.setData("text", e.target.id);
}

function AllowDrop(e)
{
	e.preventDefault();
}

function OnDrop(e)
{
	if (e.stopPropagation)
	{
		e.stopPropagation();
	}

	var dragged = e.dataTransfer.getData("text");
	var dropped = e.target.id;

	document.forms[0].appendChild("<input type='hidden' name='dragdrop_dragged' value=" + dragged + "/>");
	document.forms[0].appendChild("<input type='hidden' name='dragdrop_dropped' value=" + dropped + "/>");
	document.forms[0].submit();

	return false;
}