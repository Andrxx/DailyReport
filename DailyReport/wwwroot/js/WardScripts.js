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

		for (let ward of wardsList)
		{
			let filteredPaients = patientList.filter((patient) => patient.WardNumber == ward.Number);
			let wardFormWrapper = document.createElement("div");
			wardFormWrapper.classList.add('mt-1');
			let wardHeaderForm = document.createElement("form");
			let wardHeader = document.createElement("div");
			let patientForm = document.createElement("form");				//new HTMLElement();
			
			patientForm.classList.add('ward_form');
			let patientFormText;

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

			for (let i = 0; i < ward.Capacity; i++) {
				let name = "";
				let age = "";
				let male = "";
				let diagnos = "";
				let date = new Date();
				//let age = "";
				//let male = "";
				//let diagnos = "";
				if (filteredPaients[i] != null) {
					name = filteredPaients[i].Name;
					age = filteredPaients[i].sAge;
					male = filteredPaients[i].Male;
					diagnos = filteredPaients[i].Diagnos;
					date = new Date(filteredPaients[i].HospitalisationDate);
					date = Intl.DateTimeFormat().format(date);
					//alert(date);
					//name = filteredPaients[i].Name;
					//name = filteredPaients[i].Name;
				}
				patientFormText =
				`<form method="post" class='ward_form'>
					<input  type="text" required value='${name}' />
					<input type="text" placeholder="" required value='${age}'/>
					<input class="" type="text" placeholder="Пол" required value='${male}'/>
					<input class="" type="text" placeholder="Диагноз" required value='${diagnos}'/>
				`

				if (filteredPaients[i] != null) {
					let rash = '';
					let care = '';
					let untouch = '';
					if (filteredPaients[i].HasRash) rash = 'checked';
					if (filteredPaients[i].HasCareRisk) care = 'checked';
					if (filteredPaients[i].IsUntochable) untouch = 'checked';
					patientFormText +=
					`
						<div> ${date} </div>
						<input class="form-check-input" type="checkbox"  ${rash} asp-for="@Model.newPatient.HasRash">
						<input class="form-check-input" type="checkbox" ${care} asp-for="@Model.newPatient.HasCareRisk" >
						<input class="form-check-input" type="checkbox" ${untouch} asp-for="@Model.newPatient.IsUntochable">
						<input type="submit" value="&#9998" asp-page-handler="UpdatePatient"/>
						<input type="submit" value="&#128465" asp-page-handler="DeletePatient" />

				</form>`
					if (filteredPaients[i].HasRash || filteredPaients[i].HasCareRisk || filteredPaients[i].IsUntochable) {
						wardFormWrapper.classList.add("ward-close");
					}
				}
				else{ 
				patientFormText +=
					`
						<input type="date" class="" value='${date}' required />
						<input  type="checkbox" >
						<input  type="checkbox" >
						<input  type="checkbox" >
						<input type="submit" value="+" asp-page-handler="AddPatient"/>
						<input type="submit" value=""  class="invisible" />
				</form>`}
				patientForm.innerHTML = patientFormText;
				let fClone = patientForm.cloneNode(true);	//клонируем и добавляем форму для передачи объекта по значению
				wardFormWrapper.append(fClone);
				//wardFormWrapper.insertAdjacentHTML('beforeend', patientForm);
				}

			if (ward.Capacity <= filteredPaients.length) {
				wardFormWrapper.classList.add("ward-full");
			}
			if (ward.IsDirtyZone) {
				wardFormWrapper.classList.add("ward-dirty");
			}
			if (ward.CanPut) {
				wardFormWrapper.classList.add("ward-open");
			}
			else {
				wardFormWrapper.classList.add("ward-close");
			}
			
			wardHeaderForm.innerHTML = wardHeaderFormText;
			wardHeader.innerHTML = wardHeaderText;
			//patientForm.innerHTML = patientFormText;

			//размещаем заголовки перед содержимым
			wardFormWrapper.prepend(wardHeader);
			wardFormWrapper.prepend(wardHeaderForm);
			//document.querySelector('#ward_wrapper').append(wardHeaderForm);
			//document.querySelector('#ward_wrapper').append(wardHeader);
			//добавляем содержимое
			document.querySelector('#ward_wrapper').append(wardFormWrapper);
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
