namespace AFSInterview.Units.UnitsSO
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnitClassesSO;
    public abstract class Unit : SerializedScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int attackDamage;
        [SerializeField] private int healthPoints;
        [SerializeField] private int armorPoints;
        [SerializeField] private UnitAttribute unitAttribute;


        public void Attack()
        {
            Debug.Log("Attack" + name);
        }
        
        public void AcquireDamage()
        {
            Debug.Log("Attack" + name);
        }
        
    }
    
}