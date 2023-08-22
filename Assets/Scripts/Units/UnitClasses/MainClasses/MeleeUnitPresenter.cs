namespace AFSInterview.Units.UnitClasses.MainClasses
{
    using System;
    using System.Collections;
    using DG.Tweening;
    using UnityEngine;

    public abstract class MeleeUnitPresenter : UnitPresenter
    {
        public override void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            int damage = GetDamage(unitPresenter.UnitAttributes);
            MoveToEnemy(unitPresenter.transform.position);
            StartCoroutine(ExecuteAttack(unitPresenter, damage, OnFinishCurrentState));
        }
        
        public void MoveToEnemy(Vector3 enemyPosition)
        {
            Vector3 currentPos = transform.position;
            
            transform.DOMove(enemyPosition, TimeToHitEnemy).SetDelay(0);
            transform.DOMove(currentPos,TimeToHitEnemy).SetDelay(TimeToHitEnemy).SetEase(Ease.OutBack);
        }

        private IEnumerator ExecuteAttack(UnitPresenter unitPresenter, int damage, 
            Action OnFinishCurrentState)
        {
            yield return new WaitForSeconds(TimeToHitEnemy);
            unitPresenter.AcquireDamage(damage, OnFinishCurrentState);        
        }
    }
}