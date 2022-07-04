using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentGradeSheet
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadRecord();
            }

        }
        SqlConnection con = new SqlConnection("Data Source=SHAON;Initial Catalog=studentGradeSheet;Integrated Security=True");
        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("insert into studentMarks values ('" + TextBoxName.Text + "', '" + int.Parse(TextBoxID.Text) + "','" + DropDownList1.SelectedValue + "','" + double.Parse(TextBoxBangla.Text) + "','" + double.Parse(TextBoxEnglish.Text) + "','" + double.Parse(TextBoxMath.Text)+"')",con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert ('sucessfully Inserted');", true);
            loadRecord();   
        }

        void loadRecord()
        {
            SqlCommand comm = new SqlCommand("select * from studentMarks", con);
            SqlDataAdapter d = new SqlDataAdapter(comm); 
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("update studentMarks set name= '" + TextBoxName.Text + "', bangla = '" + double.Parse(TextBoxBangla.Text) + "', english= '" + double.Parse(TextBoxEnglish.Text) + "' , math= '" + double.Parse(TextBoxMath.Text) + "' where id = '" + int.Parse(TextBoxID.Text)+"'  ", con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert ('sucessfully Updated');", true);
            loadRecord();

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("delete studentMarks where id= '"+int.Parse(TextBoxID.Text)+"' ",con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert ('deleted');", true);
            loadRecord();

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * from studentMarks where id= '"+int.Parse(TextBoxID.Text)+"' ", con);
            SqlDataAdapter d = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}