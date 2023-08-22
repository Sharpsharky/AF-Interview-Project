using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AFSInterview.Battle
{
    public class BattleManager : SerializedMonoBehaviour
    {
        private BattleState currentBattleState;

        [SerializeField] private TeamController firstTeamController;
        [SerializeField] private TeamController secondTeamController;
        
        private void Start()
        {
            ChangeState(BattleState.Start);
        }

        private void ChangeState(BattleState newState)
        {
            currentBattleState = newState;

            switch (currentBattleState)
            {
                case BattleState.Start:
                {
                    break;
                }
                case BattleState.FirstTeamTurn:
                {
                    firstTeamController.AttackEnemyTeam(secondTeamController);
                    break;
                }
                case BattleState.SecondTeamTurn:
                {
                    secondTeamController.AttackEnemyTeam(firstTeamController);
                    break;
                }
                case BattleState.Finish:
                {
                    break;
                }
            }
            
        }
        
        
        
    }
}