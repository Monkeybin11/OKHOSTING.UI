function OnDragStart(e)
{
	e.dataTransfer.setData("text", e.target.id);
}

function OnDragOver(e)
{
	e.preventDefault();
}

function OnDrop(e)
{
	e.preventDefault();
	console.log("OnDrop: " + e.target.id);

	var dragged = e.dataTransfer.getData("text");
	var dropped = e.target.id;

	var dragdrop_dragged = document.createElement("input");
	dragdrop_dragged.setAttribute("type", "hidden");
	dragdrop_dragged.setAttribute("name", "dragdrop_dragged");
	dragdrop_dragged.setAttribute("value", dragged);

	var dragdrop_dropped = document.createElement("input");
	dragdrop_dropped.setAttribute("type", "hidden");
	dragdrop_dropped.setAttribute("name", "dragdrop_dropped");
	dragdrop_dropped.setAttribute("value", dropped);

	document.forms[0].appendChild(dragdrop_dragged);
	document.forms[0].appendChild(dragdrop_dropped);

	console.log(dragged);
	console.log(dropped);

	document.forms[0].submit();

	return false;
}