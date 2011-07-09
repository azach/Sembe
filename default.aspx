<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Sembe</title>
  <link href="/css/themes/jquery-ui.css" rel="stylesheet" type="text/css"/>
  <link href="/css/main.css" rel="stylesheet" type="text/css"/>
  <link href="/css/table.css" rel="stylesheet" type="text/css"/>
  <script type="text/javascript" src="/scripts/jquery.min.js"></script>
  <script type="text/javascript"src="/scripts/jquery-ui.min.js"></script>
  <script type="text/javascript"src="/scripts/jquery.dataTables.min.js"></script>
  <script type="text/javascript"src="/scripts/main.js"></script>
</head>

<body>
    <img src="images/logo_medium.png" />

    <div id="gl-primaryNavigation">
      <ul>
       <li class="gl-primaryNavigation-li"><a href="/" title="Home">Home</a></li>
       <li class="gl-primaryNavigation-li"><a href="/tools.aspx" title="Tools">Tools</a></li>
       <li class="gl-primaryNavigation-li"><a href="/options.aspx" title="Options">Options</a></li>
     </ul>
    </div>
<br/><br/><br/>
<div id="ws-primaryNavigation">
</div>
<div id="ws-primaryContent">
<br/><br/><br/><br/><br/>
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

<form id="selectpatform" name="selectpatform" method="post" action="Patient.aspx"><input id="selectpatformid" name="selectpatformid" value="" type="hidden"/></form>
<div id="selectpatdialog" title="Select Patient">
<table cellpadding="0" cellspacing="0" border="0" class="display" id="selectpat"> 
	<thead>
		<tr>
			<th>ID</th>
			<th>First Name</th>
			<th>Last Name</th>
		</tr>
	</thead>
	<tbody>
	</tbody>
</table>
</div>
</div>

<div id="loading"><img class="centered" src="/images/loading.gif" alt="Loading"/></div>

</body>
</html>