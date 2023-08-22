namespace AFSInterview.Items.Inventory.Items
{
	using General;
	using UnityEngine;

	public class ItemPresenter : MonoBehaviour, IItemHolder, IGameObjectPooled
	{
		[SerializeField] private Item item;
		public GameObjectPool Pool { get; set; }

		public Item GetItem(bool disposeHolder)
		{
			if (disposeHolder) 
				Pool.ReturnToPool(gameObject);
			
			return item;
		}

	}
}