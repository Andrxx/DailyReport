const wardsUrlRequest = document.location + '&handler=WardsList';
const patientsUrlRequest = document.location + '&handler=PatientsList'

window.onload = async () => {
	//var url = "Reports/DepReport?depNumber=1";
	await loadData(wardsUrlRequest);
}
async function loadData(url) {
	let responseWardsList = await fetch(url);		//запрашиваем список палат
	if (responseWardsList.ok) {
		let wardsList = await responseWardsList.json();
		let responsePatientList = await fetch(patientsUrlRequest);	//загружаем список пациентов

		let patientList = [];
		if (responsePatientList.ok) {
			patientList = await responsePatientList.json();
		}
		else {
			alert("Не удалось загрузить список пациентов " + responsePatientList.statusText);
		}

		for (let ward of wardsList) {
			let wardHeaderForm = document.createElement("form");
			let wardHeader = document.createElement("div");
			let patientForm = document.createElement("form");

			let wardHeaderFormText =
				`<form method ='post' onsubmit = 'submitWard(event)' > 
					<div class='row ward-header'>
						<div class='col-2'>
							Палата ${ward.Number}
						</div>
						<div class='form-check form-switch col-2'>
							<input class='form-check-input' type='checkbox'>
								<label class='form-check-label' for=''>Грязная зона</label>\
						</div>
						<div class='col-2 form-check form-switch'>
							<input class='form-check-input' type='checkbox'>
								<label class='form-check-label' for=''>Палата открыта</label>
						</div>
						<div class='col-1'>
							<input type='submit' value='&#9998' asp-page-handler='UpdateWard' />
						</div>
					</div>
				</form >`

			let wardHeaderText =
			`<div class="row ward-header">
                <div class="col-2">
                    ФИО пациента
                </div>
                <div class="col-2">
                    Возраст пациента
                </div>
                <div class="col-1">
                    Пол
                </div>
                <div class="col-1">
                    Диагноз
                </div>
                <div class="col-1">
                    Дата
                </div>
                <div class="col-1">
                    Сыпь
                </div>
                <div class="col-1">
                    Риск ВБИ
                </div>
                <div class="col-2">
                    <h7>От главного</h7>
                </div>
            </div>`

			let patientFormText =
			` <form method="post">
                        <div class="row patient ward-open">
                                <div class="col-2">
                                    <input  type="text" required/>
                                </div>
                                <div class="col-2">
                                <input type="text" placeholder="" required />
                                </div>
                               
                                <div class="col-1">
                                <input class="m-width-100" type="text" placeholder="Пол" required/>
                                </div>
                                <div class="col-1">
                                <input class="m-width-100" type="text" placeholder="Диагноз" required/>
                                </div>
                                <div class="col-1 ">
                                <input type="date" class="m-width-100" value="@DateTime.Now.ToString("dd.MM.yy")" required />
                                </div>
                                <div class="col-1">
                                    <input  type="checkbox" >
                                </div>
                                <div class="col-1">
                                    <input  type="checkbox" >
                                </div>
                                <div class="col-1">
                                    <input  type="checkbox" >
                                </div>
                                <div class="col-1 ">
                                    <input type="submit" value="+" asp-page-handler="AddPatient"/>
                                </div>
                            </div>
                    </form>`

			wardHeaderForm.innerHTML = wardHeaderFormText;
			wardHeader.innerHTML = wardHeaderText;
			patientForm.innerHTML = patientFormText;
			document.querySelector('#ward_wrapper').append(wardHeaderForm);
			document.querySelector('#ward_wrapper').append(wardHeader);
			document.querySelector('#ward_wrapper').append(patientForm);
		}
		//alert(result);
		//event.target.querySelector('#newPatient_Gender').value = result.Gender;// = response.;
		//event.target.querySelector('#newPatient_Name').value = result.Name;
		//event.target.querySelector('#newPatient_AgeYears').value = result.AgeYears;
		//event.target.querySelector('#newPatient_AgeMonth').value = result.AgeMonth;
		//event.target.querySelector('#newPatient_Diagnos').value = result.Diagnos;
		//event.target.querySelector('#newPatient_Shipped').value = result.Shipped
		//event.target.querySelector('#newPatient_SubmitedFrom').value = result.SubmitedFrom;
		//event.target.querySelector('#newPatient_SubmitedTo').value = result.SubmitedTo;
		//alert(event.target.querySelector('#newPatient_Shipped').value);
	}
	else {
		alert("Не сохранено, " + response.statusText);
	}
	//alert("load");
} 

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

async function savePatient(event) {
	event.preventDefault();
	let url = document.location + '?handler=FetchSavePatients';
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
		let emptyForm = event.target.cloneNode(true);
		event.target.parentElement.append(emptyForm);
		//alert(emptyForm);
		//event.target.querySelector('#newPatient_Gender').value = result.Gender;// = response.;
		//event.target.querySelector('#newPatient_Name').value = result.Name;
		//event.target.querySelector('#newPatient_AgeYears').value = result.AgeYears;
		//event.target.querySelector('#newPatient_AgeMonth').value = result.AgeMonth;
		//event.target.querySelector('#newPatient_Diagnos').value = result.Diagnos;
		//event.target.querySelector('#newPatient_Shipped').value = result.Shipped
		//event.target.querySelector('#newPatient_SubmitedFrom').value = result.SubmitedFrom;
		//event.target.querySelector('#newPatient_SubmitedTo').value = result.SubmitedTo;
		//alert(event.target.querySelector('#newPatient_Shipped').value);
	}
	else {
		alert("Не сохрнено, " + response.statusText);
	}
}
