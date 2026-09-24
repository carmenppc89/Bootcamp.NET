<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%--<%@ VirtualPath %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>

        <section class="row" aria-labelledby="aspnetTitle">


            <div>
                <h1>Login</h1>

                <asp:Label ID="labEstatus" runat="server" Text="Label">
                    <%=(Session["UserName"]==null? 
                            "Aun no estas logeado":
                            $"Logeado como: {Session["UserName"]}") %>
                </asp:Label>
                <br />

                <p>User:</p>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Label ID="labLoginEstatus" runat="server" Text=""></asp:Label>

            </div>

        </section>

    </main>
</asp:Content>
