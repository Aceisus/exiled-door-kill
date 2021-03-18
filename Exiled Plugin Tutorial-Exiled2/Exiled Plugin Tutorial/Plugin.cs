using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using UnityEngine;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled;

namespace Exiled_Plugin_Tutorial
{

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class Main : Plugin<Config>
    {
        public static List<ItemType> items = new List<ItemType>();
        private Handlers.Server server;
        private Handlers.Player player;
        public override PluginPriority Priority { get; } = PluginPriority.First;

        public static Config config;

        public override string Author { get; } = "Ace";

        public override string Name { get; } = "Acesus";

        public override string Prefix { get; } = "ace";

        public override void OnEnabled()
        {
            if (!Config.IsEnabled)
                return;
            config = Config;
            RegisterEvents();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            server = new Handlers.Server();
            player = new Handlers.Player();

            Exiled.Events.Handlers.Player.Destroying += player.OnLeft;
            Exiled.Events.Handlers.Player.Verified += player.OnJoined;
            Exiled.Events.Handlers.Player.InteractingDoor += player.OnInteractingDoor;

            Exiled.Events.Handlers.Server.RoundStarted += server.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += server.OnWaitingForPlayer;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Destroying -= player.OnLeft;
            Exiled.Events.Handlers.Player.Verified -= player.OnJoined;
            Exiled.Events.Handlers.Player.InteractingDoor -= player.OnInteractingDoor;

            Exiled.Events.Handlers.Server.RoundStarted -= server.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= server.OnWaitingForPlayer;

            server = null;
            player = null;
        }
    }
}
