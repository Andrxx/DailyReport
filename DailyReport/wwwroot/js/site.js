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

//TODO сообщение об ошибке при сбое БД
function submitWard(event) {
	event.preventDefault();
	var dep = event.target.elements.ward_Department.value;	
	let dirty = event.target.elements.ward_IsDirtyZone.checked;
	let canPut = event.target.elements.ward_CanPut.checked;
	var patientRows = event.target.parentElement.querySelectorAll(".patient");
	var patientParent = event.target.parentElement;
	//alert(document.location);
	let url = document.location + '&handler=FetchWard';
	let ward = new FormData(event.target); //получаем данные формы
	//alert(ward);
	let response = fetch(url	//)
		, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
				// 'Content-Type': 'application/x-www-form-urlencoded',
			},
		body: new URLSearchParams(ward)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки
	})
	.then((response) => {
		if (response.ok) {
			if (!dirty) {
				if (patientParent.classList.contains('ward-dirty')) {
				event.target.parentElement.classList.remove('ward-dirty');
				}
			}
				if (dirty) {
					if (!patientParent.classList.contains('ward-dirty')) {
					event.target.parentElement.classList.add('ward-dirty');
					}
				}
			if (!canPut) {
				patientRows.forEach((row) => {
					if (row.classList.contains('ward-open')) {
						row.classList.remove('ward-open');
						row.classList.add('ward-close');
					}
				})
			}
			if (canPut) {
				patientRows.forEach((row) => {
					if (row.classList.contains('ward-close')) {
						row.classList.add('ward-open');
						row.classList.remove('ward-close');
					}
				})
			}
		}
	});
}

function updatePatient(event) {
	//event.preventDefault();
	//let url = document.location + '?handler=FetchPatient';
	//let patient = new FormData(event.target); //получаем данные формы

	//let response = fetch(url
	//	, {
	//		method: 'POST',
	//		headers: {
	//			'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
	//			// 'Content-Type': 'application/x-www-form-urlencoded',
	//		},
	//		body: new URLSearchParams(patient)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки
	//	})
	//	.then((response) => {
	//		let patient = response.json();
	//		event.target.querySelector('newPatient_Name').value = response.;
	//		//
	//		//newPatient_Gender
	//		//newPatient_AgeYears
	//		//newPatient_AgeMonth
	//		//newPatient_Diagnos
	//		//newPatient_Shipped
	//		//newPatient_SubmitedFrom
	//		//newPatient_SubmitedTo
	//	});
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