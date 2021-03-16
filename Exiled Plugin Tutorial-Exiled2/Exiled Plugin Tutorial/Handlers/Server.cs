using Exiled.API.Features;


namespace Exiled_Plugin_Tutorial.Handlers
{
    class Server
    {
        public void OnWaitingForPlayer()
        {
            Log.Info(message: "Waiting for players...");
        }

        public void OnRoundStarted()
        {
            Map.Broadcast(duration: 6,TutorialPlugin.Instance.Config.RoundStartedMessage);
        }

    }
}
