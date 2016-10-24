using System.Collections.Generic;

namespace Oxagile.Internal.IoC.Notification
{
    public class SmsNotificator : INotificator
    {
        public void SendNotification(ICollection<int> identifiers, string message)
        {
            foreach (var item in identifiers)
            {
                //Do something for send SMS with a message
            }
        }
    }
}