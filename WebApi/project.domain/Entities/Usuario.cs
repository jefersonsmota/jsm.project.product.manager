using project.domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.domain.Entities
{
    public class Usuario : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Usuario(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            this.Validation = new UsuarioValidation().Validate(this);
        }

        protected Usuario() { }

        public string BasicAutentication()
        {
            byte[] textoAsBytes = Encoding.ASCII.GetBytes($"{this.Username}:{this.Password}");
            var autenticacao = Convert.ToBase64String(textoAsBytes);
            return autenticacao;
        }

        public override bool IsValid()
        {
            return Validation.IsValid;
        }
    }
}
