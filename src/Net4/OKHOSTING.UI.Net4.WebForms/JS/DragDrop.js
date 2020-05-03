function OnDragStart(e) {
	e.dataTransfer.setData("text", e.target.id);
}

function OnDragOver(e) {
	e.preventDefault();
}

function OnDrop(e) {
	e.preventDefault();

	var dragged = e.dataTransfer.getData("text");
	var droppedOn = e.target.id;

	var draggedInput = document.createElement("input");
	draggedInput.setAttribute("type", "hidden");
	draggedInput.setAttribute("name", "dragdrop_dragged");
	draggedInput.setAttribute("value", dragged);

	var droppedOnInput = document.createElement("input");
	droppedOnInput.setAttribute("type", "hidden");
	droppedOnInput.setAttribute("name", "dragdrop_droppedOn");
	droppedOnInput.setAttribute("value", droppedOn);

	document.forms[0].appendChild(draggedInput);
	document.forms[0].appendChild(droppedOnInput);

	document.forms[0].submit();

	return false;
}