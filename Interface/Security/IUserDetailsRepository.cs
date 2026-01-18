using React_API.Models;
using System.Data;

namespace React_API.Interface.Security
{
    public interface IUserDetailsRepository
    {
        public List<UserInfoData> GetUserDetails(int? userId = 0);
    }
}
