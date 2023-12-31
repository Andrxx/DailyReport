﻿const wardsUrlRequest = document.location + '&handler=WardsList';
const patientsUrlRequest = document.location + '&handler=PatientsList'
const editPatient = document.location + '&handler=OnPostUpdatePatient'

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
			let filteredPaients = patientList.filter((patient) => patient.WardNumber == ward.Number);
			let wardFormWrapper = document.createElement("div");
			wardFormWrapper.classList.add('mt-1');
			let wardHeaderForm = document.createElement("form");
			let wardHeader = document.createElement("div");
			wardHeader.classList.add('ward-header');
			let patientForm = document.createElement("form");
			patientForm.setAttribute('method', 'post');
			patientForm.classList.add('patient_form');
			let patientFormText;
			let isDirty = '';
			let canPut = '';
			if (ward.IsDirtyZone) isDirty = 'checked';
			if (ward.CanPut) canPut = 'checked';

			let wardHeaderFormText =
				`<form  onsubmit='submitWard(event)'> 
					<div class='row bg-lightgray'>
						<div class='col-2'>
							Палата ${ward.Number}
							<input class='' value='${ward.Department}' type="hidden" id='ward_Department' name='Department'></input>
						</div>
						<div class='col-2 form-check form-switch'>
							<input class='form-check-input' type='checkbox' ${isDirty} id='ward_IsDirtyZone' name='IsDirtyZone'>
							<label class='form-check-label' for=''>Грязная зона</label>
						</div>
						<div class='form-check form-switch col-2'>
							<input class='form-check-input' type='checkbox' ${canPut} id='ward_CanPut' name='CanPut'>
								<label class='form-check-label' for=''>Палата открыта</label>
						</div>
						<div class='col-1'>
							<input type='submit' value='&#9998' asp-page-handler='' />
						</div>
						<div class ="d-none col-1">
							<input type="text" value='${ward.Number}' id='ward_Number' name='Number'/>
							<input  type="number" value='${ward.Capacity}' id='ward_Capacity' name='Capacity'/>
							<input type="number" value='${ward.Id}' id='ward_Id' name='Id'/>
						</div>
					</div>
				</form >`

			wardHeaderForm.setAttribute('method', 'post');
			wardHeaderForm.setAttribute('onsubmit', 'submitWard(event)');
			let wardHeaderText =
                `<div class="">
                    ФИО пациента
                </div>
                <div class="">
                    Возраст пациента
                </div>
                <div class="">
                    Пол
                </div>
                <div class="">
                    Диагноз
                </div>
                <div class="">
                    Дата
                </div>
                <div class="">
                    Сыпь
                </div>
                <div class="">
                     ВБИ
                </div>
                <div class="">
                    АК
                </div>
				<div class="invisible">
                    АК
                </div>
				<div class="invisible">
                    АК
                </div>
			`

			for (let i = 0; i < ward.Capacity; i++) {
				let name = "";
				let age = "";
				let male = "";
				let diagnos = "";
				let date = new Date();
				if (filteredPaients[i] != null) {
					name = filteredPaients[i].Name;
					age = filteredPaients[i].sAge;
					male = filteredPaients[i].Male;
					diagnos = filteredPaients[i].Diagnos;
					date = new Date(filteredPaients[i].HospitalisationDate);
					date = Intl.DateTimeFormat().format(date);
				}
				patientFormText =
				`<form>
					<input  type="text" required value='${name}' name='Name' id=''/>
					<input type="text" placeholder="" required value='${age}' name='sAge' id=''/>
					<input class="" type="text" placeholder="Пол" required value='${male}' name='Male' id=''/>
					<input class="" type="text" placeholder="Диагноз" required value='${diagnos}' name='Diagnos' id=''/>
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
						<div class="form-check form-switch col-1">
							<input class="form-check-input" type="checkbox"  ${rash} name='HasRash' id=''>
						</div>
						<div class="form-check form-switch">
							<input class="form-check-input" type="checkbox" ${care} name='HasCareRisk' id=''>
                        </div>
						<div class="form-check form-switch col-1">
							<input class="form-check-input" type="checkbox" ${untouch} name='IsUntochable' id=''>
						</div>
						<input type="submit" value="&#9998" name='edit' id='sub_edit' />
						<input type="submit" value="&#128465" name='delete' id='sub_delete'/> 

						<input class="d-none" type="hidden" value=' ${filteredPaients[i].Department}'  name='Department' id=''/>
                        <input class="d-none" type="hidden" value='${filteredPaients[i].WardNumber}' name='WardNumber' id=''/>
                        <input class="d-none" type="hidden" value='${filteredPaients[i].Id}' name='Id'/>

					</form>`

					if (filteredPaients[i].HasRash || filteredPaients[i].HasCareRisk || filteredPaients[i].IsUntochable) {
						wardFormWrapper.classList.add("ward-close");
					}//<input type="hidden"></input onclick='eventAnalys(event)'formaction="${editPatient}"
				}
				else{ 
				patientFormText +=
					`
					<input type="date" class="" value='${date}' required name='' id=''/>
					<input  type="checkbox" name='' id=''>
					<input  type="checkbox" name='' id=''>
					<input  type="checkbox" name='' id=''>
					<input type="submit" value="+" name='add' id='sub_save' id=''/>	
				</form>`
				}//<input type="submit" value=""  class="invisible" />
				patientForm.innerHTML = patientFormText;
				let fClone = patientForm.cloneNode(true);	//клонируем и добавляем форму для передачи объекта по значению

				fClone.setAttribute('onsubmit', 'savePatient(event)');	//запуск формы

				wardFormWrapper.append(fClone);
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

