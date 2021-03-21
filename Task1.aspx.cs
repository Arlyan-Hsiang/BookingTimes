using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    dbConnect dbConnect = new dbConnect();
    protected void Page_Init(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        dbConnect.createTable();
    }
    protected void addNewRow(object sender, EventArgs e)
    {
        dbConnect.insertTable(Convert.ToInt16(id.Text), name.Text);
        //empty the textbox
        id.Text = "";
        name.Text = "";
        //refresh the gridviews
        Gv1.DataBind();
        GridView1.DataBind();
    }
}