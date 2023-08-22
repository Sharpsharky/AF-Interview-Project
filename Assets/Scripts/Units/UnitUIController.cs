namespace AFSInterview.Units
{
    using Sirenix.OdinInspector;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    public class UnitUIController : SerializedMonoBehaviour
    {
        [SerializeField, BoxGroup("UI")] private TMP_Text unitName;
        [SerializeField, BoxGroup("UI")] private Image healthBar;
        [SerializeField, BoxGroup("UI")] private Image armorBar;

        public void InitializeUnitUI()
        {
            
        }
        
    }
}