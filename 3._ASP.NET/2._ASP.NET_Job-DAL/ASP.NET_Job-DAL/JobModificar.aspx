<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobModificar.aspx.cs"
    Inherits="ASP.NET_Job_DAL.JobModificar" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">

            <%--<form id="JobModificar" runat="server">--%>

            <div id="JobForm" class="row">

                <span>ID:
                <asp:Label ID="labJobID" runat="server" Text="0"></asp:Label>
                </span>
                <br />

                <asp:Label ID="labJobTitulo" runat="server" Text="Trabajo:"></asp:Label>
                <asp:TextBox ID="txtJobTitulo" runat="server"></asp:TextBox>
                <%--<p>Trabajo:</p>
                    <input id="txtJobTitulo" type="text" />--%>
                <br />

                <asp:Label ID="labJobSalMin" runat="server" Text="Salario Minimo:"></asp:Label>
                <asp:TextBox ID="txtJobSalMin" runat="server"></asp:TextBox>
                <%-- <p>Salario Minimo:</p>
                    <input id="txtJobSalMin" type="number" />--%>
                <br />


                <asp:Label ID="labJobSalMax" runat="server" Text="Salario Maximo:"></asp:Label>
                <asp:TextBox ID="txtJobSalMax" runat="server"></asp:TextBox>
                <%--<p>Salario Maximo:</p>
                    <input id="txtJobSalMax" type="number" />--%>
                <br />

                <asp:Button ID="btnUpdate" runat="server" Text="Modificar" />
                <%--<input id="btnUpdate" type="button" value="Modificar" />--%>
                <asp:Label ID="labErrorUpdate" runat="server" class="ErrorText">
                    <%=(Session["JobSelected"] != null ? $"{Session["JobSelected"]}" : $"no Job: {Session["JobSelected"]}") %>
                </asp:Label>



            </div>

            <%--</form>--%>
        </section>
    </main>
</asp:Content>
