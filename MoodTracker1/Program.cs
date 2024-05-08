using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MoodTracker1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Connection string
            string connectionString = "Data Source=ATBiW;Initial Catalog=moodTracker;Integrated Security=True";

            // Membuat koneksi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Membuka koneksi
                connection.Open();

               
            }
        }
    }
}
