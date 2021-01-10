using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Pagrindinis : System.Web.UI.Page
{
    string userid = "";
    string notes = "";
    string text, date;
    string kodas, vardas;
    int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlConnection sqlcon4 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query4 = "Select * from uzrasai";
        MySqlDataAdapter sda4 = new MySqlDataAdapter(query4, sqlcon4);
        DataTable dtbl4 = new DataTable();
        sda4.Fill(dtbl4);
        /*count = dtbl4.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            GridView1.Columns.Add = dtbl4.Rows[i]["text"].ToString() + "\n" + text;
            date = dtbl4.Rows[i]["data"].ToString() + "\n" + date;
        }*/
        //TextBox1.Text = text + " " + date;
        GridView1.DataSource = dtbl4;
        GridView1.DataBind();
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'";
        MySqlCommand cmd3 = new MySqlCommand(query3, sqlcon3);
        MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, sqlcon3);
        DataTable dtbl3 = new DataTable();
        sda3.Fill(dtbl3);
        sqlcon3.Open();
        cmd3.ExecuteNonQuery();
        sqlcon3.Close();
        if (dtbl3.Rows.Count > 0)
        {
            userid = dtbl3.Rows[0]["UserID"].ToString();
        }

        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select * from tickets";
        MySqlCommand cmd = new MySqlCommand(query, sqlcon);
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        sqlcon.Open();
        cmd.ExecuteNonQuery();
        sqlcon.Close();
        int tickets = dtbl.Rows.Count;
        Label1.Text = tickets.ToString();
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from accounts";
        MySqlCommand cmd2 = new MySqlCommand(query2, sqlcon2);
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        sqlcon2.Open();
        cmd2.ExecuteNonQuery();
        sqlcon2.Close();
        int accounts = dtbl2.Rows.Count;
        Label2.Text = accounts.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'";
        MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, sqlcon3);
        DataTable dtbl3 = new DataTable();
        sda3.Fill(dtbl3);
        kodas = dtbl3.Rows[0]["UserID"].ToString();
        MySqlConnection sqlcon8 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query4 = "Select Vardas from users Where paskyra = '" + kodas + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query4, sqlcon8);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        vardas = dtbl2.Rows[0]["Vardas"].ToString();
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + kodas + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + vardas + "', '" + "Paspaustas užrašo patvirtinimo mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader2 = comm.ExecuteReader();
        databaseConn.Close();
        if (TextBox1.Text != "")
        {
            string query = "INSERT INTO uzrasai(`text`, `user`) VALUES ('" + TextBox1.Text + "', '" + userid + "')";
            MySqlConnection databaseConnection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                Label3.Text = "Sukure";
                databaseConnection.Close();
                MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                string query2 = "Select * from uzrasai";
                MySqlDataAdapter sda = new MySqlDataAdapter(query2, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label3.Text = (ex.Message);
            }
        }
        else
        {
            Label3.Text = "Teksto langas negali būti tuščias";
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "DELETE FROM `uzrasai` WHERE `uzrasai`.`noteID` = '" + GridView1.SelectedRow.Cells[1].Text + "';";
        MySqlCommand cmd = new MySqlCommand(query2, sqlcon2);
        sqlcon2.Open();
        cmd.ExecuteNonQuery();
        sqlcon2.Close();
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select * from uzrasai";
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
    }
}