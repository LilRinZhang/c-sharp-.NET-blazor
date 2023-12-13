using Blazor_Project.Models;
namespace Blazor_Project.Data
{
    public class custMasterDetailSerivce
    {
        customerConnection objUsers = new();

        // 全件取得
        public async Task<Customer[]> GetCustDetails(string id, string name)
        {
            Customer[] custsObjs;
            custsObjs = await Task.Run(() => objUsers.GetCustDetails(id, name).Result.ToArray());
            return custsObjs;
        }

        // 登録
        public void InsertCustomer(int id, string name, string phoneNumber, string email)
        {
            objUsers.InsertCustomer(id, name, phoneNumber, email);
        }

        // 更新
        public void UpdateCustomer(int id, string name, string phoneNumber, string email)
        {
            objUsers.UpdateCustomer(id, name, phoneNumber, email);
        }

        // 削除
        public void DeleteCustomer(int id)
        {
            objUsers.DeleteCustomer(id);
        }
    }
}
