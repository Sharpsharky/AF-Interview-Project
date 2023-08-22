using AFSInterview.Items.Inventory.Items.ItemsSO;

namespace AFSInterview.Items.Inventory.Items
{
	public interface IItemHolder
	{
		Item GetItem(bool disposeHolder);
	}
}