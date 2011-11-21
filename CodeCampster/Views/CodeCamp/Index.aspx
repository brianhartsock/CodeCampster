<%@ Page Title=" " Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Upcoming Camps</h3>
    <% foreach (var camp in (IList<CodeCamp>)Model)
       { %>
        <div class="colmask threecol">
            <div class="colmid">
                <div class="colleft">
                    <div class="col1">
                        <h1><%= Html.ActionLink(camp.Name, "Show", new { id = camp.Id.ToString() }) %></h1>
                    </div>
                    <div class="col2">
                        <h2><%= camp.Date.ToString("d") %></h2>
                    </div>
                    <div class="col3">
                        <p class="comment"><%= camp.Presentations.Count %> Presentations</p>
                    </div>
                </div>
            </div>
        </div>
    <% }%>
    
    <p>
        <%= Html.ActionLink("Add a Camp", "Add") %>
    </p>
    
</asp:Content>
