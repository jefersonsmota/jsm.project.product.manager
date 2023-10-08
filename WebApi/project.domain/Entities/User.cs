using System;
using System.Text;

namespace project.domain.Entities
{
    public interface IUse : IEntity
    {
        string Username { get; }
        string Password { get; }

        string BasicAutentication();
    }
    public class User : Entity, IUse
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            Validate();
        }

        protected User() { }

        public string BasicAutentication()
        {
            byte[] textoAsBytes = Encoding.ASCII.GetBytes($"{this.Username}:{this.Password}");
            var autenticacao = Convert.ToBase64String(textoAsBytes);
            return autenticacao;
        }

        protected override string EntityErrorMessage() => "Invalid User.";

        protected override void Validations()
        {
            Fail(string.IsNullOrWhiteSpace(Username), "USER_USERNAME", "Invalid Username.");
            Fail(string.IsNullOrWhiteSpace(Password), "USER_PASSWORD", "Invalid Password.");
        }
    }
}
