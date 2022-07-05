# Dot_Net

SqlCommand comm = new SqlCommand("select id,(AVG(bangla)+AVG(english)+AVG(math))/3 as average from student_info group by id", con);


//connecting ....>>>>> SqlConnection con = new SqlConnection("Data Source=SHAON;Initial Catalog=dataEdge;Integrated Security=True");



protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand comm = new SqlCommand("insert into student_info values('"+TextBoxFname.Text+"', '"+TextBoxLname.Text+"', '"+int.Parse(TextBoxID.Text)+"', '"+double.Parse(TextBoxBangla.Text)+"', '"+double.Parse(TextBoxEnglish.Text)+"', '"+double.Parse(TextBoxMath.Text)+"' )" ,con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert ('sucessfully Inserted');", true);
            loadRecord();
        }
        
        
       --------------------------------------------------------------------------------------------
        
        
        
         protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("update studentMarks set name= '" + TextBoxName.Text + "', bangla = '" + double.Parse(TextBoxBangla.Text) + "', english= '" + double.Parse(TextBoxEnglish.Text) + "' , math= '" + double.Parse(TextBoxMath.Text) + "' where id = '" + int.Parse(TextBoxID.Text)+"'  ", con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert ('sucessfully Updated');", true);
            loadRecord();

        }
-----------------------------------------------------------------------------------------------
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("delete studentMarks where id= '"+int.Parse(TextBoxID.Text)+"' ",con);
            comm.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert ('deleted');", true);
            loadRecord();

        }
-----------------------------------------------------------------------------------------------------------------
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
-------------------------------------------------------------------------------
AVERAGE ..>>>>


SqlCommand comm = new SqlCommand("select id,(AVG(bangla)+AVG(english)+AVG(math))/3 as average from student_info group by id", con);
