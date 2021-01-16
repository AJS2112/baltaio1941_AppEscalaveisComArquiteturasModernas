using MyStore.Domain.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Entities
{
    public class User
    {
        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Verified = false;
            Active = false;
            LastLoginDate = DateTime.Now;
            Role = ERole.User;
            VerificationCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            ActivationCode = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            AuthorizationCode = "";
            LastAuthorizationCodeRequest = DateTime.Now.AddMinutes(5);
        }

        public Guid Id { get; private set; }
        public string Username{ get; private set; }
        public string Password { get; private set; }
        public bool Verified { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public ERole Role { get; private set; }
        public string VerificationCode { get; private set; }
        public string ActivationCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public DateTime LastAuthorizationCodeRequest { get; private set; }


        public void Register()
        {
            Password = EncryptPassword();
        }

        private string EncryptPassword()
        {
            throw new NotImplementedException();
        }

        public void Verify(string verificationCode)
        {
            if (verificationCode == VerificationCode)
                Verified = true;
        }   

        public void Activate(string activationCode)
        {
            if (!Verified)
                return;

            if (activationCode == ActivationCode)
                Active = true;
        }

        public void RequestLogin(string username)
        {
            if (!Active)
                return;

            if (!Verified)
                return;

            if (username.ToLower() != Username.ToLower())
                return;

            AuthorizationCode = GenerateAutorizationCode();
            LastAuthorizationCodeRequest = DateTime.Now;
        }

        public string GenerateAutorizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        }

        public bool Authenticate(string authorizationCode, string password)
        {
            if (!Active)
                return false;

            if (!Verified)
                return false;

            if (authorizationCode != AuthorizationCode || password != Password)
                return false;

            return true;
        }
    }
}
