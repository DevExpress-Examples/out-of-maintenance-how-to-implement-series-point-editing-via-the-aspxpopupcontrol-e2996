<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.XtraCharts.v9.3.Web, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="ClientScripts.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Height="300px" Width="800px"
            ClientInstanceName="chart" EnableClientSideAPI="True" EnableClientSidePointToDiagram="True"
            EnableViewState="False" SaveStateOnCallbacks="False" OnCustomCallback="WebChartControl1_CustomCallback"
            ShowLoadingPanel="False">
            <ClientSideEvents ObjectHotTracked="function(s, e) { Chart_ObjectHotTracked(s, e); }"
                ObjectSelected="function(s, e) { Chart_ObjectSelected(s, e); }" />
        </dxchartsui:WebChartControl>
        <asp:HiddenField ID="hfOriginalArgument" runat="server" />
    </div>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" PopupAction="None"
        PopupElementID="WebChartControl1" ClientInstanceName="popup" PopupHorizontalAlign="Center"
        PopupVerticalAlign="Middle" HeaderText="Edit Series Point">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Argument" Width="100px" />
                        </td>
                        <td>
                            <dx:ASPxTimeEdit ID="teArgument" runat="server" ClientInstanceName="teArgument" Width="180px"
                                EditFormat="Custom" EditFormatString="MM/dd/yyyy HH:mm:ss" DateTime='<%# DateTime.Today %>'
                                EnableClientSideAPI="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Value" Width="100px" />
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="tbValue" runat="server" ClientInstanceName="tbValue" Width="100%"
                                EnableClientSideAPI="True" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td align="center" style="width: 50%;">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="OK" Width="100px" AutoPostBack="False">
                                <ClientSideEvents Click="function(s, e) { Ok_Click(s, e); }" />
                            </dx:ASPxButton>
                        </td>
                        <td align="center">
                            <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Cancel" Width="100px" AutoPostBack="False">
                                <ClientSideEvents Click="function(s, e) { Cancel_Click(s, e); }" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    </form>
</body>
</html>
