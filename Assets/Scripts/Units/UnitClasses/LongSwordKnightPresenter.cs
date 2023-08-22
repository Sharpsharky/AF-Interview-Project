namespace AFSInterview.Units.UnitClasses
{
    using System;

    public class LongSwordKnightPresenter : UnitPresenter
    {
        public virtual void AttackEnemy(UnitPresenter unitPresenter, Action OnFinishCurrentState)
        {
            base.AttackEnemy(unitPresenter, OnFinishCurrentState);
        }
    }
}