async function submitWard(event) {
	event.preventDefault();
	var dep = event.target.elements.ward_Department.value;
	let dirty = event.target.elements.ward_IsDirtyZone.checked;
	let canPut = event.target.elements.ward_CanPut.checked;
	var patientRows = event.target.parentElement.querySelectorAll(".patient_form");
	var patientParent = event.target.parentElement;
	let url = document.location + '&handler=FetchWard';
	let ward = new FormData(event.target); //получаем данные формы
	//удаляем вхождения в форме с value='on' и добавляем булевые значения
	ward.delete('IsDirtyZone');
	ward.delete('CanPut');
	ward.append('IsDirtyZone', event.target.elements.ward_IsDirtyZone.checked);
	ward.append('CanPut', event.target.elements.ward_CanPut.checked);

	//alert(ward);
	let response = await fetch(url	//)
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
					event.target.parentElement.classList.add('ward-close');
					//patientRows.forEach((row) => {
						//if (row.classList.contains('ward-open')) {
							//row.classList.remove('ward-open');
							//row.classList.add('ward-close');
						//}
					//})
				}
				if (canPut) {
					event.target.parentElement.classList.remove('ward-close');
					event.target.parentElement.classList.add('ward-open');
					//patientRows.forEach((row) => {
						//if (row.classList.contains('ward-close')) {
							//row.classList.add('ward-open');
							//row.classList.remove('ward-close');
						//}
					//})
				}
			}
		});
}

async function eventAnalys(event) {
	event.preventDefault();
	let action = event.target.name;
	let nPatient = event.target.parentElement;
	switch (action) {
		case 'edit':
			await savePatient(nPatient);
			break;
	}
		
}

async function savePatient(event) {
	event.preventDefault();
	let fSubmitter = event.submitter;//.target//.querySelector('#sub_edit');  //event.target.contains();
	let subUrl = '';
	switch (fSubmitter.name) {
		case 'edit':
			subUrl = '&handler=UpdatePaient';
			break;
		case 'add':
			;
			break;
		case 'delete':
			subUrl = '&handler=DeletePatient';
			break;
	}
	let url = document.location + subUrl;
	let patient = new FormData(event.target); //получаем данные формы
	if (fSubmitter.name == 'delete') {
		alert(patient.get('Id'));

		let response = await fetch(url
			, {
				method: 'POST',
				headers: {
					'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
				},
				body: new URLSearchParams(patient.get("Id"))		//преобразуем форму в application/x-www-form-urlencoded для работы привязки ASP Razor
			});
		if (response.ok) {
			//break;
		}
	}
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
		//let emptyForm = event.target.cloneNode(true);
		//event.target.parentElement.append(emptyForm);
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
		alert("Не сохранено, " + response.statusText);
	}
}