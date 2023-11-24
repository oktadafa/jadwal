using System.Data;
using MySql.Data.MySqlClient;

public class DbSiswa
{
    private readonly string connectionString;

    private readonly MySqlConnection _connection;

    public  DbSiswa(IConfiguration configuration )
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(connectionString);
    }

    public List<Siswa> GetAllSiswa()
    {
        List<Siswa> SiswaList = new List<Siswa>();
        try
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM siswa";
                MySqlCommand command = new MySqlCommand(query,connection);
                connection.Open();
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Siswa siswa = new Siswa
                        {
                            id_siswa = reader["id_siswa"].ToString(),
                            kode_mapel = reader["kode_mapel"].ToString(),
                            nama_siswa  = reader["nama_siswa"].ToString(),
                            kode_kelas = reader["kode_kelas"].ToString(),
                            jurusan = reader["jurusan"].ToString()
                        };

                        SiswaList.Add(siswa);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return SiswaList;
    }

     public int CreateSiswa(Siswa siswa)
    {
        using(MySqlConnection connection = _connection)
        {
            string query = "INSERT INTO siswa (id_siswa, kode_mapel,nama_siswa,kode_kelas,jurusan) VALUES (@id_siswa, @kode_mapel, @nama_siswa, @kode_kelas, @jurusan)";
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id_siswa", siswa.id_siswa);
                command.Parameters.AddWithValue("@kode_mapel", siswa.kode_mapel);
                command.Parameters.AddWithValue("@nama_siswa", siswa.nama_siswa);
                command.Parameters.AddWithValue("@kode_kelas", siswa.kode_kelas);
                command.Parameters.AddWithValue("@jurusan", siswa.jurusan);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }

     public int updateSiswa(string id,Siswa siswa)
    {
        using(MySqlConnection connection = _connection)
        {
            string query = "update siswa set kode_mapel = @kode_mapel, nama_siswa = @nama_siswa, kode_kelas = @kode_kelas, jurusan = @jurusan where id_siswa = @id";
            using(MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@kode_mapel", siswa.kode_mapel);
                command.Parameters.AddWithValue("@nama_siswa", siswa.nama_siswa);
                command.Parameters.AddWithValue("@kode_kelas", siswa.kode_kelas);
                command.Parameters.AddWithValue("@jurusan", siswa.jurusan);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }



    public int DeleteSiswa(string id)
    {
        using(MySqlConnection connection = _connection)
        {
            string query = "delete from siswa where id_siswa = @id";
            using(MySqlCommand command = new MySqlCommand(query,connection))
            {
            command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}