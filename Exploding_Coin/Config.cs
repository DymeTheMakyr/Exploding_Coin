using Exiled.API.Interfaces;
using Exploding_Coin.Items;

namespace Exploding_Coin {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        public Coin coin = new();
    }
}