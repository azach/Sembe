<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="_default" %>

<asp:Content ContentPlaceHolderID="glPrimaryHeaderHolder" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="wsPrimaryNavigationHolder" runat="server">
    <div>        
        <ul class="wsPrimaryNavigationItem">
            <li class="wsPrimaryNavigationHeader">Navigation</li>
            <li class="wsPrimaryNavigationItem"><span class="wsPrimaryNavigationItemIcon" style="background-position: -5px -1px"></span>Find Patient</li>
            <li class="wsPrimaryNavigationItem"><span class="wsPrimaryNavigationItemIcon" style="background-position: -5px -20px"></span>Vitals</li>
        </ul>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="wsPrimaryContentHolder" runat="server">

<div style="padding-top: 100px;">
<center>
    <button id="newpat" class="big">New Patient</button>
    <button id="findpat" class="big">Find Patient</button>
</center>
</div>

<!--New/Find patient dialog-->
<div id="patdialog"  style="display: none;">
	<p>All form fields are required.</p>	
	<fieldset>
	<label for="firstname" class="dialog">First Name</label> <input type="text" name="firstname" id="firstname"/><br/>
	<label for="lastname" class="dialog">Last Name</label> <input type="text" name="lastname" id="lastname" value=""/><br/>
	<label for="dob" class="dialog">Date of Birth</label> <input type="text" class="date" name="dob" id="dob" value="" size="14"/><select name="sex" id="sex"><option value="" selected=true></option><option value="M">M</option><option value="F">F</option></select><br/>
	<label for="patientId" class="dialog" id="patientIdlabel">MRN</label> <input type="text" name="patientId" id="patientId"/>
	</fieldset>	
</div>

<br />

<form id="selectpatform" name="selectpatform" method="post" action="Patient.aspx"><input id="selectpatformid" name="patientId" value="" type="hidden"/></form>

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

<div id="loading"><img class="centered" src="/images/loading.gif" alt="Loading"/></div>

</asp:Content>