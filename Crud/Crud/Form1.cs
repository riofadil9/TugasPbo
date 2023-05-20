using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Rio09rio:v;Database=Toko_Baju";
            string query = "SELECT * FROM Barang";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int KodeBarang = (int)numericUpDown1.Value;
            int HargaBarang = (int)numericUpDown2.Value;
            int JumlahBarang = (int)numericUpDown3.Value;
            Crud.CreateData(KodeBarang, textBox1.Text, HargaBarang, JumlahBarang);
            LoadData();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int KodeBarang = (int)numericUpDown6.Value;
            int HargaBarang = (int)numericUpDown5.Value;
            int JumlahBarang = (int)numericUpDown4.Value;
            Crud.UpdateData(KodeBarang, textBox2.Text, HargaBarang, JumlahBarang);
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int KodeBarang = (int)numericUpDown7.Value;
            Crud.DeleteData(KodeBarang);
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadData();
        }
   
    }
    class Crud
    {
        public static void CreateData(int kode, string nama, int harga, int jumlah)
        {
            Connect koneksidb = new Connect();
            string querycreate = $"insert into barang (kode_barang, nama_barang, harga_barang, jumlah_barang) values ('{kode}', '{nama}', '{harga}', '{jumlah}');";
            koneksidb.Run(querycreate);
        }
        
        public static void UpdateData(int kode, string nama, int harga, int jumlah)
        {
            Connect connectdb = new Connect();
            string queryupdate = $"update barang set nama_barang = '{nama}', harga_barang = '{harga}', jumlah_barang = '{jumlah}' where kode_barang = {kode}";
            connectdb.Run(queryupdate);
        }
        public static void DeleteData(int kode)
        {
            Connect connectdb = new Connect();
            string querydelete = $"delete from barang where kode_barang = {kode}::integer;;";
            connectdb.Run(querydelete);
        }

    }
    class Connect
    {
        public NpgsqlConnection connect;

        public Connect()
        {
            NpgsqlConnection connect = new NpgsqlConnection();
            connect.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Rio09rio:v;Database=Toko_Baju";
        }

        public DataTable Run(string sql)
        {
            NpgsqlConnection connect = new NpgsqlConnection();
            connect.ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Rio09rio:v;Database=Toko_Baju";

            DataTable dt = new DataTable();
            try
            {
                connect.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Dispose();
                connect.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return dt;
        }
    }

    }
