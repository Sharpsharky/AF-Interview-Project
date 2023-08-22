namespace AFSInterview.Items.Inventory.UI
{
    using TMPro;
    using UnityEngine;
    
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyValueText;
        [SerializeField] private InventoryController inventoryController;
        
        private void Awake()
        {
            inventoryController.OnReloadMoneyText += ReloadMoneyValueText;
        }

        private void ReloadMoneyValueText(int currentValue)
        {
            moneyValueText.text = currentValue.ToString();
        }
        
    }
}