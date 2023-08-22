using System;

namespace AFSInterview.Battle
{
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using Random = UnityEngine.Random;
    using Units.UnitClasses;

    public class TeamController : SerializedMonoBehaviour
    {
        [SerializeField] private string teamName;
        private List<UnitPresenter> aliveUnits = new List<UnitPresenter>();

        private void Awake()
        {
            InitializeUnits();
        }

        public void AttackEnemyTeam(TeamController enemyTeam, Action OnFinishCurrentState)
        {
            var attackingEnemy = DrawUnitToAttack();
            var defendingEnemy = enemyTeam.DrawUnitToAttack();
            
            attackingEnemy.AttackEnemy(defendingEnemy, OnFinishCurrentState);
            
        }

        public void RemoveUnitFromList(UnitPresenter unitToRemove)
        {
            aliveUnits.Remove(unitToRemove);
        }
        
        public int GetAliveUnits()
        {
            return aliveUnits.Count;
        }

        public UnitPresenter DrawUnitToAttack()
        {
            int rand = Random.Range(0, aliveUnits.Count);
            return aliveUnits[rand];
        }

        public string GetTeamName()
        {
            return teamName;
        }
        
        private void InitializeUnits()
        {
            foreach (Transform unit in transform)
            {
                UnitPresenter unitPresenter = unit.GetComponent<UnitPresenter>();
                aliveUnits.Add(unitPresenter);
                unitPresenter.Initialize(this);
            }
        }


        
    }
}