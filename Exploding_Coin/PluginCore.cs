using Exiled.API.Features;

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
            
        }

        void UnbindEvents() {
            
        }
        void RegisterItems() {
            
        }

        void UnregisterItems() {
            
        }
    }
}