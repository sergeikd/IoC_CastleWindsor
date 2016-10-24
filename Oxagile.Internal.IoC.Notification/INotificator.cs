using System.Collections.Generic;

namespace Oxagile.Internal.IoC.Notification
{
    public interface INotificator
    {
        void SendNotification(ICollection<int> identifiers, string message);
    }
}