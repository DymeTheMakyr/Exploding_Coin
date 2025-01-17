using Exiled.API.Features;
using Exiled.CustomItems.API;
using Exploding_Coin.Items;
using Player = Exiled.Events.Handlers.Player;


namespace Exploding_Coin {
    public class PluginCore : Plugin<Config> {
        public override void OnEnabled() {
            base.OnEnabled();
            BindEvents();
            RegisterItems();
        }

        public override void OnDisabled() {
            base.OnDisabled();
            UnbindEvents();
            UnregisterItems();
        }
        void BindEvents() {
            Player.FlippingCoin += Config.coin.OnFlippingCoin;
        }

        void UnbindEvents() {
            Player.FlippingCoin -= Config.coin.OnFlippingCoin;
        }
        void RegisterItems() {
            Config.coin.Register();
        }

        void UnregisterItems() {
            Config.coin.Unregister();
        }
    }
}