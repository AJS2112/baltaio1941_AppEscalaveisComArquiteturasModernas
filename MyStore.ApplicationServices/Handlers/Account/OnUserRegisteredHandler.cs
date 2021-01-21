using DomainNotificationHelper;
using MyStore.ApplicationServices.Services.Common;
using MyStore.Domain.Account.Events.UserEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.ApplicationServices.Handlers.Account
{
    public class OnUserRegisteredHandler : IHandler<OnUserRegisteredEvent>
    {
        public void Dispose()
        {
            
        }

        public void Handle(OnUserRegisteredEvent args)
        {
            var user = args.User;
            var title = args.EmailTitle;
            var body = args.EmailBody.Replace("##EMAIL##",args.User.Email);

            EmailService.Send(user.Email,title,body);

        }

        public bool HasNotifications()
        {
            return false;
        }

        public IEnumerable<OnUserRegisteredEvent> Notify()
        {
            return null;
        }
    }
}
