using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace AFSInterview.Units.UnitClasses.MainClasses
{
    public abstract class LongRangeUnitPresenter : UnitPresenter
    {
        [SerializeField] private GameObject projectilePrefab;
        
        public override void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            int damage = GetDamage(unitPresenter.UnitAttributes);
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            MoveProjectileToEnemy(projectile, unitPresenter.transform.position);
            
            StartCoroutine(ExecuteAttack(projectile, unitPresenter, damage, OnFinishCurrentState));
        }
        
        public void MoveProjectileToEnemy(GameObject projectile, Vector3 enemyPosition)
        {
            projectile.transform.DOMove(enemyPosition, TimeToHitEnemy).SetDelay(0).SetEase(Ease.Flash);
        }

        private IEnumerator ExecuteAttack(GameObject projectile, UnitPresenter unitPresenter, int damage, 
            Action OnFinishCurrentState)
        {
            yield return new WaitForSeconds(TimeToHitEnemy);
            Destroy(projectile);
            unitPresenter.AcquireDamage(damage, OnFinishCurrentState);        
        }
    }
}