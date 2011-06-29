<!DOCTYPE html>
<html>
<head>
  <title>Sembe</title>
  <link href="/css/themes/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <link href="/css/main.css" rel="stylesheet" type="text/css"/>
  <link href="/css/table.css" rel="stylesheet" type="text/css"/>
  <script type="text/javascript" src="/scripts/jquery.min.js"></script>
  <script type="text/javascript"src="/scripts/jquery-ui.min.js"></script>
  <script type="text/javascript"src="/scripts/jquery.dataTables.min.js"></script>
  <script type="text/javascript"src="/scripts/main.js"></script>

    <img src="images/logo_medium.png" />

    <div id="gl-primaryNavigation">
      <ul>
       <li class="gl-primaryNavigation-li"><a href="/" title="Home">Home</a></li>
       <li class="gl-primaryNavigation-li"><a href="/tools.aspx" title="Tools">Tools</a></li>
       <li class="gl-primaryNavigation-li"><a href="/options.aspx" title="Options">Options</a></li>
     </ul>
    </div>
</head>

<body>
<br/><br/><br/><br/><br/><br/>
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

<br />

<div id="selectpatdialog" title="Select Patient">
<table id="selectpat" cellpadding="0" cellspacing="0" border="0">
    <thead>
        <tr>
            <th style="width: 100px;">ID</th>
            <th style="width: 45%;">First Name</th>
            <th style="width: 45%;">Last Name</th>
        </tr>
        <tbody></tbody>
    </thead>
</table>
</div>

<div id="loading"><img class="centered" src="/images/loading.gif" alt="Loading"/></div>

</body>
</html>