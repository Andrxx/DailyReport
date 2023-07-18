// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function($){
		$(".action-print").click(function () {
			window.print();
			return false;
		});
});


function CountSum() {
	let sum = parseInt($("#existed").val()) - parseInt($("#outcome").val()) + parseInt($("#income").val()) -
		parseInt($("#movedOutDep").val()) + parseInt($("#movedInDep").val()) - parseInt($("#died").val());
	$("#present").val(sum);
	
}
function CountSumChildrens() {
	let sum = parseInt($("#existedChildren").val()) - parseInt($("#outcomeChildrens").val()) + parseInt($("#incomeChildrens").val())
		- parseInt($("#movedOutDepChildrens").val()) + parseInt($("#movedInDepChildrens").val()) - parseInt($("#diedChildrens").val());
	$("#presentChildrens").val(sum);
}

function CountReject() {
	let sumRej = parseInt($("#reject").val()) + parseInt($("#rejectChildren").val());
	let sumAmb = parseInt($("#ambulance").val()) + parseInt($("#ambulanceChildren").val());
	let sumOth = parseInt($("#sendToMO").val()) + parseInt($("#sendToMOChildren").val());
	$("#sumRej").html(sumRej);
	$("#sumAmb").html(sumAmb);
	$("#sumOth").html(sumOth);
	let sumAdults = parseInt($("#reject").val()) + parseInt($("#ambulance").val()) + parseInt($("#sendToMO").val());
	$("#sumAdults").html(sumAdults);
	let sumChild = parseInt($("#rejectChildren").val()) + parseInt($("#ambulanceChildren").val()) + parseInt($("#sendToMOChildren").val());
	$("#sumChild").html(sumChild);
	let sumAll = sumAdults + sumChild;
	$("#sumAll").html(sumAll);
}

function submitWard(event) {
	event.preventDefault();
	var dep = event.target.elements.ward_Department.value;	
	var data = event.target.elements;
	alert(data);
	let response = fetch('/Wards/DepartmentWards?depNumber=' + dep, {
		// Default options are marked with *
		method: 'POST', // *GET, POST, PUT, DELETE, etc.
		mode: 'cors', // no-cors, *cors, same-origin
		cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
		credentials: 'same-origin', // include, *same-origin, omit
		headers: {
			'Content-Type': 'application/json'
			// 'Content-Type': 'application/x-www-form-urlencoded',
		},
		redirect: 'follow', // manual, *follow, error
		referrerPolicy: 'no-referrer', // no-referrer, *client
		//body: JSON.stringify(data) // body data type must match "Content-Type" header
	});

	//
	//alert(response);
	if (response.ok) { // если HTTP-статус в диапазоне 200-299 id - ward_Department  name  - ward.Department
		alert("OK");

	} else {
		alert("Ошибка HTTP: " + response.status);
	}

	//setTimeout("event.target.scrollIntoView(true)", 1000);
	//event.preventDefault();
	//var log = event.target.serialize();
	//console.log(event.target);		event.target.scrollIntoView(true);
	//alert(event.target[0]);
}