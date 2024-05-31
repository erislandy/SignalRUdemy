using Microsoft.AspNetCore.SignalR;

namespace SignalRUdemy.Hubs
{
    public class NotificationHub : Hub
    {
        public static int messageCounter = 0;
        public static List<string> messages = new List<string>();
        public async Task SendMessage(string message)
        {
            if(!string.IsNullOrEmpty(message))
            {
                messageCounter++;
                messages.Add(message);
                await LoadMessages();
            }
        }

        public async Task LoadMessages()
        {
            await Clients.All.SendAsync("LoadNotification", messages, messageCounter);
        }
    }
}
