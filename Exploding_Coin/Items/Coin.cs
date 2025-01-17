using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.ThrowableProjectiles;

namespace Exploding_Coin.Items {
    [CustomItem(ItemType.Coin)]
    public class Coin : CustomItem {
        public override uint Id { get; set; } = 69;
        public override string Name { get; set; } = "Coin?";
        public override string Description { get; set; } = "I think its a coin";
        public override float Weight { get; set; } = 0.1f;
        public override SpawnProperties SpawnProperties { get; set; }

        public void OnFlippingCoin(FlippingCoinEventArgs ev) {
            if (Check(ev.Item)) {
                if (!ev.IsTails) {
                    //rtp
                }else if (ev.IsTails) {
                    Map.ExplodeEffect(ev.Player.Position, ProjectileType.Scp018);
                    ev.Player.Kill("Tails, you die.");
                }
            }
        }
    }
}