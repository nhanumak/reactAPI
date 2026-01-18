namespace React_API.Models
{
    public class UserInfoData : CommonEntity
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ContactNummber { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}
