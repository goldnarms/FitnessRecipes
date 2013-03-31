using SignalR.Hubs;

namespace FitnessRecipes
{
    public class MessagePoster : Hub
    {
        public void SendMessage(string message, bool success)
        {
            Clients.receive(message);
        }
    }
}