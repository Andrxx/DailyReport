const wardsUrlRequest = document.location + '&handler=WardsList';
const patientsUrlRequest = document.location + '&handler=PatientsList'
const editPatient = document.location + '&handler=OnPostUpdatePatient'
const patientsInWardRequest = document.location + '&handler=PatientsInWard'
const baseUrl = window.location.origin + window.location.pathname;
const doc = document;
;
//window.onload = async () => {
//	await loadData(wardsUrlRequest);
//}

//document.addEventListener('DOMContentLoaded', function () {
//	document.querySelectorAll('.empty-form-placeholder').forEach(container => {
//		const department = container.dataset.department;
//		const wardNumber = container.dataset.wardNumber;

//		const template = document.getElementById('ward_form_template');
//		if (!template) return;

//		const form = template.content.cloneNode(true).querySelector('form');

//		// Заполняем поля Department и WardNumber
//		form.querySelector('[name="newPatient.Department"]').value = department;
//		form.querySelector('[name="newPatient.WardNumber"]').value = wardNumber;

//		// Меняем атрибуты data у формы
//		form.setAttribute('data-department', department);
//		form.setAttribute('data-ward-number', wardNumber);

//		// Вставляем форму в контейнер
//		container.replaceWith(form);
//	});
//});



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
						<div  name='HospitalisationDate' id='HospitalisationDate'> ${date} </div>
						<div class="form-check form-switch col-1">
							<input class="form-check-input" type="checkbox"  ${rash} name='HasRash' id=''>
						</div>
						<div class="form-check form-switch">
							<input class="form-check-input" type="checkbox" ${care} name='HasCareRisk' id=''>
                        </div>
						<div class="form-check form-switch col-1">
							<input class="form-check-input" type="checkbox" ${untouch} name='IsUntochable' id=''>
						</div>
						<input type="submit" value="Р" name='edit' id='sub_edit'/>
						<input type="submit" value="У" name='delete' id='sub_delete'/> 

						<input class="d-none" type="hidden" value=' ${ward.Department}'  name='Department' id=''/>
                        <input class="d-none" type="hidden" value='${ward.Number}' name='WardNumber' id=''/>
                        <input class="d-none" type="hidden" value='${filteredPaients[i].Id}' name='Id'/>

					</form>`

					if (filteredPaients[i].HasRash || filteredPaients[i].HasCareRisk || filteredPaients[i].IsUntochable) {
						wardFormWrapper.classList.add("ward-close");
					}//<input type="hidden"></input onclick='eventAnalys(event)'formaction="${editPatient}" value='${date}' корзина - &#128465 карандаш-&#9998
				}
				else{ 
				patientFormText +=
					`
					<input type="date" class="" required name='HospitalisationDate' id='HospitalisationDate'/>
					<div class="form-check form-switch col-1">
							<input class="form-check-input" type="checkbox" name='HasRash' id=''>
						</div>
						<div class="form-check form-switch">
							<input class="form-check-input" type="checkbox" name='HasCareRisk' id=''>
                        </div>
						<div class="form-check form-switch col-1">
							<input class="form-check-input" type="checkbox" name='IsUntochable' id=''>
						</div>
					<input type="submit" value="+" name='add' id='sub_save' id=''/>	

					<input class="d-none" type="hidden" value='${ward.Department}' name='Department' id=''/>
					<input class="d-none" type="hidden" value='${ward.Number}' name='WardNumber' id=''/>
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
				wardFormWrapper.classList.remove("ward-close");
				wardFormWrapper.classList.add("ward-open");
			}
			else {
				wardFormWrapper.classList.remove("ward-open");
				wardFormWrapper.classList.add("ward-close");
			}
			
			wardHeaderForm.innerHTML = wardHeaderFormText;
			wardHeader.innerHTML = wardHeaderText;
			//размещаем заголовки перед содержимым
			wardFormWrapper.prepend(wardHeader);
			wardFormWrapper.prepend(wardHeaderForm);
			//добавляем содержимое
			document.querySelector('#ward_wrapper').append(wardFormWrapper);
		}
		
	}
	else {
		alert("Не сохранено, " + response.statusText);
	}
	//alert("load");
} 

