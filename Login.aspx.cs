using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    string userid = "";
    string id, vardas;
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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select UserID from accounts Where Username = '" + TextBox2.Text + "'";
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        id = dtbl.Rows[0]["UserID"].ToString();
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select Vardas from users Where paskyra = '" + id + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
        vardas = dtbl2.Rows[0]["Vardas"].ToString();
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + id + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + vardas + "', '" + "Paspaustas prisijungimo mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader = comm.ExecuteReader();
        databaseConn.Close();
        MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
          con.Open();
          MySqlCommand cmd = new MySqlCommand("select COUNT(*)FROM accounts WHERE Username='" + TextBox2.Text + "' and Password='" + Hash(TextBox3.Text) + "' and Priv='" + "ADMIN" + "'");
          cmd.Connection = con;
          int OBJ = Convert.ToInt32(cmd.ExecuteScalar());
        captcha1.ValidateCaptcha(TextBox4.Text);
        if (OBJ > 0 && captcha1.UserValidated)
          {
              Session["name"] = TextBox2.Text;
              Label5.Text = "valid";
              Response.Redirect("Pagrindinis.aspx");
          }
          else
          {
              Label5.Text = "error";
              TextBox2.Text = "";
              TextBox3.Text = "";
              TextBox4.Text = "";
        }
          con.Close();
    /*    MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select * from accounts Where Username = '" + TextBox2.Text.Trim() + "' and Password = '" + TextBox3.Text.Trim() + "'";
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
        var lygis = dtbl.AsEnumerable().Select(r => r.Field<string>("Priv")).ToArray();
        Label5.Text = lygis.ToString();*/

    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        MySqlConnection sqlcon = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query = "Select UserID from accounts Where Username = '" + TextBox2.Text + "'";
        MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlcon);
        DataTable dtbl = new DataTable();
        sda.Fill(dtbl);
      //  id = dtbl.Rows[0]["UserID"].ToString();
        MySqlConnection sqlcon2 = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        string query2 = "Select Vardas from users Where paskyra = '" + id + "'";
        MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, sqlcon2);
        DataTable dtbl2 = new DataTable();
        sda2.Fill(dtbl2);
   //     vardas = dtbl2.Rows[0]["Vardas"].ToString();
        string quer = "INSERT INTO logs(`LogID`, `userid`, `date`, `vardas`, `action`) VALUES (NULL, '" + "-" + "', '" + DateTime.Now.ToString("yyyy-MM-dd-") + "', '" + "-" + "', '" + "Paspaustas registracijos mygtukas" + "')";
        MySqlConnection databaseConn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=db");
        MySqlCommand comm = new MySqlCommand(quer, databaseConn);
        databaseConn.Open();
        MySqlDataReader myReader = comm.ExecuteReader();
        databaseConn.Close();
        Response.Redirect("Register.aspx");
    }
}
