using AFSInterview.Units.UnitClasses;

namespace AFSInterview.Battle
{
    using System.Collections.Generic;
    using Units;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using Random = UnityEngine.Random;
    
    public class TeamController : SerializedMonoBehaviour
    {
        private List<UnitPresenter> aliveUnits = new List<UnitPresenter>();

        private void Awake()
        {
            InitializeUnits();
        }

        public void AttackEnemyTeam(TeamController enemyTeam)
        {
            var attackingEnemy = DrawUnitToAttack();
            var defendingEnemy = enemyTeam.DrawUnitToAttack();
            
            attackingEnemy.AttackEnemy(defendingEnemy);
            
        }

        public UnitPresenter DrawUnitToAttack()
        {
            int rand = Random.Range(0, aliveUnits.Count);
            return aliveUnits[rand];
        }
        
        private void InitializeUnits()
        {
            foreach (GameObject unit in transform)
            {
                aliveUnits.Add(unit.GetComponent<UnitPresenter>());
            }
        }


        
    }
}