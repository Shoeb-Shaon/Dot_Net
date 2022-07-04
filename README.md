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
