<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% var camp = (CodeCamp)Model; %>

    <h2><%= camp.Name %></h2>
    
    <div style="float:right;border-left:1px solid #53B6CC;padding:0 10px 10px 10px">
        <h4>Details</h4>
        <table>
            <tr>
                <td>When:</td>
                <td><%= camp.Date %></td>
            </tr>
            <tr>
                <td>Where:</td>
                <td><%= camp.Address.City %>, <%= camp.Address.State %></td>
            </tr>
        </table>
        
        <h4>Actions</h4>
        <%= Html.ActionLink("Cancel this Camp", "Delete", new { id = camp.Id })%>
    </div>
    
    <h3>Presentations</h3>
    <ul>
        <% foreach (var presentation in camp.Presentations)
          { %>
            <li><%= presentation.Name %> - <%= Html.ActionLink("X", "Delete", "Presentation", new { campId = camp.Id, presentationId = presentation.Id }, new { })%></li>
        <% } %>

    </ul>
            
    <% if (camp.Presentations.Count == 0)
       { %>
       
       No presentations yet!  Add one.
       
    <%}%>
    
    <% using (Html.BeginForm("Add", "Presentation", new { campId = camp.Id }))
       {%>
       
        <table>
            <tr>
                <td class="label">Name:</td>
                <td><%= Html.TextBox("presentation.Name")%></td>
            </tr>
            <tr>
                <td class="label">Abstract:</td>
                <td><%= Html.TextBox("presentation.Abstract")%></td>
            </tr>
            <tr>
                <td class="label">Audience Level:</td>
                <td><%= Html.DropDownList("presentation.AudienceLevels")%></td>
            </tr>
        </table>
        <p><input type="submit" value="Add Presentation" /></p>
       
    <% } %>
    
</asp:Content>
