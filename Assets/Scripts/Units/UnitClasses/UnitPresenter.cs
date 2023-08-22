namespace AFSInterview.Units.UnitClasses
{
    using UnitsSO;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using System.Collections.Generic;
    using UnitClassesSO;
    using System;
    using Battle;

    public abstract class UnitPresenter : SerializedMonoBehaviour 
    {
        [SerializeField, InlineEditor] private Unit unit;
        [SerializeField] private UnitUIController unitUIController;
        
        private string unitName;
        private int currentHealth;
        private int currentArmor;
        private int attackDamage;
        private List<UnitAttribute> unitAttributes = new List<UnitAttribute>();

        private TeamController teamController;

        public List<UnitAttribute> UnitAttributes => unitAttributes;
        public string UnitName => unitName;

        private void Awake()
        {
            InitializeUnit();
            InitializeUI();
        }

        public void Initialize(TeamController teamController)
        {
            this.teamController = teamController;
        }
        
        public virtual void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            Debug.Log($"{unit.name} attacked {unitPresenter.UnitName}");
            int damage = GetDamage(unitPresenter.UnitAttributes);
            unitPresenter.AcquireDamage(damage, OnFinishCurrentState);
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

        public virtual void AcquireDamage(int damage, Action OnFinishCurrentState)
        {
            currentArmor -= damage;
            if (currentArmor < 0)
            {
                currentHealth += currentArmor;
            }
            currentArmor = 0;

            if (currentHealth < 0)
            {
                currentHealth = 0;
                GetKilled();
            }

            unitUIController.ReloadHealthPoints(currentArmor, unit.ArmorPoints);
            unitUIController.ReloadArmorPoints(currentHealth, unit.HealthPoints);
            
            Debug.Log("Acquire Damage");
            OnFinishCurrentState();
        }

        protected virtual void GetKilled()
        {
            gameObject.SetActive(false);
            teamController.RemoveUnitFromList(this);
        }
        
        private void InitializeUnit()
        {
            unitName = unit.Name;
            currentHealth = unit.HealthPoints;
            currentArmor = unit.ArmorPoints;
            attackDamage = unit.AttackDamage;
            unitAttributes = unit.UnitAttributes;
        }
        
        private void InitializeUI()
        {
            unitUIController.ReloadHealthPoints(currentArmor, unit.ArmorPoints);
            unitUIController.ReloadArmorPoints(currentHealth, unit.HealthPoints);
            unitUIController.SetName(unitName);
        }
        
    }
}