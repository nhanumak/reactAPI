using React_API.Models;
using System.Data;

namespace React_API.Interface.Security
{
    public interface IUserDetails_CRUDRepository
    {
        public DataSet SaveUserDetails();
    }
}
