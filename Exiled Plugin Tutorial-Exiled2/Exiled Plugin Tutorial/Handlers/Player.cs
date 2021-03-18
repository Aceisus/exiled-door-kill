using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace Exiled_Plugin_Tutorial.Handlers

{
    class Player
    {
        public void OnLeft(LeftEventArgs ev)
        {
            string message = Main.config.LeftMessage.Replace(oldValue: "{player}", newValue: ev.Player.Nickname);
            Map.Broadcast(duration: 6, message);
        }

        public void OnJoined(JoinedEventArgs ev)
            {
            string message = Main.config.JoinedMessage.Replace(oldValue: "{player}", newValue: ev.Player.Nickname);
            Map.Broadcast(duration: 6, message);
        }

        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (ev.IsAllowed == false)
            {
                ev.Player.Broadcast(duration: 3, Main.config.BoobyTrapMessage);
                ev.Player.Kill(DamageTypes.Lure);
            }
        }
    }
}
