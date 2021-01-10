using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

public partial class Accounts : System.Web.UI.Page
{
    string id = "0";
    string userid;
    string vardas, kodas;
    double result;
    static string Hash(string input)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                // can be "x2" if you want lowercase
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Button2.Enabled = false;
        Button3.Enabled = false;
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select * from accounts";
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string vardas = "", pavarde = "", privilegijos = "";
        if (GridView1.SelectedRow.Cells[1].Text != "0")
        {
            Button2.Enabled = true;
            Button3.Enabled = true;
            this.DropDownList2.SelectedItem.Text = GridView1.SelectedRow.Cells[4].Text;
            MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query2 = "Select * from accounts Where UserID = '" + GridView1.SelectedRow.Cells[1].Text + "'";
            MySqlCommand cmd = new MySqlCommand(query2, sqlcon2);
            MySqlDataAdapter sda = new MySqlDataAdapter(query2, sqlcon2);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            sqlcon2.Open();
            cmd.ExecuteNonQuery();
            sqlcon2.Close();
            if (dtbl.Rows.Count > 0)
            {
                vardas = dtbl.Rows[0]["Username"].ToString();
                pavarde = dtbl.Rows[0]["Password"].ToString();
                privilegijos = dtbl.Rows[0]["Priv"].ToString();
            }
            TextBox3.Text = vardas;
            TextBox4.Text = pavarde;
            if (this.DropDownList2.SelectedItem.Text == privilegijos)
            {

            }
        }
        else
        {
            Button2.Enabled = false;
            Button3.Enabled = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query13 = "Select UserID from accounts Where Username = '" + Session["name"] + "'"; //pakeist i Session["name"]
        MySqlDataAdapter sda3 = new MySqlDataAdapter(query13, sqlcon3);
        DataTable dtbl3 = new DataTable();
        sda3.Fill(dtbl3);
        kodas = dtbl3.Rows[0]["UserID"].ToString();
        MySqlConnection sqlcon12 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query4 = "Select Vardas from users Where paskyra = '" + kodas + "'";
        MySqlDataAdapter sda12 = new MySqlDataAdapter(query4, sqlcon12);
        DataTable dtbl12 = new DataTable();
        sda12.Fill(dtbl12);
        vardas = dtbl12.Rows[0]["Vardas"].ToString();
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + kodas + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + vardas + "', '" + "Paspaustas įrašo sukurimo mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader2 = comm.ExecuteReader();
        databaseConn.Close();
        int error = 0;
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select * from accounts Where Username = '" + TextBox1.Text + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query3, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        string statusas = this.DropDownList1.SelectedItem.Text;
        if (dtbl2.Rows.Count != 0)
        {
            error = 1;
        }
        if (TextBox1.Text != "" || TextBox2.Text != "" || TextBox9.Text != "" || TextBox10.Text != "")
            {
                if (statusas == "ADMIN" || statusas == "USER" || statusas == "FIXER")
                {
                if (error == 0)
                {
                    string query = "INSERT INTO accounts(`UserID`, `Username`, `Password`, `Priv`) VALUES (NULL, '" + TextBox1.Text + "', '" + Hash(TextBox2.Text) + "', '" + statusas + "')";
                    MySqlConnection databaseConnection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    try
                    {
                        databaseConnection.Open();
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                        databaseConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = (ex.Message);
                    }
                    MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                    using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(UserID) FROM accounts", con))
                    {
                        con.Open();
                        result = (Convert.ToDouble(cmd.ExecuteScalar()));
                    }
                    string query2 = "INSERT INTO users(`UserID`, `Vardas`, `Pavarde`, `Privilegijos`, `paskyra`) VALUES (NULL, '" + TextBox9.Text + "', '" + TextBox10.Text + "', '" + statusas + "', '" + result + "')";
                    MySqlConnection databaseConnection2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                    MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                    commandDatabase2.CommandTimeout = 60;
                    try
                    {
                        databaseConnection2.Open();
                        MySqlDataReader myReader = commandDatabase2.ExecuteReader();
                        Label1.Text = "Sukure";
                        databaseConnection.Close();
                        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
                        string query89 = "Select * from accounts";
                        MySqlDataAdapter sda = new MySqlDataAdapter(query89, sqlcon);
                        DataTable dtbl = new DataTable();
                        sda.Fill(dtbl);
                        GridView1.DataSource = dtbl;
                        GridView1.DataBind();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = (ex.Message);
                    }
                }
                else
                {
                    Label1.Text = "Slapyvardis užimtas";
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'"; //pakeist i session
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
        string query4 = "update accounts set Priv='" + this.DropDownList2.SelectedItem.Text + "',Username='" + TextBox3.Text + "',Password='" + Hash(TextBox4.Text) + "' where UserID='" + GridView1.SelectedRow.Cells[1].Text + "';";
        MySqlConnection databaseConnection3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand commandDatabase3 = new MySqlCommand(query4, databaseConnection3);
        commandDatabase3.CommandTimeout = 60;
        try
        {
            databaseConnection3.Open();
            MySqlDataReader myReader3 = commandDatabase3.ExecuteReader();
            Label4.Text = "Duomenys atnaujinti";
            MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
            string query = "Select * from accounts";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            TextBox4.Text = "";
            TextBox3.Text = "";
            TextBox8.Text = "";
            TextBox8.Text = "";
        }
        catch (Exception ex)
        {
            Label4.Text = (ex.Message);
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        MySqlConnection sqlcon3 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query3 = "Select UserID from accounts Where Username = '" + Session["name"] + "'"; //pakeist i session
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
        string query2 = "DELETE FROM `accounts` WHERE `accounts`.`UserID` = '" + id + "';";
        MySqlCommand cmd = new MySqlCommand(query2, sqlcon2);
        sqlcon2.Open();
        cmd.ExecuteNonQuery();
        sqlcon2.Close();
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select * from accounts";
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        GridView1.DataSource = dtbl;
        GridView1.DataBind();
        TextBox4.Text = "";
        TextBox3.Text = "";
        TextBox8.Text = "";
        TextBox8.Text = "";
    }

    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select * from accounts";
        MySqlDataAdapter sda = new MySqlDataAdapter(query2, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        var tblFiltered = (from row in dtbl.AsEnumerable()
                           where row.Field<String>("Username").Contains(TextBox8.Text)
                           select row).CopyToDataTable();
        GridView1.DataSource = tblFiltered;
        GridView1.DataBind();
    }
}