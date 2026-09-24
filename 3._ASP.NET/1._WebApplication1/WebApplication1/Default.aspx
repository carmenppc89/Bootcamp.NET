<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET - <%-- =Session["Inicio"] --%></h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p>
                <a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a>
            </p>

            <%--            <div class="ex01-displayTXT">
                <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                <asp:Button ID="btn1" runat="server" Text="Button" OnClick="btn1_Click"/>
            </div>

            <br />

            <div class="ex02-DiaSemana">
                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="164px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="128px">
                </asp:ListBox>
            </div>--%>
        </section>


    </main>

</asp:Content>
