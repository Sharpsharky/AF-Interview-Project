﻿namespace AFSInterview.Items.Inventory
{
	using General;
	using Items;
	using UnityEngine;

	public class ItemsManager : MonoBehaviour
	{
		[SerializeField] private InventoryController inventoryController;
		[SerializeField] private int itemSellMaxValue;
		[SerializeField] private Transform itemSpawnParent;
		[SerializeField] private GameObject itemPrefab;
		[SerializeField] private BoxCollider itemSpawnArea;
		[SerializeField] private float itemSpawnInterval;
		[SerializeField] private GameObjectPool gameObjectPool;
		[SerializeField] private ItemsContainer itemsContainer;

		private float nextItemSpawnTime;

		private void Update()
		{
			if (Time.time >= nextItemSpawnTime)
				SpawnNewItem();
			
			if (Input.GetMouseButtonDown(0))
				TryPickUpItem();
			
			if (Input.GetKeyDown(KeyCode.Space))
				inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

			if (Input.GetKeyDown(KeyCode.E))
				inventoryController.UseFirstItem();

		}
		
		
		
		private void SpawnNewItem()
		{
			nextItemSpawnTime = Time.time + itemSpawnInterval;
			
			var spawnAreaBounds = itemSpawnArea.bounds;
			var position = new Vector3(
				UnityEngine.Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
				0f,
				UnityEngine.Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
			);
			
			var newItem = gameObjectPool.Get();
			newItem.transform.position = position;
			newItem.transform.parent = itemSpawnParent;

			newItem.GetComponent<ItemPresenter>().SetItem(itemsContainer.GetRandomItem());
		}
		
		
		private void TryPickUpItem()
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			var layerMask = LayerMask.GetMask("Item");
			if (!Physics.Raycast(ray, out var hit, 100f, layerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
				return;
			
			var item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);
            Debug.Log("Picked up " + item.Name + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " items");
		}
	}
}