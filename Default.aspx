<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="product_nm">Product Name:</label>
            <asp:TextBox ID="product_nm" runat="server" />
            <br />

            <label for="size">Size:</label>
            <asp:TextBox ID="size" runat="server" />
            <br />

            <label for="price">Price:</label>
            <asp:TextBox ID="price" runat="server" />
            <br />

            <label for="mfgdate">Manufacture Date:</label>
            <asp:TextBox ID="mfgdate" runat="server" />
            <br />

            <label for="category">Category:</label>
            <asp:TextBox ID="category" runat="server" />
            <br />

            <label for="conjunction">Conjunction:</label>
            <select id="conjunction" runat="server">
                <option value="AND">AND</option>
                <option value="OR">OR</option>
            </select>
            <br />

            <asp:Button ID="search" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="clear" runat="server" Text="Clear" OnClick="btnClear_Click" />
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="MfgDate" HeaderText="MfgDate" SortExpression="MfgDate" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="Search" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="Size" Type="String" />
                    <asp:Parameter Name="Price" Type="String" />
                    <asp:Parameter DbType="Date" Name="MfgDate" />
                    <asp:Parameter Name="Category" Type="String" />
                    <asp:Parameter Name="Conjunction" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
