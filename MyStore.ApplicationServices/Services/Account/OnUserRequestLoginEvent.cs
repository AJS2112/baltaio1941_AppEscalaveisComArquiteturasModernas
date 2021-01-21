using MyStore.Domain.Account.Entities;

namespace MyStore.ApplicationServices.Services.Account
{
    internal class OnUserRequestLoginEvent
    {
        private User user;

        public OnUserRequestLoginEvent(User user)
        {
            this.user = user;
        }
    }
}