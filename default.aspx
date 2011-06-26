<!DOCTYPE html>
<html>
<head>
  <title>Sembe</title>
  <link href="/css/themes/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <link href="/css/main.css" rel="stylesheet" type="text/css"/>
  <script type="text/javascript" src="/scripts/jquery.min.js"></script>
  <script type="text/javascript"src="/scripts/jquery-ui.min.js"></script>
  <script type="text/javascript"src="/scripts/main.js"></script>
</head>
<body>

<br/><br/><br/><br/>
<center><h1>Sembe</h1></center>
<br/><br/><br/><br/>

<center>
<button id="newpat" class="big">New Patient</button>
<button id="findpat" class="big">Find Patient</button>
</center>

<!--New/Find patient dialog-->
<div id="patdialog">
	<p>All form fields are required.</p>	
	<fieldset>
	<label for="firstname" class="dialog">First Name</label> <input type="text" name="firstname" id="firstname"/><br/>
	<label for="lastname" class="dialog">Last Name</label> <input type="text" name="lastname" id="lastname" value=""/><br/>
	<label for="dob" class="dialog">Date of Birth</label> <input type="text" class="date" name="dob" id="dob" value="" size="14"/><select name="sex" id="sex"><option value="" selected=true></option><option value="M">M</option><option value="F">F</option></select><br/>
	<label for="mrn" class="dialog" id="mrnlabel">MRN</label> <input type="text" name="mrn" id="mrn"/>
	</fieldset>	
</div>

<div id="selectpat"></div>

<div id="loading"><img class="centered" src="/images/loading.gif" alt="Loading"/></div>

</body>
</html>