using Exiled.API.Interfaces;

namespace Exploding_Coin {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
}