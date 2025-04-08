using Game.Inventory;

namespace Game.UI
{
    public sealed class SlotPresenter : SlotPresenterBase
    {
        public SlotPresenter(SlotView view, IInventory inventory, Slot slot) : base(view, inventory, slot) { }
    }
}