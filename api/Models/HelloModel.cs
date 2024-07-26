using api.Entity;
using MySql.Data.MySqlClient;

namespace api.Models
{
    public class HelloModel
    {
        readonly string connStr = "server=127.0.0.1;user=root;password=root@123;database=BOOK_RECODER;port=3366;";

        public List<Book> GetAllBooks()
        {
            MySqlConnection conn = new(connStr);

            // リストを作成
            List<Book> books = [];

            try
            {
                conn.Open();
                MySqlCommand cmd = new("select * from book", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Bookオブジェクトを作成し、値を設定
                    Book book = new()
                    {
                        Id = rdr.GetInt32(0),
                        Title = rdr.GetString(1),
                        Author = rdr.GetString(2),
                        Genre = rdr.GetString(3),
                        Thoughts = rdr.IsDBNull(4) ? null : rdr.GetString(4)
                    };

                    // リストに追加
                    books.Add(book);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                // エラーハンドリング（例外をログに記録する、再スローするなど）
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // 接続を閉じる
                conn.Close();
            }

            // リストを返す
            return books;
        }

    }
}
