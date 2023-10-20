using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm_SQL_StoredProcedure
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindGrid();
			}
		}

		private void BindGrid()
		{
			// Fetch data from the SQL Server database and bind it to the GridView.
			// Use ADO.NET, Entity Framework, or any other data access method.
			// Example:
			string connectionString = "Data Source=WENG;Initial Catalog=WebForm;Integrated Security=True";
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("sp_GetRecords", con);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				GridView1.DataSource = dt;
				GridView1.DataBind();
			}
		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				// Get user input from textboxes
				int id_bl = int.Parse(txtBlId.Text);
				string consignee = txtConsignee.Text;
				string bl_Number = txtBl_Number.Text;
				string type_Bl = txtUnit.Text;

				// Insert data into the database
				using (SqlConnection connection = new SqlConnection("Data Source=WENG;Initial Catalog=WebForm;Integrated Security=True"))
				{
					connection.Open();

					SqlCommand command = new SqlCommand("sp_InsertRecord", connection);
					command.CommandType = CommandType.StoredProcedure;

					// Manually provide the ID_BL parameter
					command.Parameters.AddWithValue("@ID_BL", id_bl);
					command.Parameters.AddWithValue("@Consignee", consignee);
					command.Parameters.AddWithValue("@Bl_Number", bl_Number);
					command.Parameters.AddWithValue("@Type_Bl", type_Bl);
					command.ExecuteNonQuery();
				}

				// Clear the textboxes after successful insertion
				txtBlId.Text = string.Empty;
				txtConsignee.Text = string.Empty;
				txtBl_Number.Text = string.Empty;
				txtUnit.Text = string.Empty;

				// Refresh the GridView or perform any other UI updates
				BindGrid(); // Assuming BindGrid is a method to refresh the GridView
			}
			catch (SqlException sqlEx)
			{
				lblErrorMessage.Text = "SQL error occurred: " + sqlEx.Message;
				lblErrorMessage.Visible = true;
				// Log the exception for troubleshooting
				// You can use a logging library like Serilog or log to a file or database.
			}
			catch (Exception ex)
			{
				lblErrorMessage.Text = "An error occurred: " + ex.Message;
				lblErrorMessage.Visible = true;
				// Log the exception for troubleshooting
				// You can use a logging library like Serilog or log to a file or database.
			}
		}


		private int GetSelectedID_BL()
		{
			if (GridView1.SelectedRow != null)
			{
				int idBl;
				if (int.TryParse(GridView1.SelectedRow.Cells[0].Text, out idBl))
				{
					return idBl;
				}
			}
			return -1; // Return a default value or handle the case when no row is selected.
		}


		

		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				int idBl = int.Parse(GridView1.DataKeys[e.RowIndex].Values["ID_BL"].ToString());

				using (SqlConnection connection = new SqlConnection("Data Source=WENG;Initial Catalog=WebForm;Integrated Security=True"))
				{
					connection.Open();

					SqlCommand command = new SqlCommand("sp_DeleteRecord", connection);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@IDBl", idBl);
					command.ExecuteNonQuery();
				}

				// Refresh the GridView or any other UI updates
				BindGrid(); // Assuming BindGrid is a method to refresh the GridView
			}
			catch (SqlException sqlEx)
			{
				lblErrorMessage.Text = "SQL error occurred: " + sqlEx.Message;
				lblErrorMessage.Visible = true;
				// Log the exception for troubleshooting
				// You can use a logging library like Serilog or log to a file or database.
			}
			catch (Exception ex)
			{
				lblErrorMessage.Text = "An error occurred: " + ex.Message;
				lblErrorMessage.Visible = true;
				// Log the exception for troubleshooting
				// You can use a logging library like Serilog or log to a file or database.
			}
		}


		
		protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView1.EditIndex = e.NewEditIndex;
			BindGrid();
		}


		protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				// Check if the row is in edit mode
				if (GridView1.EditIndex == e.RowIndex)
				{
					int idBl = int.Parse(GridView1.DataKeys[e.RowIndex].Values["ID_BL"].ToString());
					string consignee = (GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox)?.Text;
					string blNumber = (GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox)?.Text;
					string typeBl = (GridView1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox)?.Text;


					// Update data in the database
					using (SqlConnection connection = new SqlConnection("Data Source=WENG;Initial Catalog=WebForm;Integrated Security=True"))
					{
						connection.Open();

						SqlCommand command = new SqlCommand("sp_UpdateRecord", connection);
						command.CommandType = CommandType.StoredProcedure;
						command.Parameters.AddWithValue("@ID_BL", idBl);
						command.Parameters.AddWithValue("@Consignee", consignee);
						command.Parameters.AddWithValue("@Bl_Number", blNumber);
						command.Parameters.AddWithValue("@Type_Bl", typeBl);
						command.ExecuteNonQuery();
					}

					// Exit edit mode and refresh the GridView
					GridView1.EditIndex = -1;
					BindGrid(); // Assuming BindGrid is a method to refresh the GridView
				}

			}
			catch (SqlException sqlEx)
			{
				lblErrorMessage.Text = "SQL error occurred: " + sqlEx.Message;
				lblErrorMessage.Visible = true;
				// Log the exception for troubleshooting
				// You can use a logging library like Serilog or log to a file or database.
			}
			catch (Exception ex)
			{
				lblErrorMessage.Text = "An error occurred: " + ex.Message;
				lblErrorMessage.Visible = true;
				// Log the exception for troubleshooting
				// You can use a logging library like Serilog or log to a file or database.
			}
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				string consignee = txtConsignee.Text;
				string blNumber = txtBl_Number.Text;
				string typeBl = txtUnit.Text;

				int idBl = GetSelectedID_BL();

				if (idBl != -1)
				{
					using (SqlConnection connection = new SqlConnection("Data Source=WENG;Initial Catalog=WebForm;Integrated Security=True"))
					{
						connection.Open();

						SqlCommand command = new SqlCommand("sp_UpdateRecord", connection);
						command.CommandType = CommandType.StoredProcedure;

						// Add the @ID_Bl parameter
						command.Parameters.AddWithValue("@ID_Bl", idBl);
						command.Parameters.AddWithValue("@Consignee", consignee);
						command.Parameters.AddWithValue("@Bl_Number", blNumber);
						command.Parameters.AddWithValue("@Type_Bl", typeBl);
						command.ExecuteNonQuery();
					}

					// Refresh the GridView or perform other UI updates
					BindGrid();
				}
				else
				{
					lblErrorMessage.Text = "No row selected or invalid selection.";
				}
			}
			catch (Exception ex)
			{
				lblErrorMessage.Text = "An error occurred: " + ex.Message;
				// Handle the exception as needed, including logging.
			}
		}


		//protected void btnUpdate_Click(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		string consignee = txtConsignee.Text;
		//		string bl_Number = txtBl_Number.Text;
		//		string type_Bl = txtUnit.Text;

		//		int idBl = GetSelectedID_BL();

		//		if (idBl != -1)
		//		{
		//			using (SqlConnection connection = new SqlConnection("Data Source=WENG;Initial Catalog=WebForm;Integrated Security=True"))
		//			{
		//				connection.Open();

		//				SqlCommand command = new SqlCommand("sp_UpdateRecord", connection);
		//				command.CommandType = CommandType.StoredProcedure;
		//				command.Parameters.AddWithValue("@ID_Bl", idBl);
		//				command.Parameters.AddWithValue("@Consignee", consignee);
		//				command.Parameters.AddWithValue("@Bl_Number", bl_Number);
		//				command.Parameters.AddWithValue("@Type_Bl", type_Bl);
		//				command.ExecuteNonQuery();
		//			}

		//			// Refresh the GridView or perform other UI updates
		//			BindGrid();
		//		}
		//		else
		//		{
		//			lblErrorMessage.Text = "No row selected or invalid selection.";
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		lblErrorMessage.Text = "An error occurred: " + ex.Message;
		//		// Handle the exception as needed, including logging.
		//	}
		//}


	}
}

