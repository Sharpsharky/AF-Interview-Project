using System.Collections.Generic;

namespace AFSInterview.Units.UnitsSO
{
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnitClassesSO;

    [CreateAssetMenu(menuName = "Unit")]
    public class Unit : SerializedScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int attackDamage;
        [SerializeField] private int healthPoints;
        [SerializeField] private int armorPoints;
        [SerializeField] private List<UnitAttribute> unitAttributes;

        public string Name => name;
        public int AttackDamage => attackDamage;
        public int HealthPoints => healthPoints;
        public int ArmorPoints => armorPoints;
        public List<UnitAttribute> UnitAttributes => unitAttributes;


    }
    
}