async function updateWard(event) {
	event.preventDefault();
	var dep = event.target.elements.ward_Department.value;
	let dirty = event.target.elements.ward_IsDirtyZone.checked;
	let canPut = event.target.elements.ward_CanPut.checked;
	var patientRows = event.target.parentElement.querySelectorAll(".patient_form");
	var patientParent = event.target.parentElement;
	let url = document.location + '&handler=UpdateWard';
	let ward = new FormData(event.target); //получаем данные формы
	//удаляем вхождения в форме с value='on' и добавляем булевые значения
	ward.delete('IsDirtyZone');
	ward.delete('CanPut');
	ward.append('IsDirtyZone', event.target.elements.ward_IsDirtyZone.checked);
	ward.append('CanPut', event.target.elements.ward_CanPut.checked);

	//alert(ward);
	let response = await fetch(url
		, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
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
					event.target.parentElement.classList.remove('ward-open');
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

async function EditPatient(event) {
	event.preventDefault();
	let fSubmitter = event.submitter;	
	let url;
	let subUrl = '';
	let patient = new FormData(event.target); //получаем данные формы
	let response;
	switch (fSubmitter.name) {
		case 'add':
			subUrl = '&handler=AddPatient';
			url = document.location + subUrl;
			response = await fetch(url
				, {
					method: 'POST',
					headers: {
						'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
					},
					body: new URLSearchParams(patient)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки ASP Razor
				});
			if (response.ok) {
				let newPatient = await response.json();
				//создаем новое поле даты
				let d = document.createElement('div');	
				d.setAttribute('name', 'HospitalisationDate');
				let dt = new Date(newPatient.HospitalisationDate);
				let sDate = dt.toLocaleDateString();
				d.innerHTML = sDate;
				event.target.children.namedItem('HospitalisationDate').replaceWith(d);
				//новая кнопка редактировать
				let e = document.createElement('input');
				e.setAttribute('name', 'edit');
				e.setAttribute('id', 'sub_edit');
				e.setAttribute('type', 'submit');
				e.value = "Р";
				event.target.children.namedItem('add').replaceWith(e);
				//новая кнопка удалить
				let del = document.createElement('input');
				del.setAttribute('name', 'delete');
				del.setAttribute('id', 'sub_delete');
				del.setAttribute('type', 'submit');
				del.setAttribute('value', 'У');
				event.target.children.namedItem('edit').after(del);
				//создаем новое поле id <input class="d-none" type="hidden" value='${filteredPaients[i].Id}' name='Id'/>
				let i = document.createElement('input');
				i.setAttribute('name', 'Id');
				i.setAttribute('type', 'hidden');
				i.value = newPatient.Id;
				event.target.children.namedItem('delete').after(i);
			}
			else { alert("Не сохранено!"); }
			break;

		case 'edit':
			subUrl = '&handler=UpdatePaient';
			url = document.location + subUrl;
			response = await fetch(url
				, {
					method: 'POST',
					headers: {
						'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
					},
					body: new URLSearchParams(patient)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки ASP Razor
				});
			if (response.ok) {
				//let p = await response.json();
				alert("Сохранено");
			}
			else { alert("Не сохранено!"); }
			break;

		case 'delete':
			subUrl = '&handler=DeletePatient';
			url = document.location + subUrl;
				response = await fetch(url
					, {
						method: 'POST',
						headers: {
							'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
						},
						body: new URLSearchParams(patient)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки ASP Razor
					});
			if (response.ok) {
					//очищаем поля формы кроме номера палаты и отделения
					event.target.querySelectorAll('input').forEach(el => {
						if (el.name == 'WardNumber') { ; }
						else if (el.name == 'Department') { ; }
						else if (el.name == 'HospitalisationDate') { ; }
						else el.value = '';	
					});
					let d = document.createElement('input');	//создаем новое поле даты
				d.setAttribute('name', 'HospitalisationDate');
					d.setAttribute('type', 'date');
					let i = document.createElement('input');	//создаем новую кнопку подтверждения
					i.setAttribute('type', 'submit');
					i.setAttribute('value', '+');
					i.setAttribute('name', 'add');
					i.setAttribute('id', 'sub_save');
				event.target.children.namedItem('HospitalisationDate').replaceWith(d);
					event.target.children.namedItem('Id').remove();
					event.target.children.namedItem('edit').remove();
					event.target.children.namedItem('delete').remove();
					event.target.append(i);
			}
			break;
	}

	//let response = await fetch(url
	//	, {
	//		method: 'POST',
	//		headers: {
	//			'Content-Type': 'application/x-www-form-urlencoded'	//используем кодировку для сохранения привязки объекта
	//		},
	//		body: new URLSearchParams(patient)		//преобразуем форму в application/x-www-form-urlencoded для работы привязки ASP Razor
	//	});
	//if (response.ok) {
	//	let result = await response.json();
	//	//let emptyForm = event.target.cloneNode(true);
	//	//event.target.parentElement.append(emptyForm);
	//	//alert(emptyForm);
	//	//event.target.querySelector('#newPatient_Gender').value = result.Gender;// = response.;
	//	//event.target.querySelector('#newPatient_Name').value = result.Name;
	//	//event.target.querySelector('#newPatient_AgeYears').value = result.AgeYears;
	//	//event.target.querySelector('#newPatient_AgeMonth').value = result.AgeMonth;
	//	//event.target.querySelector('#newPatient_Diagnos').value = result.Diagnos;
	//	//event.target.querySelector('#newPatient_Shipped').value = result.Shipped
	//	//event.target.querySelector('#newPatient_SubmitedFrom').value = result.SubmitedFrom;
	//	//event.target.querySelector('#newPatient_SubmitedTo').value = result.SubmitedTo;
	//	//alert(event.target.querySelector('#newPatient_Shipped').value);
	//}
	//else {
	//	alert("Не сохранено, " + response.statusText);
	//}
}

let draggedForm;
function drag_handler(event) {
	const form = event.target.closest('form');
	draggedForm = form;
	// Собираем данные из всех полей формы
	//const formData = new FormData(form);
	//const patientData = {};
	//formData.forEach((value, key) => {
	//	patientData[key] = value;
	//});

	//event.dataTransfer.setData("application/json", JSON.stringify(patientData));

	//console.log("Перетаскиваемый объект:", patientData);

	let id = form.querySelector('input[name="newPatient.Id"]').value;
	event.dataTransfer.setData("text/plain", id);
	//console.log(id, event);
}

 //Разрешаем сброс элемента
function allowDrop(event) {
	event.preventDefault(); 
	console.log("allodrop", event);

}

//function drop_handler(event) {
//	event.preventDefault();

//	// Находим целевой элемент
//	const form = event.target.closest('form');
//	//let id = form.querySelector('input[name="ward.Number"]').value;
//	const wardNumber = form.dataset.wardNumber;
//	//const targetElement = event.target.closest('.droppable-area');
//	//if (!targetElement) return;

//	//const wardId = targetElement.dataset.ward.Number; // ID палаты
//	const patientId = event.dataTransfer.getData("text/plain"); // ID пациента
//	const TransferData = {
//		PatientId: patientId,
//		WardNumber : wardNumber
//	}
//	//console.log("drop", wardNumber, patientId, event);

//	// Отправляем данные на сервер через AJAX
//	let action =  document.location.pathname + document.location.search + '&handler=DropPatient';
//	fetch(action, {
		
//		method: 'POST',
//		headers: {
//			'Content-Type': 'application/json',
//		//	"RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
//		},
//		body: JSON.stringify(TransferData)
//	})
//		.then(response => response.json())
//		.then(data => {
//			const parent = draggedForm.parentElement;
//			parent.removeChild(draggedForm);

//			const newForm = createWardForm(4, 5);
//			document.getElementById('form-container').appendChild(newForm);
//			//let emptyForm = `
//			//<form method="post" draggable="true" class="target" data-department="@ward.Department" data-ward-number="@ward.Number" ondragover="allowDrop(event)" ondrop="drop_handler(event)">@*onsubmit="EditPatient(event)"*@
//   //                     <input class="d-none" type="number" value="@ward.Department" asp-for="@Model.newPatient.Department"/>
//   //                     <input class="d-none" type="text" value="@ward.Number" asp-for="@Model.newPatient.WardNumber" />
//   //                     <div class="row patient" asp-page-handler="AddPatient" >
//   //                             <div class="col-2" >
//   //                                 <input  type="text" asp-for="@Model.newPatient.Name" required/>
//   //                             </div>
//   //                             <div class="col-2">
//   //                             <input type="text" placeholder="" asp-for="@Model.newPatient.sAge" required />
//   //                             </div>                               
//   //                             <div class="col-1">
//   //                             <input class="m-width-100" type="text" placeholder="Пол" asp-for="@Model.newPatient.Male" required/>
//   //                             </div>
//   //                             <div class="col-1">
//   //                             <input class="m-width-100" type="text" placeholder="Диагноз" asp-for="@Model.newPatient.Diagnos" required/>
//   //                             </div>
//   //                             <div class="col-1 ">
//   //                             <input type="date" class="m-width-100" value="@DateTime.Now.ToString("yyyy-MM-dd")" asp-for="@Model.newPatient.HospitalisationDate" required />
//   //                             </div>
//   //                             <div class="col-1">
//   //                                 <input  type="checkbox" asp-for="@Model.newPatient.HasRash">
//   //                             </div>
//   //                             <div class="col-1">
//   //                                 <input  type="checkbox" asp-for="@Model.newPatient.HasCareRisk">
//   //                             </div>
//   //                             <div class="col-1">
//   //                                 <input  type="checkbox" asp-for="@Model.newPatient.IsUntochable">
//   //                             </div>
//   //                             <div class="col-1 ">
//   //                                 <input type="submit" value="+" name="add" asp-page-handler="AddPatient" />
//   //                             </div>
//   //                         </div>
//   //                 </form>	`
//			//parent.insertBefore(emptyForm, event.currentTarget);
//		})
//		.catch(error => {
			
//		});
//}


function createPatientForm(department, wardNumber) {
	const template = document.getElementById('ward_form_template');
	const form = template.content.cloneNode(true).querySelector('form');

	form.querySelector('[name="department"]').value = department;
	form.querySelector('[name="wardNumber"]').value = wardNumber;

	return form;
}



//надмозг
document.addEventListener('DOMContentLoaded', function () {
	const wards = document.querySelectorAll('.patients-container');

	wards.forEach(ward => {
		const wardNumber = ward.dataset.ward;
		const depNumber = ward.dataset.department;
		const capacity = ward.dataset.wardcapacity;
		let isFull;

		fetch(baseUrl + `?handler=PatientsInWard&depNumber=${depNumber}&wardNumber=${wardNumber}`)
			.then(response => {
				if (!response.ok) throw new Error('Ошибка сети');
				return response.json();
			})
			.then(patients => {
				// Очистка контейнера перед добавлением
				ward.innerHTML = '';
				
				if (patients) {
					// Добавляем пациентов
					patients.forEach(patient => {
						const template = document.getElementById('patient-row-template');
						const clone = template.content.cloneNode(true);
						const row = clone.querySelector('.patient-row');

						row.querySelector('.name').textContent = patient.Name;
						row.querySelector('.age').textContent = patient.sAge;
						row.querySelector('.male').textContent = patient.Male;
						row.querySelector('.diagnos').textContent = patient.Diagnos;
						row.querySelector('.date').textContent = formatDate(patient.HospitalisationDate);
						row.querySelector('input[type="checkbox"]').checked = patient.HasRash;
						row.querySelectorAll('input[type="checkbox"]')[1].checked = patient.HasCareRisk;

						container.appendChild(row);
					});
					if (patients.length) {
						if (patients.length >= capacity) { isFull = true; }
					}
					// Проверяем вместимость
					if (!patients.length) {
						for (i = 0; i < capacity; i++)
						{
							const addForm = createAddPatientForm(depNumber, wardNumber);
							container.appendChild(addForm);
						}
					}
					else if(patients.length < capacity) {
						let diff = capacity - patients.length;
						for (i = 0; i < diff; i++) {
							const addForm = createAddPatientForm(depNumber, wardNumber);
							container.appendChild(addForm);
						}
					}

					if (canPut) {
						//ward.addClass
					}
				}
			});
			//.catch(err => {
			//	console.error('Ошибка загрузки пациентов:', err);
			//});
	});
});

// Создание формы добавления пациента
function createAddPatientForm(depNumber, wardNumber) {
	const template = document.getElementById('add-patient-form-template');
	const clone = template.content.cloneNode(true);
	const form = clone.querySelector('form');

	// Добавляем скрытые поля
	const inputWard = document.createElement('input');
	inputWard.type = 'hidden';
	inputWard.name = 'WardNumber';
	inputWard.value = wardNumber;
	form.appendChild(inputWard);

	const inputDep = document.createElement('input');
	inputDep.type = 'hidden';
	inputDep.name = 'Department';
	inputDep.value = depNumber;
	form.appendChild(inputDep);

	// Обработчик отправки формы
	form.onsubmit = function (e) {
		e.preventDefault();

		const formData = new FormData(form);

		fetch('/Wards/DepartmentWards?handler=AddPatient', {
			method: 'POST',
			body: formData
		})
			.then(response => {
				if (!response.ok) throw new Error('Ошибка при добавлении пациента');
				return response.json();
			})
			.then(() => {
				// Перезагружаем пациентов или обновляем список
				location.reload(); // можно улучшить до динамического обновления
			})
			.catch(err => {
				console.error('Ошибка добавления пациента:', err);
			});
	};

	return form;
}

// Формат даты
function formatDate(dateString) {
	const date = new Date(dateString);
	return `${String(date.getDate()).padStart(2, '0')}.${String(date.getMonth() + 1).padStart(2, '0')}`;
}

