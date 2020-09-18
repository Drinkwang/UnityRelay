
using UnityEngine;

namespace ZCard
{
    public class CardDiscard : BaseCardState
    {
        public CardDiscard(ICard handler, BaseStateMachine fsm, CardConfig parameters) : base(handler, fsm,
            parameters)
        {
        }

        Vector3 StartScale { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnEnterState()
        {
            Disable();
            SetScale();
            SetRotation();
        }

        void SetScale()
        {
            var finalScale = Handler.transform.localScale * Parameters.DiscardedSize;
            Handler.ScaleTo(finalScale, Parameters.ScaleSpeed);
        }

        void SetRotation()
        {
            var speed = Parameters.RotationSpeed;
            Handler.RotateTo(Vector3.zero, speed);
        }

        #endregion
    }
}