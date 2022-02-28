using ADO_Exam.Model;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace ADO_Exam;

public class BooksDB
{
    private readonly MySqlConnection _db;
    private MySqlCommand _cmd;

    public BooksDB(string connectionString)
    {
        _db = new MySqlConnection(connectionString);
            _cmd = new MySqlCommand{Connection = _db};
    }

    public void Open() => _db.Open();

    public void Close() => _db?.Close();

    public bool Add_Author(Author author)
    {
        Open();
        var sql =
            $"INSERT INTO Authors(First_name, Middle_name, Last_name) VALUES ('{author.First_name}','{author.Middle_name}','{author.Last_name}');";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }

    public void GetAllAuthors()
    {
        Open();
        var sql = "SELECT id, First_name, Middle_name, Last_name FROM Authors";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteReader();
        Console.WriteLine("id " + " First name " + " Middle name " + " Last name ");
        while (res.Read())
        {
            Console.Write(res.GetInt32("id"));
            Console.WriteLine("   " + res.GetString("First_name"));
            Console.WriteLine("   " + res.GetString("Middle_name"));
            Console.WriteLine("   " + res.GetString("Last_name"));
        }
        Close();
    }

    public bool Remove_Author(uint id)
    {
        Open();
        var sql = $"DELETE FROM Authors WHERE Authors.id = {id}";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();

        return res == 1;
    }
    
    public bool UpdateAuthor(uint id, string str, uint column)
    {
        Open();
        if(column == 1){
            var sql = $"UPDATE Authors SET First_name = {str} WHERE id = {id}"; //TODO обработать исключения на имена/фамилии/отчества авторов
            _cmd.CommandText = sql;
            var res = _cmd.ExecuteNonQuery();
            return res == 1;
        }else if (column == 2)
        {
            var sql = $"UPDATE Authors SET Middle_name = {str} WHERE id = {id}";
            _cmd.CommandText = sql;
            var res = _cmd.ExecuteNonQuery();
            return res == 1;
        }else if(column == 3)
        {
            var sql = $"UPDATE Authors SET Last_name = {str} WHERE id = {id}";
            _cmd.CommandText = sql;
            var res = _cmd.ExecuteNonQuery();
            return res == 1;
        }
        Close();
        return false;
    }

    public bool Add_genre(Genre genre)
    {
        Open();
        var sql = $"INSERT INTO Genres(name) VALUES ('{genre.name}');";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }

    public bool Remove_genre(uint id)
    {
        Open();
        var sql = $"DELETE FROM Genres WHERE Genres.id = {id}";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }
    public void GetAllGenres()
    {
        Open();
        var sql = "SELECT id, name FROM Genres";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteReader();
        Console.WriteLine("id " + " name ");
        while (res.Read())
        {
            Console.Write(res.GetInt32("id"));
            Console.WriteLine("   " + res.GetString("name"));
        }
        Close();
    }

    public bool UpdateGenre(uint id, string str)
    {
        Open();
        var sql = $"UPDATE Genres SET name = {str} WHERE id = {id}";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }

    public bool Add_Publisher(Publishers publishers)
    {
        Open();
        var sql = $"INSERT INTO Publishers(name) VALUES ('{publishers.name}');";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }

    public bool Remove_Publisher(uint id)
    {
        Open();
        var sql = $"DELETE FROM Publishers WHERE Publishers.id = {id}";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }
    
    public bool UpdatePublisher(uint id, string str)
    {
        Open();
        var sql = "UPDATE Publishers SET Name = {str} WHERE id = {id}";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }

    public List<Publishers> GerAllPublishers()
    {
        var publishers = new List<Publishers>();
        Open();
        var sql = "SELECT id, name FROM Publishers";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteReader();
        while (res.Read())
        {
            publishers.Add(new Publishers()
            {
                id = res.GetInt32("id"),
                name = res.GetString("name")
            });
        }
        Close();
        
        return publishers;
    }

    public bool Add_book(Books books)
    {
        Open();
        var sql =
            $"INSERT INTO Books(id_author, id_publ, id_genre, pages, cost_price, publishing_year, selling_price, series) VALUES ('{books.id_author}','{books.id_publ}','{books.id_genre}','{books.pages}','{books.cost_price}','{books.publishing_year}','{books.selling_price}','{books.series}');";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }

    public bool Remove_book(uint id)
    {
        Open();
        var sql = $"DELETE FROM Books WHERE Books.id = {id}";
        _cmd.CommandText = sql;
        var res = _cmd.ExecuteNonQuery();
        Close();
        return res == 1;
    }
}