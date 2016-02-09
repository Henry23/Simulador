<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simular.aspx.cs" Inherits="Simulador.Views.Simulador.Simular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />

    <link href="~/Content/css" rel="stylesheet" type="text/css" />
    <script src="~/bundles/modernizr" type="text/javascript"></script>

    <title></title>
    <style type="text/css">
        .newStyle2 {
            table-layout: auto;
            border-collapse: separate;
            border-spacing: inherit;
            empty-cells: show;
            caption-side: bottom;
        }

        .table {
            table-layout: fixed;
            border-collapse: separate;
            empty-cells: show;
            border-spacing: inherit;
            
        }
    </style>
</head>
<body>
    <div id="header">
        <h1>&nbsp;&nbsp;&nbsp;&nbsp;Simulador</h1>
    </div>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <ul>
                        <li><a href="Datos/Create" class="navbar-brand">Simulador de Temperatura</a></li>
                    </ul>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="Simular.aspx">Simular</a></li>
                        <li><a href="Datos/Index">Datos</a></li>
                    </ul>

                </div>
            </div>
        </div>
    <hr />
    <div class="bodycontent">
        <div class="row">
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" Width="120px" runat="server" DataSourceID="SqlDataSource1" DataTextField="Id" DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" EnableTheming="True"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatiosModel %>" SelectCommand="SELECT * FROM [Datos]"></asp:SqlDataSource>
            <br />
            <br />
            <br />

            <table class="table">
                 <thead class="thead-inverse">
                     <tr>
                         <th>&nbsp;&nbsp;&nbsp;&nbsp;Capacidad: </th>
                         <th>Temp. Inicial:</th>
                         <th>Costo:</th>
                         <th>Watts:</th>
                         <th>Litros/S:</th>
                         <th>Volumen Inicial:</th>
                     </tr>
                     </thead>
                <tbody>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox2" class="form-control" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox3" class="form-control" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox4" class="form-control" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox5" class="form-control" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox6" class="form-control" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <hr />
    <table class="table">       
        <tr>
            <th>Temperatura
                <div class="progress">
                    <div class="progress-bar progress-bar-danger" role="progressbar" runat="server" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100" style="width: 80%">80%
                        <span class="sr-only"> 80% Complete (danger)</span>
                    </div>
                </div>
                <asp:Label ID="Label1" runat="server" Text="TempFinal"></asp:Label>
                <asp:TextBox ID="TempFinal" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Minutos"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </th>
            <th>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CausesValidation="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">Manual</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">Automatico</asp:ListItem>
                </asp:CheckBoxList>
            </th>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>

    <asp:Button ID="Button1" class="btn btn-primary btn-large" runat="server" Text="Empezar " OnClick="Button1_Click" />
    <asp:Button ID="Button2" class="btn btn-primary btn-large" runat="server" Text="Cerrar" />

    </form>
  
</body>
</html>
