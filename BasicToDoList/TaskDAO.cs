using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicToDoList
{
    internal class TaskDAO
    {
        // Database connection string
        string connectionString = "Server =.; Database = To Do List; Trusted_Connection = True;";

        // Get all open tasks
        public List<Task> getOpenTasks()
        {
            // Create a List to store tasks
            List<Task> returnList = new List<Task>();

            // Create a server connection object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Connect to server and prepare SQL statement
                conn.Open();
                string sql = "select taskName, taskDescription, complete from Task where task.complete = 0;";

                // Create a SQL command object to process SQL statements
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Create a SQL reader object to read data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Read data and add to returnList
                        while (reader.Read())
                        {
                            Task a = new Task
                            {
                                TaskName = reader.GetString(0),
                                TaskDescription = reader.GetString(1),
                                Complete = reader.GetBoolean(2),
                            };

                            returnList.Add(a);
                        }
                    }
                }
                // Close connection
                conn.Close();
            }

            return returnList;
        }

        // Add new task to database
        public int addNewTask(Task newTask)
        {
            // Create a List to store tasks
            List<Task> returnList = new List<Task>();

            // Create a server connection object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Connect to server and prepare SQL statement
                conn.Open();
                string sql = "insert into Task (taskName, taskDescription) values (@taskName, @taskDescription);";

                // Create a SQL command object to process SQL statements
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Map paramters for the SQL statement
                    cmd.Parameters.AddWithValue("@taskName", newTask.TaskName);
                    cmd.Parameters.AddWithValue("@taskDescription", newTask.TaskDescription);

                    int newRows = cmd.ExecuteNonQuery();

                    // Close connection
                    conn.Close();
                    
                    return newRows;
                }
                
            }

        }
    }
}
