﻿using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;
using Light = Exiled.API.Features.Toys.Light;
using MEC;

namespace Exploding_Coin.Items {
    [CustomItem(ItemType.Coin)]
    public class Coin : CustomItem {
        public override uint Id { get; set; } = 69;
        public override string Name { get; set; } = "Coin?";
        public override string Description { get; set; } = "I think its a coin";
        public override float Weight { get; set; } = 0.1f;
        public override SpawnProperties SpawnProperties { get; set; } = new();
        public override ItemType Type { get; set; } = ItemType.Coin;
        
        public void OnFlippingCoin(FlippingCoinEventArgs ev) {
            if (!Check(ev.Item)) return; 
            
            if (!ev.IsTails) {
                Room randRoom = ev.Player.CurrentRoom;
                int check = (Map.IsLczDecontaminated ? 1 : 0) + (Warhead.IsDetonated ? 1 : 0);
                switch (check) {
                    case 0:
                        do randRoom = Room.Random(); while(!Config.validZones.Contains(randRoom.Zone) || randRoom.Type == RoomType.EzShelter);
                        break;
                    case 1:
                        do randRoom = Room.Random(); while(!Config.validZones.Contains(randRoom.Zone) || randRoom.Zone == ZoneType.LightContainment || randRoom.Type == RoomType.EzShelter);
                        break;
                    case 2:
                        randRoom = Room.Random(ZoneType.Surface);
                        break;
                }

                if (randRoom.Zone == ZoneType.Surface) {
                    Door door;
                    do door = randRoom.Doors.ToArray().RandomItem(); while (door.Type == DoorType.ElevatorGateA || door.Type == DoorType.ElevatorGateB);
                    Timing.CallDelayed(2.5f, () => ev.Player.Teleport(door));
                }
                else {
                    Timing.CallDelayed(2.5f, () => ev.Player.Teleport(randRoom));
                }
            } else {
                Timing.CallDelayed(3f, () => { 
                    Map.ExplodeEffect(ev.Player.Position, ProjectileType.FragGrenade);
                    ev.Player.Kill("Tails, you die");
                });
            }
            
        }

        public void OnStarting() {
            Vector3[] pos = [Door.Get(DoorType.Scp106Primary).Position, Door.Get(DoorType.Scp106Secondary).Position];
            for (int i = 0; i < Config.SpawnCount; i++) {
                Vector3 p = pos.RandomItem();
                p -= Room.Get(RoomType.Hcz106).Rotation * Vector3.left - Vector3.up;
                TrySpawn(Id, p, out _);
            }
        }
    }
}