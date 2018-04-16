<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v14.2, Version=14.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v14.2, Version=14.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function OnSelectedFileChanged(s, e) {
            if (e.file != null) {
                PopupWithDocument.PerformCallback(e.file.GetFullName());
            }
        }
        function OnEndCallback(s, e) {
            s.Show();
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxFileManager ID="MyFileManager" ClientInstanceName="MyFileManager" runat="server">
                <Settings RootFolder="~\Content" ThumbnailFolder="~\Thumb\" />
                <SettingsUpload Enabled="false" />
                <ClientSideEvents SelectedFileChanged="OnSelectedFileChanged" />
            </dx:ASPxFileManager>

            <dx:ASPxPopupControl AllowResize="true" ID="PopupWithDocument" ClientInstanceName="PopupWithDocument" runat="server" OnWindowCallback="PopupWithDocument_WindowCallback" >
               <ClientSideEvents  EndCallback="OnEndCallback" />
                 <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxSpreadsheet ID="MySpreadsheet" runat="server" WorkDirectory="~/App_Data/WorkDirectory" Visible="false">
                        </dx:ASPxSpreadsheet>
                        <dx:ASPxRichEdit ID="ASPxRichEdit1" runat="server" WorkDirectory="~\App_Data\WorkDirectory" Visible="false"></dx:ASPxRichEdit>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
        </div>
    </form>
</body>
</html>