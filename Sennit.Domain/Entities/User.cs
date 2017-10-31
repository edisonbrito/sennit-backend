using System.Text;
using FluentValidator;
using Sennit.Shared.Entities;

namespace Sennit.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = EncryptPassword(password);
            Active = true;
            IsAdmin = false;

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, EncryptPassword(password), "As senhas não coincidem");
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public bool IsAdmin { get; private set; }


        public bool Authenticate(string username, string password)
        {
            if (Username == username && Password == EncryptPassword(password))
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        public bool ChargechangePassword(string password, string confirmPassword)
        {
            if (Password == confirmPassword)
            {
                EncryptPassword(password);
                return true;
            }
            else
            {
                AddNotification("User", "Senhas dígitas precisam ser iguais");
                return false;
            }
        }


        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2BC0E82C-F70C-4AED-A5D2-4779B2938F41");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
