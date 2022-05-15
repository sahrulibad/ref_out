using System;
using Npgsql;
using System.Data;

namespace refout
{
    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Hyejun60;database=kedai;");
        }
        public bool ExecuteQuery(out bool info)
        {
            info = true;
            try
            {
                NpgsqlConnection con = koneksi();
                string sql = "select * from pemesanan";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;

            }
            catch (Exception)
            {
                info = false;
                return info;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Hyejun60;database=kedai;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into pemesanan(id_pesanan,jenis_pesanan,nama_pesanan) values('1','makanan,'kerupuk ikan')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }

        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update pemesanan set jenis_pesanan = minuman, nama_pesanan = boba where id_pesanan = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
        public bool Delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from pemesanan where id_pesanan = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }

        }
    }

    class program_utama
    {

        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("berhasil mengambil data");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("gagal mengambil data");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("insert berhasil");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("insert gagal");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("update berhasil");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("update gagal");
            }
            if (op.Delete(ref ingfo) == true)
            {
                Console.WriteLine("delete berhasil");
            }
            else if (op.Delete(ref ingfo) == false)
            {
                Console.WriteLine("delete gagal");
            }
        }
    }
}
