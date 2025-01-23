using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommandSystem;
using Exiled.API.Features;

namespace Exploding_Coin.Commands;

[CommandHandler(typeof(ClientCommandHandler))]
public class RoomId : ICommand {
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response) {
        Room room = Player.Get(sender).CurrentRoom;
        response = "\n" + room.RoomShape + "\n" + room.RoomName + "\n";
        return true;
    }

    public string Command { get; } = "roomid";
    public string[] Aliases { get; } = ["rid"];
    public string Description { get; } = "Gets a buncha information about the current room.";
} 