using System;
using System.Collections.Generic;
using AFSInterview.Units.UnitClassesSO;

namespace AFSInterview.Units.UnitClasses
{
    using UnitsSO;
    using Sirenix.OdinInspector;
    using UnityEngine;
    
    public abstract class UnitPresenter : SerializedMonoBehaviour 
    {
        [SerializeField, InlineEditor] private Unit unit;
        [SerializeField] private UnitUIController unitUIController;

        private string unitName;
        private int currentHealth;
        private int currentArmor;
        private int attackDamage;
        private List<UnitAttribute> unitAttributes = new List<UnitAttribute>();
        
        public List<UnitAttribute> UnitAttributes => unitAttributes;
        public string UnitName => unitName;

        private void Awake()
        {
            unitName = unit.Name;
            currentHealth = unit.HealthPoints;
            currentArmor = unit.ArmorPoints;
            attackDamage = unit.AttackDamage;
            unitAttributes = unit.UnitAttributes;
            
            unitUIController.InitializeUnitUI();
        }


        public virtual void AttackEnemy(UnitPresenter unitPresenter)
        {
            Debug.Log($"{unit.name} attacked {unitPresenter.UnitName}");
            int damage = GetDamage(unitPresenter.unitAttributes);
            unitPresenter.AcquireDamage(damage);
        }

        protected int GetDamage(List<UnitAttribute> enemyUnitAttributes)
        {
            int potentialAttackDamage = 0;
            
            foreach (var unitAttribute in unitAttributes)
            {
                foreach (var enemyUnitAttribute in enemyUnitAttributes)
                {

                    if (unitAttribute.AttackDamageForSpecificUnits.ContainsKey(enemyUnitAttribute))
                    {
                        int dmg = unitAttribute.AttackDamageForSpecificUnits[enemyUnitAttribute];
                        if (dmg > potentialAttackDamage) potentialAttackDamage = dmg;
                    }
                    
                }
            }

            if (potentialAttackDamage > 0) return potentialAttackDamage;
            return attackDamage;
        }

        public virtual void AcquireDamage(int damage)
        {
            
        }
        
    }
}