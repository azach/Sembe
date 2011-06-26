$(document).ready(function() {
  //Stylize the UI
  $(".date").datepicker();
  //New patient
  $("#newpat").button();
  $("#newpat").click(
	function() {
		//Hide MRN
		$("#patdialog").bind("dialogopen", function(event, ui) {
			$("#mrn").hide();
			$("#mrnlabel").hide();		
		});
		//Add new patient buttons to dialog
		$("#patdialog").dialog("option", "buttons", { 
			"Create": function() { 
				var close = NewPatient(this);
				if (close) { $(this).dialog("close"); }
			},
			"Cancel": function() { $(this).dialog("close"); }
		});
		$("#patdialog").dialog("option", "title", "Create New Patient");
		$("#patdialog").dialog("open");
	});
  //Find patient
  $("#findpat").button();
  $("#findpat").click(
	function() {
		//Show MRN
		$("#patdialog").bind("dialogopen", function(event, ui) {
			$("#mrn").show();
			$("#mrnlabel").show();		
		});
		//Add find patient buttons to dialog
			$("#patdialog").dialog("option", "buttons", { 
			"OK": function() { 
				var close = FindPatient(this);
				if (close) { $(this).dialog("close"); }
			},
			"Cancel": function() { $(this).dialog("close")
		}});
		$("#patdialog").dialog("option", "title", "Find Patient");
		$("#patdialog").dialog("open");
	});
//Define basic patient dialog parameters
  $("#patdialog").dialog({
	autoOpen: false,
	modal: true,
	width: 420,
	zIndex: 5,
	resizable: false,
	close: function(event, ui) {
		$("#firstname").val("");
		$("#lastname").val("");
		$("#dob").val("");
		$("#mrn").val("");
		$("#firstname").removeClass("ui-state-error");
		$("#lastname").removeClass("ui-state-error");
		$("#dob").removeClass("ui-state-error");
	}
  });
  $('#loading').hide();
  $('#loading').ajaxStart(function() {
       $(this).show();
  });
  $('#loading').ajaxStop(function() {
        $(this).hide();
  });
});

//Create a new patient
function NewPatient() {
  var fname = $("#firstname").val();
  var lname = $("#lastname").val();
  var dob = $("#dob").val();
  var sex = $("#sex").val();
  var create = true;
  if (fname == "") { 
    $("#firstname").addClass("ui-state-error");
	create = false; 
  } else { 
    $("#firstname").removeClass("ui-state-error");
  }
   if (lname == "") { 
    $("#lastname").addClass("ui-state-error");
	create = false; 
  } else { 
    $("#lastname").removeClass("ui-state-error");
  }
   if (dob == "") { 
    $("#dob").addClass("ui-state-error");
    create = false;
  } 
  else {
      $("#dob").removeClass("ui-state-error");
  }
  if (create) {
      $.ajax({
          type: "POST",
          contentType: 'application/json; charset=utf-8',
          dataType: "json",
          data: "{fname: \"" + fname + "\", lname: \"" + lname + "\", dob: \"" + dob + "\", sex: \"" + sex + "\"}",
          url: "PatientService.asmx/CreatePatient",
          success: function (msg) {
              alert("Patient successfully created");
          },
          error: function (jqXHR, textStatus, thrown) { alert("Error : " + thrown.toString()); }
      });
  }
  return create;
}

//Find existing patient
function FindPatient() {
    var fname = $("#firstname").val();
    var lname = $("#lastname").val();
    var dob = $("#dob").val();
    var sex = $("#sex").val();
    var mrn = $("#mrn").val();
    var success = false;
    $.ajax({
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{fname: \"" + fname + "\", lname: \"" + lname + "\", dob: \"" + dob + "\", sex: \"" + sex + "\", mrn: \"" + mrn + "\"}",
        url: "PatientService.asmx/FindPatient",
        success: function (msg) {
            var patients = $.parseJSON(msg.d);
            if (patients.length < 1) { alert("Patient not found"); }
            //SelectPatient(patients);
            //for (i = 0; i < patients.length; i++) {
            //alert(patients[i].First_Name + " " + patients[i].Last_Name);
            //}
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status == 500) {
                var error = $.parseJSON(jqXHR.responseText);
                alert(error.Message);
            }
            else { alert("Error: " + errorThrown); }            
        }
    });
    return true;
}

function SelectPatient(patients) {
    $('#selectpat').dataTable();
}