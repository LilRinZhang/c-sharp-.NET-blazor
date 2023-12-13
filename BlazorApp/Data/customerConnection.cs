using System.Configuration;
using Blazor_Project.Models;
using MySqlConnector;
namespace Blazor_Project.Data
{
    public class customerConnection
    {
        // 全件取得
        public async Task<Customer[]> GetCustDetails(string id, string name)
        {
            // リターンのリスト初期化
            List<Customer> list = new List<Customer>();
            // SQLとの連携
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                conn.Open();
                // SQLコマンド設定
                var query = "SELECT * FROM customer WHERE id LIKE '%" + $"{id}" + "%' AND name LIKE '%" + $"{name}" + "%'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // 取得結果をリストに追加
                        while (reader.Read())
                        {
                            list.Add(new Customer()
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                Email = reader.GetString("Email"),
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }

        // 登録
        public void InsertCustomer(int id, string name, string phoneNumber, string email)
        {
            // SQLとの連携
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                var query = "INSERT INTO customer VALUES(" + $"{id},'{name}','{phoneNumber}','{email}')";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // 更新
        public void UpdateCustomer(int id, string name, string phoneNumber, string email)
        {
            // SQLとの連携
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                var query = "UPDATE customer SET " + $"name = '{name}', phoneNumber = '{phoneNumber}', email = '{email}' WHERE id = '{id}'";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // 削除
        public void DeleteCustomer(int id)
        {
            // SQLとの連携
            using (MySqlConnection conn = mySQLSqlHelper.GetConnection())
            {
                var query = "DELETE FROM customer WHERE id =" + $"{id}";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}