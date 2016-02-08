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
    <form id="form1" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button> 
                <ul>               
                    <li><a href="Datos/Create" class ="navbar-brand">Simulador de Temperatura</a></li>
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
        <hr/>
         &nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" width="120px" runat="server" DataSourceID="SqlDataSource1" DataTextField="Id" DataValueField="Id" AutoPostBack ="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" EnableTheming="True"></asp:DropDownList>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatiosModel %>" SelectCommand="SELECT * FROM [Datos]"></asp:SqlDataSource><br/><br/><br/>             
        <div class="row"> 
            <table class="table">
                <tr>
                    <th>
                       &nbsp;&nbsp;&nbsp;&nbsp;Capacidad: </th>
                    <th>
                         Temp. Inicial:
                    </th>
                    <th>
                        Material:
                    </th>
                    <th>
                        Resistencia:
                    </th>
                    <th>
                        Ml/Segundos:                    
                    </th>
                    <th>
                        Ml/Inicial:
                    </th>
                 </tr>
                <tr>
                    <td>
                       &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Enabled="False" ></asp:TextBox>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Enabled="False" ></asp:TextBox>                     
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Enabled= "False" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Enabled ="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                </table>
            </div>

        <hr/>

        <table class="table">
            <tr>
                <th>
                    Temperatura
                </th>  
                <th>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CausesValidation="True" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">Manual</asp:ListItem>
                        <asp:ListItem Selected="True" Value="1">Automatico</asp:ListItem>
                    </asp:CheckBoxList>
                </th>             
            </tr>
            <tr>
                <td>
                   
                 </td>
            </tr>
        </table>

        <asp:Button ID="Button1" runat="server" Text="Abrir " />
        <asp:Button ID="Button2" runat="server" Text="Cerrar" />

    </form>
  
</body>
</html>
