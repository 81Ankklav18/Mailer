using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MailerApp
{
    /// <summary>
    /// Summary description for MailerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MailerService : System.Web.Services.WebService
    {
        static private string log_in;
        private string password;
        static private SqlConnection con = new SqlConnection();

        //Создание сессии
        [WebMethod]
        public void Connect(string login, string password)
        {
            log_in = login;
            this.password = password;

            con = new SqlConnection("Server=localhost\\sqlexpress; Database=sqlbase; Integrated Security=SSPI; User=localhost\\" + log_in + ";Password=" + password + ";");
        }

        //Выборка всех данных из базы данных по типу письма
        [WebMethod]
        public DataTable GetData(string selectedItem)
        {
            if (selectedItem == "Исходящие")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from dbo.Messages where sender = '" + log_in + "'";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Messages");
                da.Fill(dt);
                con.Close();

                return dt;
            }
            else if (selectedItem == "Входящие")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from dbo.Messages where addressee = '" + log_in + "'";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Messages");
                da.Fill(dt);
                con.Close();

                return dt;
            }
            else
            {
                return null;
            }
        }

        //Обнуление данных текущей сессии
        [WebMethod]
        public void LogOut()
        {
            log_in = "";
            this.password = "";
        }

        //Добавление информации о письме в базу данных
        [WebMethod]
        public void CreateMessage(string message_name, string addressee, string tags, string message)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[Messages]"+
           "(message_name"+
           ",registration_date" +
           ",addressee"+
           ",sender"+
           ",tags"+
           ",message)"+
            "VALUES"+
           "(@message_name, @registration_date, @addressee,  @sender, @tags, @message)";
            cmd.Connection = con;
            cmd.Parameters.Add("@message_name", System.Data.SqlDbType.NChar);
            cmd.Parameters.Add("@registration_date", System.Data.SqlDbType.DateTime);
            cmd.Parameters.Add("@addressee", System.Data.SqlDbType.NChar);
            cmd.Parameters.Add("@sender", System.Data.SqlDbType.NChar);
            cmd.Parameters.Add("@tags", System.Data.SqlDbType.NChar);
            cmd.Parameters.Add("@message", System.Data.SqlDbType.NChar);

            cmd.Parameters["@message_name"].Value = message_name;
            cmd.Parameters["@registration_date"].Value = DateTime.Now;
            cmd.Parameters["@addressee"].Value = addressee;
            cmd.Parameters["@sender"].Value = log_in;
            cmd.Parameters["@tags"].Value = tags;
            cmd.Parameters["@message"].Value = message;
            
            con.Open();
            int RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }

        //Создание логина и пользователя в SQL Server
        [WebMethod]
        public void Registration(string login, string password)
        {
            con = new SqlConnection("Server=localhost\\sqlexpress; Initial Catalog=sqlbase; Integrated Security=True;");
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();

            cmd1.CommandText = "create login "+login+" with password = '" + password +"';";
            cmd1.Connection = con;

            cmd2.CommandText = "create user " + login + " for login " + login;
            cmd2.Connection = con;

            con.Open();
            int RowsAffected1 = cmd1.ExecuteNonQuery();
            int RowsAffected2 = cmd2.ExecuteNonQuery();
            con.Close();
        }

        //Получение текста сообщения
        [WebMethod]
        public String GetMessage(string selectedItem, int message_id)
        {
            string message = "";

            if (selectedItem == "Исходящие")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from dbo.Messages where sender = '" + log_in + "' and message_id = " + message_id;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Messages");
                da.Fill(ds);
                con.Close();
                message = ds.Tables[0].Rows[0]["message"].ToString();

                return message;
            }
            else if (selectedItem == "Входящие")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from dbo.Messages where addressee = '" + log_in + "' and message_id = " + message_id;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Messages");
                da.Fill(ds);
                con.Close();
                message = ds.Tables[0].Rows[0]["message"].ToString();
                return message;
            }
            else
            {
                return null;
            }
        }
    }
}
