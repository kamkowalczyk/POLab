using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorowanieZawodnikow
{
    public class Tracker
    {
        public Dictionary<int, Queue<Location>> playersPath;
        public Tracker()
        {
            playersPath = new Dictionary<int, Queue<Location>>();
        }

        public void ObservePlayer(Player player)
        {
            player.Moved += OnLocationChange;
            playersPath.Add(player.id, new Queue<Location>());
        }

        public void OnLocationChange(object source, PlayerEventArgs args)
        {
            var player = source as Player;
            playersPath[player.id].Enqueue(args.location);
        }

    }
}
