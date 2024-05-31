using Microsoft.AspNetCore.SignalR;

namespace SignalRUdemy.Hubs
{
    public class DeathlyHallowHub : Hub
    {
        public Dictionary<string, int> GetRaceStatus()
        {
            return SD.DealthyHalloRace;
        }

    }
}
