using React_API.Interface.Security;
using React_API.Models;
using System.Data;

namespace React_API.Repositories.Security
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        public List<UserInfoData> GetUserDetails(int? userID)
        {
            List<UserInfoData> userInfos = new List<UserInfoData>();
            userInfos.Add(new UserInfoData () { Id = 1, UserName = "Vivek", Age = 32, Gender = 'M', RecordStatus = "Active", ContactNummber = "1234567890" });
            userInfos.Add(new UserInfoData() { Id = 2, UserName = "Vaibhav", Age = 30, Gender = 'M', RecordStatus = "Active", ContactNummber = "1234567890" });
            userInfos.Add(new UserInfoData() { Id = 3, UserName = "Mandar", Age = 36, Gender = 'M', RecordStatus = "Active", ContactNummber = "1234567890" });
            return userInfos;
        }
    }
    public class UserDetails_CRUDRepository : IUserDetails_CRUDRepository
    {
        public DataSet SaveUserDetails()
        {
            return new DataSet();
        }
    }
}
