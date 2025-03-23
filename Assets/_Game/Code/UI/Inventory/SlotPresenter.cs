using Game.Inventory;
using UnityEngine;

namespace Game.UI
{
    public sealed class SlotPresenter : SlotPresenterBase
    {
        public SlotPresenter(SlotView view, IInventory inventory, Vector3Int position) : base(view, inventory, position) { }
    }
}