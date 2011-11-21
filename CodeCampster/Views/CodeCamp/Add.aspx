<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add</h2>
    
    <% using (Html.BeginForm())
       { %>
        <table>
            <tr>
                <td class="label">Name:</td>
                <td><%= Html.TextBox("Name") %></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><%= Html.TextBox("Address.City") %></td>
            </tr>
            <tr>
                <td>State:</td>
                <td><%= Html.TextBox("Address.State") %></td>
            </tr>
            <tr>
                <td>Date:</td>
                <td><%= Html.TextBox("Date", null, new { id="datepicker" }) %></td>
            </tr>
        </table>
        <p><input type="submit" value="Add" /></p>
    <% } %>
    
    <script language="javascript" type="text/javascript">
      $(document).ready(function(){
        $("#datepicker").datepicker();
      });
    </script>

</asp:Content>
