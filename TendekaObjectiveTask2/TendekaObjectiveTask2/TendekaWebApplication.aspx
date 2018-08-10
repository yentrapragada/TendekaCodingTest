<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TendekaWebApplication.aspx.cs" Inherits="TendekaObjectiveTask2.TendekaWebApplication" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <!-- JavaScript library -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <script>
        $(document).ready(function () {
            $("#flip").click(function () {
                $("#panel").slideToggle("slow");
            });
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }

        .auto-style2 {
            width: 718px;
        }
        #panel, #flip {
            padding:5px;
            text-align:center;
            background-color:#e5eecc;
            border:solid 1px #c3c3c3;
        }
    </style>
   
    <script src="scripts/script.js"></script>

</head>
<body>

    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Tendeka</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">About <span class="sr-only">(current)</span></a></li>
                    <li><a href="#">Services</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Employes List <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Team Member</a></li>
                            <li><a href="#">Team Member 1</a></li>
                            <li><a href="#">Team Member 2</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">Manager</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">CEO</a></li>
                        </ul>
                    </li>
                </ul>

                <%--<ul class="nav navbar-nav navbar-right">
                    <li><a href="#">Link</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </li>
                </ul>--%>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
    <form class="navbar-form navbar-left" runat="server">
        <%--<div class="form-group">
                        <input type="text" class="form-control" placeholder="Open FIle"/>
           
                     </div>--%>
      <div id="flip">Click to slide the panel down to get to Logs</div>
        <div id="panel">
            <table>
                <tr>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" Font-Size="Medium" ForeColor="#996633" />
                    </td>
                    <td>
                        <asp:Button ID="btnOpenFile" runat="server" Text="Get Details" OnClick="btnOpenFile_Click" Font-Size="Medium" ForeColor="#996633" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:Label ID="lblNoFileError" runat="server" Text="* " ForeColor="#CC0000" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblFiberName" runat="server" Text="Fiber Name" Visible="False" Font-Size="Medium" ForeColor="#996633"></asp:Label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtDisplayName" runat="server" Visible="False" Font-Size="Medium"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save &amp; Download" OnClick="btnSave_Click" Visible="False" Font-Size="Medium" ForeColor="#996633" ToolTip="Save the file with new Fiber Name and Download the file to local disk" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblDepthValues" runat="server" Text="Depth Values :" Font-Size="Medium" ForeColor="#996633" Visible="False"></asp:Label>
                        &nbsp;<asp:DropDownList ID="ddlDepths" runat="server" OnSelectedIndexChanged="ddlDepths_SelectedIndexChanged" AutoPostBack="True" Visible="False" Font-Size="Medium" ForeColor="#996633"></asp:DropDownList>
                    </td>
                    <td class="auto-style2" rowspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Chart ID="chart1" runat="server" Visible="False" Palette="Chocolate" Width="409px">
                 <Series>
                     <asp:Series Name="Series1"></asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                 </ChartAreas>
             </asp:Chart>

                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <%--<asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>--%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDepts" runat="server" Text="Depth :" Visible="False" Font-Size="Medium" ForeColor="#996633"></asp:Label>
                        <asp:Label ID="lblDepthDisplay" runat="server" Visible="False" Font-Size="Medium" ForeColor="#996633"></asp:Label>

                    </td>
                </tr>
            </table>
            <div style="align-content: space-around">
            </div>
            <div id="divError" class="divErrorClass" runat="server">
            </div>
        </div>

    </form>

</body>
</html>
