
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZCard
{
    public class CardIdle : BaseCardState
    {
        //--------------------------------------------------------------------------------------------------------------

        public CardIdle(ICard handler, BaseStateMachine fsm, CardConfig parameters) : base(handler, fsm,
            parameters) =>
            DefaultSize = Handler.transform.localScale;

        Vector3 DefaultSize { get; }

        //--------------------------------------------------------------------------------------------------------------

        public override void OnEnterState()
        {
            Handler.Input.OnPointerDown += OnPointerDown;
            Handler.Input.OnPointerEnter += OnPointerEnter;

            if (Handler.Movement.IsOperating)
            {
                DisableCollision();
                Handler.Movement.OnFinishMotion += Enable;
            }
            else
            {
                Enable();
            }

            MakeRenderNormal();
            Handler.ScaleTo(DefaultSize, Parameters.ScaleSpeed);
        }

        public override void OnExitState()
        {
            Handler.Input.OnPointerDown -= OnPointerDown;
            Handler.Input.OnPointerEnter -= OnPointerEnter;
            Handler.Movement.OnFinishMotion -= Enable;
        }

        //--------------------------------------------------------------------------------------------------------------

        void OnPointerEnter(PointerEventData obj)
        {
            if (Fsm.IsCurrent(this))
                Handler.Hover();
        }

        void OnPointerDown(PointerEventData eventData)
        {
            if (Fsm.IsCurrent(this))
                Handler.Select();
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}