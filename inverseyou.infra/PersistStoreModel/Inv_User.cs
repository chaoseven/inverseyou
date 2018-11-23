using System;

namespace inverseyou.infra.PersistStoreModel
{
    public class Inv_User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public int GenderCode { get; set; }
        public string GenderText { get; set; }
        public int AccountStatusCode { get; set; }
        public string AccountStatusText { get; set; }
    }
}
