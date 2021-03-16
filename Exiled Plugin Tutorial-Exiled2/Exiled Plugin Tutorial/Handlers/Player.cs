using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace Exiled_Plugin_Tutorial.Handlers

{
    class Player
    {
        public void OnLeft(DestroyingEventArgs ev)
        {
            string message = TutorialPlugin.Instance.Config.LeftMessage.Replace(oldValue: "{player}", newValue: ev.Player.Nickname);
            Map.Broadcast(duration: 6, message);
        }

        public void OnJoined(VerifiedEventArgs ev)
            {
            string message = TutorialPlugin.Instance.Config.JoinedMessage.Replace(oldValue: "{player}", newValue: ev.Player.Nickname);
            Map.Broadcast(duration: 6, message);
        }

        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (ev.IsAllowed == false)
            {
                ev.Player.Broadcast(duration: 3, TutorialPlugin.Instance.Config.BoobyTrapMessage);
                ev.Player.Kill(DamageTypes.Lure);
            }
        }
    }
}
