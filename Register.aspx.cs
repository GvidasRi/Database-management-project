using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page
{
    string db = "Server=kursinis-db.mysql.database.azure.com; Port=3306; Database=db; Uid=rooot@kursinis-db; Pwd=Rootroot1; SslMode=Preferred;";
    int pass = 0;
    string name = "";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection("db");
        con.Open();
        
        captcha1.ValidateCaptcha(TextBox6.Text.Trim());
        if (captcha1.UserValidated)
        {
            MySqlCommand cmd = new MySqlCommand("insert into accounts values(@a,@b,@c,@d)", con);
            cmd.Parameters.AddWithValue("a", "");
            cmd.Parameters.AddWithValue("b", TextBox1.Text);
            cmd.Parameters.AddWithValue("c", Hash(TextBox2.Text));
            cmd.Parameters.AddWithValue("d", "ADMIN"); //ADMIN padaryta del testavimo priezasciu, kad galetu prisijungt. Paprastai naudotoja uzregistruoja USER lygiu
            cmd.ExecuteNonQuery();
            string query = "Select * from accounts Where Username = '" + TextBox1.Text.Trim() + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count > 0)
            {
                name = dtbl.Rows[0]["UserID"].ToString();
            }
            MySqlCommand cmd2 = new MySqlCommand("insert into users values(@a,@b,@c,@d,@e)", con);
            cmd2.Parameters.AddWithValue("a", "");
            cmd2.Parameters.AddWithValue("b", TextBox4.Text);
            cmd2.Parameters.AddWithValue("c", TextBox5.Text);
            cmd2.Parameters.AddWithValue("d", "ADMIN");
            cmd2.Parameters.AddWithValue("e", name);
            cmd2.ExecuteNonQuery();
            //Session["name"] = TextBox1.Text;
            //  Response.Redirect("default.aspx");
        }
        else
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "You have Entered InValid Captcha Characters please Enter again";
        }
        con.Close();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
