using DomainNotificationHelper.Validation;
using MyStore.Domain.Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertLength(user.Username, 6, 20, "O usuario deve conter entre 6 e 20 caracteres"),
                    AssertionConcern.AssertLength(user.Password, 6, 20, "A senha deve conter entre 6 e 20 caracteres")    
                );
        }   

        public static bool VerificationScopeIsValid(this User user, string verificationCode)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user,"Nenhum usuario encontrado"),
                    AssertionConcern.AssertTrue(user.Verified == false,"Usuario ja verificado"),
                    AssertionConcern.AssertAreEquals(user.VerificationCode, verificationCode,"Codigos de verificaçaõ diferentes")
                );
        }

        public static bool ActivationScopeIsValid(this User user, string activationCode)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuario encontrado"),
                    AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado"),
                    AssertionConcern.AssertTrue(user.Active == false, "Cadastro já verificado"),
                    AssertionConcern.AssertAreEquals(user.ActivationCode, activationCode, "Codigos de ativação diferente")
                );
        }

        public static bool RequestLoginScopeIsValid(this User user, string userName)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuario encontrado"),
                    AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado"),
                    AssertionConcern.AssertTrue(user.Active == true, "Cadastro não verificado"),
                    AssertionConcern.AssertAreEquals(user.Username.ToLower(), userName.ToLower(), "Nome de usuario diferente"),
                    AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAuthorizationCodeRequest.AddMinutes(-5),DateTime.Now).ToString(), (-1).ToString(), "Um SMS já foi enviado, aguarde 5 minutos")
                );
        }

        public static bool LoginScopeIsValid(this User user, string authorizationCode, string password)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(user, "Nenhum usuario encontrado"),
                    AssertionConcern.AssertTrue(user.Verified == true, "E-mail não verificado"),
                    AssertionConcern.AssertTrue(user.Active == true, "Cadastro não ativado"),
                    AssertionConcern.AssertAreEquals(user.AuthorizationCode.ToLower(), authorizationCode.ToLower(), "Codigo de Autorização diferente"),
                    AssertionConcern.AssertAreEquals(user.Password.ToLower(), password.ToLower(), "Codigo de Autorização diferente"),
                    AssertionConcern.AssertAreEquals(DateTime.Compare(user.LastAuthorizationCodeRequest.AddMinutes(5), DateTime.Now).ToString(), (1).ToString(), "Codigo de autenticação expirado")
                );
        }

    }
}
