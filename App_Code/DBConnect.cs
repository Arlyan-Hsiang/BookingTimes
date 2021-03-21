using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Summary description for dbConnect
/// </summary>
public class dbConnect
{
    SqlConnection dataConnection = new SqlConnection();
    //Connection Figuration
    public void dataconn()
    {
        string strconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        dataConnection = new SqlConnection(strconn);
    }
    //insert datarow
    public void insertTable(int id, string name)
    {
        dataconn();
        StringBuilder sql = new StringBuilder();
        //insert table
        sql.Append("INSERT INTO CLIENT (Id, Name) VALUES(  ");
        sql.Append("'" + id + "', '" + name + "' ); ");
        SqlCommand mySqlCmd = new SqlCommand(sql.ToString(), dataConnection);
        try
        {
            dataConnection.Open();
            mySqlCmd.ExecuteNonQuery();
            MessageBox.Show("Data is added Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            if (dataConnection.State == ConnectionState.Open)
            {
                dataConnection.Close();
            }
        }
    }
    //create client table
    public void createTable()
    {
        dataconn();
        StringBuilder sql = new StringBuilder();
        //create table
        sql.Append("IF NOT EXISTS ( SELECT * FROM CLIENT )  ");
        sql.Append("  CREATE TABLE CLIENT ( ");
        sql.Append("    ID INT NOT NULL,  ");
        sql.Append("    NAME VARCHAR (50) NOT NULL, ");
        sql.Append("    PRIMARY KEY (ID) );");
        SqlCommand mySqlCmd = new SqlCommand(sql.ToString(), dataConnection);
        try
        {
            dataConnection.Open();
            mySqlCmd.ExecuteNonQuery();
            MessageBox.Show("Datatable is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            if (dataConnection.State == ConnectionState.Open)
            {
                dataConnection.Close();
            }
        }
    }
}