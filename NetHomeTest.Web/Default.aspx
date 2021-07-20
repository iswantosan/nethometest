<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetHomeTest.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Net Home Test - Iswanto</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h3>Net Home Test</h3>

                    <asp:Button runat="server" ID="btnInsert" OnClick="BtnInsert_Click" CssClass="btn btn-primary" Text="Insert" />


                    <p></p>
                    <div class="form-group">
                        <asp:TextBox placeholder="Search" autofocus runat="server" ID="txtSearch" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p></p>
                    <asp:Button runat="server" ID="btnSearch" OnClick="BtnSearch_Click" CssClass="btn btn-primary" Text="Keyword" />

                    <p>
                    </p>

                    <asp:GridView AllowPaging="true" PageSize="50" OnPageIndexChanging="gridView1_PageIndexChanging" AllowSorting="true" AutoGenerateColumns="true" ShowHeaderWhenEmpty="true" runat="server" ID="gridView1" CssClass="table table-bordered table-striped table-hover">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
