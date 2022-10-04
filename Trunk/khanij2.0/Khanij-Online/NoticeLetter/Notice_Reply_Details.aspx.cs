using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NoticeLetter_Notice_Reply_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue == "2")
        {
            divPenalty.Visible = true;
        }
        else
            divPenalty.Visible = false;
    }
}