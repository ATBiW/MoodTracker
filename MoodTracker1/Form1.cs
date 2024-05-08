using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MoodTracker1
{
    public partial class Form1 : Form
    {
        // Connection string
        string connectionString = "Data Source=ATBiW;Initial Catalog=moodTracker;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void InsertMood(string mood)
        {
            // Tanggal sekarang
            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");

            // Memeriksa apakah entri dengan tanggal yang sama sudah ada
            if (EntryExistsForDate(tanggal))
            {
                MessageBox.Show("Anda hanya bisa memasukkan mood sekali sehari.");
                return;
            }

            // Query SQL untuk menyisipkan data
            string insertQuery = $"INSERT INTO MoodTracker (tanggal, mood) VALUES ('{tanggal}', '{mood}')";

            // Membuat koneksi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Membuka koneksi
                connection.Open();

                // Membuat perintah SQL
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Menjalankan perintah SQL
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} baris telah disisipkan ke dalam tabel MoodTracker!");
                }
            }
        }

        private bool EntryExistsForDate(string date)
        {
            // Query SQL untuk memeriksa apakah entri dengan tanggal yang sama sudah ada
            string checkQuery = $"SELECT COUNT(*) FROM MoodTracker WHERE tanggal = '{date}'";

            // Membuat koneksi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Membuka koneksi
                connection.Open();

                // Membuat perintah SQL
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    // Menjalankan perintah SQL dan mengambil jumlah entri
                    int count = (int)command.ExecuteScalar();

                    // Jika jumlah entri lebih dari 0, berarti entri dengan tanggal yang sama sudah ada
                    return count > 0;
                }
            }
        }

        private void UpdateLabelMood()
        {
            // Query SQL untuk menghitung jumlah masing-masing mood
            string countQuery = @"
                SELECT mood, COUNT(*) AS count
                FROM MoodTracker
                GROUP BY mood";

            // Membuat koneksi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Membuka koneksi
                connection.Open();

                // Membuat adapter dan dataset
                using (SqlDataAdapter adapter = new SqlDataAdapter(countQuery, connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    // Mengubah hasil query menjadi dictionary
                    var moodCounts = dataset.Tables[0].AsEnumerable()
                        .ToDictionary(row => row.Field<string>("mood"), row => row.Field<int>("count"));

                    // Jika tidak ada entri di tabel
                    if (moodCounts.Count == 0)
                    {
                        lblMood.Text = "Belum ada data";
                        return;
                    }

                    // Menghitung total entri
                    int totalEntries = moodCounts.Values.Sum();

                    // Mencari mood dengan persentase terbesar
                    var largestMood = moodCounts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

                    // Menghitung persentase mood terbesar
                    double largestPercentage = (double)moodCounts[largestMood] / totalEntries * 100;

                    // Menampilkan mood dengan persentase terbesar di label
                    lblMood.Text = $"{largestMood}: {largestPercentage:F2}%";
                }
            }
        }

        private void CheckAndResetData()
        {
            // Query SQL untuk menghitung jumlah entri dalam tabel
            string countEntriesQuery = "SELECT COUNT(*) FROM MoodTracker";

            // Membuat koneksi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Membuka koneksi
                connection.Open();

                // Membuat perintah SQL
                using (SqlCommand command = new SqlCommand(countEntriesQuery, connection))
                {
                    // Menjalankan perintah SQL dan mengambil jumlah entri
                    int countEntries = (int)command.ExecuteScalar();

                    // Jika jumlah entri melebihi 7 (satu minggu)
                    if (countEntries > 7)
                    {
                        // Mengurutkan entri berdasarkan tanggal secara menaik
                        string deleteQuery = @"
                            DELETE FROM MoodTracker
                            WHERE ID IN (
                                SELECT TOP (@countToDelete) ID
                                FROM MoodTracker
                                ORDER BY tanggal ASC
                            )";

                        // Membuat perintah SQL untuk menghapus entri-entri tertua
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            // Menentukan jumlah entri yang akan dihapus (total entri - 7)
                            int countToDelete = countEntries - 7;
                            deleteCommand.Parameters.AddWithValue("@countToDelete", countToDelete);

                            // Menjalankan perintah SQL untuk menghapus entri-entri tertua
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void UpdateLabelsMoodPercentage()
        {
            // Query SQL untuk menghitung jumlah masing-masing mood
            string countQuery = @"
                SELECT mood, COUNT(*) AS count
                FROM MoodTracker
                GROUP BY mood";

            // Membuat koneksi
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Membuka koneksi
                connection.Open();

                // Membuat adapter dan dataset
                using (SqlDataAdapter adapter = new SqlDataAdapter(countQuery, connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    // Mengubah hasil query menjadi dictionary
                    var moodCounts = dataset.Tables[0].AsEnumerable()
                        .ToDictionary(row => row.Field<string>("mood"), row => row.Field<int>("count"));

                    // Jika tidak ada entri di tabel
                    if (moodCounts.Count == 0)
                    {
                        lblBad.Text = "0%";
                        lblGood.Text = "0%";
                        lblVeryG.Text = "0%";
                        return;
                    }

                    // Menghitung total entri
                    int totalEntries = moodCounts.Values.Sum();

                    // Menghitung persentase masing-masing mood
                    double badPercentage = moodCounts.ContainsKey("Bad") ? (double)moodCounts["Bad"] / totalEntries * 100 : 0;
                    double goodPercentage = moodCounts.ContainsKey("Good") ? (double)moodCounts["Good"] / totalEntries * 100 : 0;
                    double veryGoodPercentage = moodCounts.ContainsKey("Very Good") ? (double)moodCounts["Very Good"] / totalEntries * 100 : 0;

                    // Menampilkan persentase masing-masing mood di label-label
                    lblBad.Text = $"{badPercentage:F2}%";
                    lblGood.Text = $"{goodPercentage:F2}%";
                    lblVeryG.Text = $"{veryGoodPercentage:F2}%";
                }
            }
        }

        private void btnBad_Click_1(object sender, EventArgs e)
        {
            InsertMood("Bad");
            UpdateLabelMood();
            CheckAndResetData();
            UpdateLabelsMoodPercentage();
        }

        private void btnGood_Click_1(object sender, EventArgs e)
        {
            InsertMood("Good");
            UpdateLabelMood();
            CheckAndResetData();
            UpdateLabelsMoodPercentage();

        }

        private void btnVeryG_Click_1(object sender, EventArgs e)
        {
            InsertMood("Very Good");
            UpdateLabelMood();
            CheckAndResetData();
            UpdateLabelsMoodPercentage();
        }
    }
}
