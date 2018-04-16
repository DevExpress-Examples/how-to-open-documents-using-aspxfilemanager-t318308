Imports DevExpress.Web
Imports DevExpress.Web.ASPxRichEdit
Imports DevExpress.Web.ASPxSpreadsheet
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub PopupWithDocument_WindowCallback(ByVal source As Object, ByVal e As DevExpress.Web.PopupWindowCallbackArgs)
        Dim IsSpreadsheet As Boolean = False
        Dim fileExtensions() As String = { "xls", "csv", "xlsx" }
        Dim fileExt As String = e.Parameter.Substring(e.Parameter.LastIndexOf("."c) + 1)
        Dim fullFileName As String = e.Parameter

        For Each ext As String In fileExtensions
            IsSpreadsheet = IsSpreadsheet OrElse (fileExt = ext)
        Next ext
        Dim MySpreadsheet As ASPxSpreadsheet = TryCast(PopupWithDocument.FindControl("MySpreadsheet"), ASPxSpreadsheet)
        Dim MyRich As ASPxRichEdit = TryCast(PopupWithDocument.FindControl("ASPxRichEdit1"), ASPxRichEdit)
        If MySpreadsheet.Visible Then
            MySpreadsheet.Close()
        End If
        If MyRich.Visible Then
            MyRich.Close()
        End If
        MySpreadsheet.Visible = IsSpreadsheet
        MyRich.Visible = Not IsSpreadsheet
        If IsSpreadsheet Then
            MySpreadsheet.Open(Server.MapPath(fullFileName))
        Else
            MyRich.Open(Server.MapPath(fullFileName))
        End If
    End Sub
End Class