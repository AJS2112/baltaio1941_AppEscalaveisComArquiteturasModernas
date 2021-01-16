using DomainNotificationHelper.Events.Contracts;
using MyStore.Domain.Account.Entities;
using MyStore.SharedKernel.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Account.Events.UserEvents
{
    public class OnUserRegisteredEvent : IDomainEvent
    {
        public OnUserRegisteredEvent(User user)
        {
            User = user;
            Date = DateTime.Now;
            EmailBody = EmailTemplate.WelcomeEmailBody ;
            EmailTitle = EmailTemplate.WelcomeEmailTitle ;
        }

                
        public User User { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBody { get; private set; }
        public DateTime Date { get; private set; }
    }
}
