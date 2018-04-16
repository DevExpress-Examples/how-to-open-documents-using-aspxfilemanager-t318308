using DevExpress.Web;
using DevExpress.Web.ASPxRichEdit;
using DevExpress.Web.ASPxSpreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Office;
using System.IO; 

public partial class _Default : System.Web.UI.Page {
    protected void PopupWithDocument_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e) {
		String fullFileName = e.Parameter;

		object format = DocumentFormatHelper.GetFormat(fullFileName);
		if (format == null) return;

		Boolean isSpreadsheet = format is DevExpress.Spreadsheet.DocumentFormat;
		ASPxSpreadsheet1.Visible = isSpreadsheet;
		ASPxRichEdit1.Visible = !isSpreadsheet;

		var docId = Guid.NewGuid().ToString();
		var docPath =  Server.MapPath(fullFileName);

		if (isSpreadsheet)
			ASPxSpreadsheet1.Open(docId, (DevExpress.Spreadsheet.DocumentFormat)format, () => File.ReadAllBytes(docPath));
		else
			ASPxRichEdit1.Open(docId, (DevExpress.XtraRichEdit.DocumentFormat)format, () => File.ReadAllBytes(docPath));
    }
}