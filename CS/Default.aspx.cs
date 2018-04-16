using DevExpress.Web;
using DevExpress.Web.ASPxRichEdit;
using DevExpress.Web.ASPxSpreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void PopupWithDocument_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e) {
        Boolean IsSpreadsheet = false;
        string[] fileExtensions = new string[] { "xls", "csv", "xlsx" };
        string fileExt = e.Parameter.Substring(e.Parameter.LastIndexOf('.') + 1);
        String fullFileName = e.Parameter;

        foreach(string ext in fileExtensions) {
            IsSpreadsheet = IsSpreadsheet || (fileExt == ext);
        }
        ASPxSpreadsheet MySpreadsheet = PopupWithDocument.FindControl("MySpreadsheet") as ASPxSpreadsheet;
        ASPxRichEdit MyRich = PopupWithDocument.FindControl("ASPxRichEdit1") as ASPxRichEdit;
        if(MySpreadsheet.Visible) {
            MySpreadsheet.Close();
        }
        if(MyRich.Visible) {
            MyRich.Close();
        }
        MySpreadsheet.Visible = IsSpreadsheet;
        MyRich.Visible = !IsSpreadsheet;
        if(IsSpreadsheet)
            MySpreadsheet.Open(Server.MapPath(fullFileName));
        else
            MyRich.Open(Server.MapPath(fullFileName));
    }
}