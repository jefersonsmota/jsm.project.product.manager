namespace project.contracts.Users
{
    public class PostLoginRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected PostLoginRequest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public PostLoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public virtual string UserName { get; private set; }
        public virtual string Password { get; private set; }
    }
}
