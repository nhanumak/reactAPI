using React_API.Models;
using System.Data;

namespace React_API.Interface
{
    public interface IUserDetails_CRUDRepository
    {
        public DataSet SaveUserDetails();
    }
}
