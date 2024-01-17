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

async function updatePatient(event) {
	event.preventDefault();
	let url = document.location + '?handler=FetchPatient';
	let patient = new FormData(event.target); //получаем данные формы
	let response = await fetch(url
		, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
			},
			body: new URLSearchParams(patient)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки ASP Razor
		});
	if (response.ok) {
		let result = await response.json();
		//alert(result.Gender);
		event.target.querySelector('#newPatient_Gender').value = result.Gender;// = response.;
		event.target.querySelector('#newPatient_Name').value = result.Name;
		event.target.querySelector('#newPatient_AgeYears').value = result.AgeYears;
		event.target.querySelector('#newPatient_AgeMonth').value = result.AgeMonth;
		event.target.querySelector('#newPatient_Diagnos').value = result.Diagnos;
		event.target.querySelector('#newPatient_Shipped').value = result.Shipped
		event.target.querySelector('#newPatient_SubmitedFrom').value = result.SubmitedFrom;
		event.target.querySelector('#newPatient_SubmitedTo').value = result.SubmitedTo;
	}
	else {
		alert("Не сохрнено, " + response.statusText);
	}
}






//if (dirty) 
	//alert();.parentNode.children.
	//alert();
	//let response = fetch('/Wards/DepartmentWards?depNumber=' + dep, {
	//	// Default options are marked with *
	//	method: 'POST', // *GET, POST, PUT, DELETE, etc.
	//	mode: 'cors', // no-cors, *cors, same-origin
	//	cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
	//	credentials: 'same-origin', // include, *same-origin, omit
	//	headers: {
	//		'Content-Type': 'application/json'
	//		// 'Content-Type': 'application/x-www-form-urlencoded',
	//	},
	//	redirect: 'follow', // manual, *follow, error
	//	referrerPolicy: 'no-referrer', // no-referrer, *client
	//	//body: JSON.stringify(data) // body data type must match "Content-Type" header
	//});