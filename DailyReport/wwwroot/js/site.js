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
	let sum = parseInt($("#existedChildrens").val()) - parseInt($("#outcomeChildrens").val()) + parseInt($("#incomeChildrens").val())
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
