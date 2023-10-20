<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm_SQL_StoredProcedure._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h1>PTML TEST WEBFORMS WITH T-SQL STORED PROCEDURES</h1>
        <table class="data-table">
            <tr>
                <th>BL_ID</th>
                <th>CONSIGNEE</th>
                <th>BL_NUMBER</th>
                <th>TYPE_BL</th>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtBlId" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtConsignee" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtBl_Number" runat="server"></asp:TextBox></td>
                <td><asp:TextBox ID="txtUnit" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="action-button" /></td>
                <td><asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="action-button" /></td>
            </tr>
        </table>

        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_BL" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="ID_BL" HeaderText="ID_BL" />
                <asp:BoundField DataField="CONSIGNEE" HeaderText="Consignee" />
                <asp:BoundField DataField="BL_NUMBER" HeaderText="BL Number" />
                <asp:BoundField DataField="TYPE_BL" HeaderText="Type_Bl" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </main>
</asp:Content>
