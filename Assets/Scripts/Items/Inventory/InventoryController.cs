﻿namespace AFSInterview.Items.Inventory
{
	using System;
	using System.Collections.Generic;
	using Items;
	using UnityEngine;
	
	public class InventoryController : MonoBehaviour
	{
		[SerializeField] private List<Item> items;
		[SerializeField] private int money;
		
		public event Action<int> OnReloadMoneyText;

		public int ItemsCount => items.Count;

		public void SellAllItemsUpToValue(int maxValue)
		{
			for (var i = items.Count - 1; i >= 0; i--)
			{
				var itemValue = items[i].Value;
				if (itemValue > maxValue)
					continue;
				
				money += itemValue;
				items.RemoveAt(i);
			}

			OnReloadMoneyText(money);

		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}
	}
}