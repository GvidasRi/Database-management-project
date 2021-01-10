using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;



public partial class Main : System.Web.UI.Page
    {
        string user;
        string userid;
        string paskyra;
        string id = "0";
    string vardas, kodas;
        int check = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
       // Label4.Text = Session["name"].ToString(); //session name issaugo username kai prisijungiama ir naudojamas kituose programos vietuose
        Button2.Enabled = false;
        Button3.Enabled = false;
        //           user = Session["name"].ToString();
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query = "Select UserID from accounts Where Username = '" + Session["name"] + "'";//pakeist i Session["name"]
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon); 
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

        if (dtbl.Rows.Count > 0)
        {
            userid = dtbl.Rows[0]["UserID"].ToString();
        }
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from tickets";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        GridView1.DataSource = dtbl2;
        GridView1.DataBind();
        // Label1.Text = userid.ToString();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'"; //pakeist i Session["name"]
        MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, sqlcon3);
        DataTable dtbl3 = new DataTable();
        sda3.Fill(dtbl3);
        kodas = dtbl3.Rows[0]["UserID"].ToString();
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query4 = "Select Vardas from users Where paskyra = '" + kodas + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query4, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        vardas = dtbl2.Rows[0]["Vardas"].ToString();
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + kodas + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + vardas + "', '" + "Paspaustas įrašo sukurimo mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader2 = comm.ExecuteReader();
        databaseConn.Close();
        string statusas = this.DropDownList1.SelectedItem.Text;
        if (TextBox1.Text != "" || TextBox2.Text != "")
        {
            if (statusas == "Aukštas" || statusas == "Vidutinis" || statusas == "Žemas")
            {
                string query = "INSERT INTO tickets(`TicketID`, `user`, `statusas`, `data`, `priority`, `projektas`, `problema`) VALUES (NULL, '" + userid + "', '" + "Nesutvarkyta" + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + statusas + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "')";
                MySqlConnection databaseConnection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    Label1.Text = "Sukure";
                    databaseConnection.Close();
                    MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                    string query2 = "Select * from tickets";
                    MySqlDataAdapter sda = new MySqlDataAdapter(query2, sqlcon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    GridView1.DataSource = dtbl;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Label1.Text = (ex.Message);
                }
            }
            else
            {
                Label1.Text = "Pasirinkite klaidos svarbumą iš duotų pasirinkimų";
            }
        }
        else
        {
            Label1.Text = "Negali būti tuščių langelių";
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow.Cells[1].Text != "0")
        {
            string vardas = "", pavarde = "", privilegijos = "", statusas = "";
            Button2.Enabled = true;
            Button3.Enabled = true;
            TextBox3.Text = GridView1.SelectedRow.Cells[6].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[7].Text;
            this.DropDownList2.SelectedItem.Text = GridView1.SelectedRow.Cells[5].Text;
            this.DropDownList3.SelectedItem.Text = GridView1.SelectedRow.Cells[3].Text;
            MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query2 = "Select * from users Where paskyra = '" + GridView1.SelectedRow.Cells[2].Text + "'";
            MySqlCommand cmd = new MySqlCommand(query2, sqlcon2);
            MySqlDataAdapter sda = new MySqlDataAdapter(query2, sqlcon2);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            sqlcon2.Open();
            cmd.ExecuteNonQuery();
            sqlcon2.Close();
            if (dtbl.Rows.Count > 0)
            {
                vardas = dtbl.Rows[0]["Vardas"].ToString();
                pavarde = dtbl.Rows[0]["Pavarde"].ToString();
                privilegijos = dtbl.Rows[0]["Privilegijos"].ToString();
            }
            TextBox5.Text = vardas;
            TextBox6.Text = pavarde;
            TextBox7.Text = privilegijos;
            TextBox8.Text = "";

        }
        else
        {
            Button2.Enabled = false;
            Button3.Enabled = false;
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'"; //pakeist i Session["name"]
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
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + kodas + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + vardas + "', '" + "Paspaustas įrašo ištrinimo mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader2 = comm.ExecuteReader();
        databaseConn.Close();
        id = GridView1.SelectedRow.Cells[1].Text;
            MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query2 = "DELETE FROM `tickets` WHERE `tickets`.`TicketID` = '" + id + "';";
            MySqlCommand cmd = new MySqlCommand(query2, sqlcon2);
            sqlcon2.Open();
            cmd.ExecuteNonQuery();
            sqlcon2.Close();
            MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query = "Select * from tickets";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        TextBox4.Text = "";
        TextBox3.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox8.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'"; //pakeist i Session["name"]
        MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, sqlcon3);
        DataTable dtbl3 = new DataTable();
        sda3.Fill(dtbl3);
        kodas = dtbl3.Rows[0]["UserID"].ToString();
        MySqlConnection sqlcon8 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query8 = "Select Vardas from users Where paskyra = '" + kodas + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query8, sqlcon8);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        vardas = dtbl2.Rows[0]["Vardas"].ToString();
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + kodas + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + vardas + "', '" + "Paspaustas įrašo atnaujinimo mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader2 = comm.ExecuteReader();
        databaseConn.Close();
        string query4 = "update tickets set statusas='" + this.DropDownList3.SelectedItem.Text + "',priority='" + this.DropDownList2.SelectedItem.Text + "',projektas='" + TextBox3.Text + "',problema='" + TextBox4.Text + "' where TicketID='" + GridView1.SelectedRow.Cells[1].Text + "';";
        MySqlConnection databaseConnection3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand commandDatabase3 = new MySqlCommand(query4, databaseConnection3);
        commandDatabase3.CommandTimeout = 60;
        try
        {
            databaseConnection3.Open();
            MySqlDataReader myReader3 = commandDatabase3.ExecuteReader();
            Label4.Text = "Duomenys atnaujinti";
            MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query = "Select * from tickets";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            TextBox4.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox8.Text = "";
        }
        catch (Exception ex)
        {
            Label4.Text = (ex.Message);
        }
    }

    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        //string _value = TextBox8.Text;
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from tickets";
        MySqlDataAdapter sda = new MySqlDataAdapter(query2, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        var tblFiltered = (from row in dtbl.AsEnumerable()
                           where row.Field<String>("projektas").Contains(TextBox8.Text)
                           select row).CopyToDataTable();
        GridView1.DataSource = tblFiltered;
        GridView1.DataBind();
    }
}