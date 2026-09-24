<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ASP.NET_Job_DAL._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">

            <div class="col-md-6 col-sm-12" name="Jobs">

                <h1 id="TitleJobs">Jobs:</h1>

                <asp:Label ID="labErrorSelectJobs" runat="server" Text="" class="ErrorText"></asp:Label>
                <br />

                <asp:ListBox ID="ListBox_Jobs" runat="server" ItemType="Model.Job"
                    OnSelectedIndexChanged="ListBox_Jobs_SelectedIndexChanged"
                    Height="500px" Width="100%" AutoPostBack="True" OnUnload="ListBox_Jobs_Unload" ></asp:ListBox>
            </div>

            <%--            <div class="col-md-6 col-sm-12" name="JobSelected" <%--style="background-color: cornflowerblue;">

                <h1 id="TitleJobSelected">Job Selected:</h1>

                <asp:Label ID="labErrorSelectItem" runat="server" Text="" class="ErrorText"></asp:Label>
                <br />

                <div id="JobSelectedInfo" runat="server">
                    <asp:ContentPlaceHolder ID="JobInfoContent" runat="server"></asp:ContentPlaceHolder>
                </div>

            </div>--%>
        </section>
    </main>

</asp:Content>
