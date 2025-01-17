using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.API.Interfaces;
using Exploding_Coin.Items;
using UnityEngine;

namespace Exploding_Coin {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        public Coin coin { get; set; } = new();

        public static int SpawnCount = 1;
    }
}