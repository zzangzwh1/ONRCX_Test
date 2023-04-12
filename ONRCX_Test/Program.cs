using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ONRCX_Test
{
    class Program
    {
        // Connection string for the SQL Server database
        public static string connectionString = "Data Source=(localdb)\\Local;Initial Catalog=ONRCX;Integrated Security=True";
        static void Main(string[] args)
        {
            Console.WriteLine($"1. how much orders was placed on 2023-01-02 : ");
            FirstQuestion();
            Console.WriteLine();
            Console.WriteLine($"-----------------------------------------------------------");

            Console.WriteLine($"2. From which countries the order was placed on 2023-01-02 : ");
            SecondQuestion();
            Console.WriteLine();
            Console.WriteLine($"-----------------------------------------------------------");

            Console.WriteLine($"3. Who order on  2023-01-02 : ");

            ThirdQuestion();
            Console.ReadLine();
        }
        #region First Quesion
        /// <summary>
        /// 1 how much orders was placed on 2023-01-02
        /// </summary>
        public static void FirstQuestion()
        {
            //query for question 1
            string query = "select * from Orders where Date = '2023-01-02' ";
            //how many item ordered
            int count = 0;
            //total amount paid
            int totalAmount = 0;
            // Create a new SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection to the database
                connection.Open();

                // Create a new SqlCommand object with the SQL query and SqlConnection object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the rows returned by the query
                        while (reader.Read())
                        {
                            // Get the values of the columns in the current row
                            int id = reader.GetInt32(0);
                            int customerId = reader.GetInt32(1);
                            DateTime date = reader.GetDateTime(2);

                            //convert to string only Year/Month/Date
                            string yearAndDay = date.ToString("yyyy-MM-dd");
                            int amount = reader.GetInt32(3);
                            //count for totalCount
                            ++count;
                            totalAmount += amount;

                            // Display the values in the console
                            Console.WriteLine($"ID: {id}, CustomerID: {customerId}, Date: {yearAndDay}, Amount : {amount} ");
                        }
                    }
                }
            }
            //total count 
            Console.WriteLine($"Total Order : {count } ");
            Console.WriteLine($"Total Amount : ${totalAmount}");
        }
        #endregion

        #region Second Question
        /// <summary>
        /// 2. From which countries the order was placed on “2023-01-02”
        /// </summary>
        public static void SecondQuestion()
        {
            //query for question 2
            string query = "select c.County, o.date from Customer c left join Orders o on c.id = o.CustomerId where o.date = '2023-01-02' ";
    
            // Create a new SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection to the database
                connection.Open();

                // Create a new SqlCommand object with the SQL query and SqlConnection object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the rows returned by the query
                        while (reader.Read())
                        {
                            // Get the values of the columns in the current row
                    
                            string country = reader.GetString(0);
                            DateTime date = reader.GetDateTime(1);
                            //convert to string only Year/Month/Date
                            string yearAndDay = date.ToString("yyyy-MM-dd");                         
                         
                            // Display the values in the console
                            Console.WriteLine($" Country : {country}, Date: {yearAndDay} ");
                        }
                    }
                }
            }
        }
        #endregion

        #region Third Question
        /// <summary>
        /// 3 Who order on “2023-01-02”
        /// </summary>
        public static void ThirdQuestion()
        {
            //query for question 3
            string query = "select c.name , o.date from Customer c left join Orders o on c.id = o.CustomerId where o.date = '2023-01-02' ";

            // Create a new SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection to the database
                connection.Open();

                // Create a new SqlCommand object with the SQL query and SqlConnection object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the rows returned by the query
                        while (reader.Read())
                        {
                            // Get the values of the columns in the current row

                            string name = reader.GetString(0);
                            DateTime date = reader.GetDateTime(1);
                            //convert to string only Year/Month/Date
                            string yearAndDay = date.ToString("yyyy-MM-dd");

                            // Display the values in the console
                            Console.WriteLine($" Name : {name}, Date: {yearAndDay} ");
                        }
                    }
                }
            }
        }

        #endregion

    }
}
