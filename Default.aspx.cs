﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string cn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        using (SqlConnection connection = new SqlConnection(cn))
        {
            SqlCommand command = new SqlCommand("Search", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductName", product_nm);
            command.Parameters.AddWithValue("@Size", size);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@MfgDate", mfgdate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Category", category);
            command.Parameters.AddWithValue("@Conjunction", conjunction);

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);
            GridView1.DataBind();

        //GridView1.DataSource = ExecuteSearchProcedure(productName, size, price, mfgDate, category, conjunction);
        }
        
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        product_nm.Text = string.Empty;
        size.Text = string.Empty;
        price.Text = string.Empty;
        mfgdate.Text = string.Empty;
        category.Text = string.Empty;
        conjunction.Value = "AND";

        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    //private DataTable ExecuteSearchProcedure(string productName, string size, string price, DateTime? mfgDate, string category, string conjunction)
    //{
    //    string cn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


    //    using (SqlConnection connection = new SqlConnection(cn))
    //    {
    //        SqlCommand command = new SqlCommand("Search", connection);
    //        command.CommandType = CommandType.StoredProcedure;

    //        command.Parameters.AddWithValue("@ProductName", productName);
    //        command.Parameters.AddWithValue("@Size", size);
    //        command.Parameters.AddWithValue("@Price", price);
    //        command.Parameters.AddWithValue("@MfgDate", mfgDate ?? (object)DBNull.Value);
    //        command.Parameters.AddWithValue("@Category", category);
    //        command.Parameters.AddWithValue("@Conjunction", conjunction);

    //        connection.Open();
    //        SqlDataAdapter adapter = new SqlDataAdapter(command);
    //        DataTable dataTable = new DataTable();
    //        adapter.Fill(dataTable);

    //        return dataTable;
    //    }
    //}

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        using (SqlConnection connection = new SqlConnection(cn))
        {
            SqlCommand command = new SqlCommand("Search", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductName", product_nm);
            command.Parameters.AddWithValue("@Size", size);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@MfgDate", mfgdate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Category", category);
            command.Parameters.AddWithValue("@Conjunction", conjunction);

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridView1.DataBind();
            //return dataTable;
        }
    }
}