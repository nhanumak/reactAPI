using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using React_API.Interface;
using React_API.Models;

namespace React_API.Controllers.UserDetalis
{

    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsRepository userDetailsRepository;
        public UserDetailsController(IUserDetailsRepository _userDetailsRepository)
        {
            userDetailsRepository = _userDetailsRepository;
        }

        [HttpGet]
        [Route("api/GetUserDetails/{id=0:int}")]
        public IActionResult getUserInfo(int? id = 0)
        {
            List<UserInfoData> result = userDetailsRepository.GetUserDetails(id);
            return Ok(result);
        }

    }
}
