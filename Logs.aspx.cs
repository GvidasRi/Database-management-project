using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Logs : System.Web.UI.Page
{
    string vardas, action, data;
    string priv = "";
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from logs";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        GridView1.DataSource = dtbl2;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from users Where paskyra = '" + GridView1.SelectedRow.Cells[2].Text + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        if (dtbl2.Rows.Count > 0)
        {
            priv = dtbl2.Rows[0]["Privilegijos"].ToString();
        }
        else
        {
            priv = "-";
        }

        TextBox1.Text = GridView1.SelectedRow.Cells[4].Text;
        TextBox2.Text = priv;
        TextBox3.Text = GridView1.SelectedRow.Cells[5].Text;
        TextBox4.Text = GridView1.SelectedRow.Cells[3].Text;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from logs";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        GridView1.DataSource = dtbl2;
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from logs";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        GridView1.DataSource = dtbl2;
        GridView1.DataBind();
        GridView1.Columns[0].Visible = false;
        GridView1.Columns[2].Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
        string FileName = "Ataskaita" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;
        GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
        GridView1.Columns[0].Visible = true;
        GridView1.Columns[2].Visible = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        
        string quer = "DELETE FROM logs";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader2 = comm.ExecuteReader();
        databaseConn.Close();
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from logs";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        GridView1.DataSource = dtbl2;
        GridView1.DataBind();
    }
}