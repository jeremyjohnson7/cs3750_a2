using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dots : System.Web.UI.Page {
    //The connenction string for the database
    private string connectionString = "Data Source=titan.cs.weber.edu,10433;Initial Catalog=W0114267;User ID=w0114267;Password='C7Q3V4;lkj'";

    /// <summary>
    /// Gets parseable output for the dots in the database
    /// </summary>
    /// <returns>All the dots in the database</returns>
    public string GetDots() {
        string sql = "SELECT DISTINCT x_coord, y_coord FROM dots;";
        List<string> dots = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString)) {
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                dots.Add((int)reader["x_coord"] + " " + (int)reader["y_coord"]);
        }

        return string.Join("\n", dots);
    }

    /// <summary>
    /// Inserts a dot into the database at the point specified
    /// </summary>
    /// <param name="x">The x coordinate</param>
    /// <param name="y">The y coordinate</param>
    /// <returns>The number of rows affected (should be 1)</returns>
    public int AddDot(int x, int y) {
        string sql = "INSERT INTO dots (x_coord, y_coord) VALUES ('" + x + "', '" + y + "');";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(connectionString)) {
            SqlCommand command = new SqlCommand(sql, connection);
            command.Connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }

        return rowsAffected;
    }

    /// <summary>
    /// Deletes all dots from the database
    /// </summary>
    /// <returns>The number of rows affected</returns>
    public int ClearDots() {
        string sql = "DELETE FROM dots WHERE dot_id IS NOT NULL;";
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(connectionString)) {
            SqlCommand command = new SqlCommand(sql, connection);
            command.Connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }

        return rowsAffected;
    }
}