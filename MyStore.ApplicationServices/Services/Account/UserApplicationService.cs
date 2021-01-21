using DomainNotificationHelper.Events;
using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Services;
using MyStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.ApplicationServices.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private readonly IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork) : base (unitOfWork)
        {
            _repository = repository;
        }
        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Email, command.Username, command.Password);
            
            user.Register();

            if (Commit())
            {
                DomainEvent.Raise(new OnUserRegisteredEvent(user));
                return user;
            }

            return null;
        }
    }
}
