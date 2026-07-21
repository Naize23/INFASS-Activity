namespace INFASS_Activity.Models
{
    public class User
    {
        public string username { get; set; } = "";

        public string fullname { get; set; } = "";

        public string email { get; set; } = "";

        public string password { get; set; } = "";

        public string Sql()
        {
            return
                "INSERT INTO User " +
                "(FullName, Username, Email, Password)\n" +
                "VALUES('" +
                fullname + "','" +
                username + "','" +
                email + "','" +
                password + "')";
        }
    }
}