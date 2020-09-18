using UnityEngine;

namespace ZCard
{
    public class CardHandFsm : BaseStateMachine
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Constructor

        public CardHandFsm(Camera camera, CardConfig cardConfigsParameters, ICard handler = null) :
            base(handler)
        {
            CardConfigsParameters = cardConfigsParameters;

            IdleState = new CardIdle(handler, this, CardConfigsParameters);
            DisableState = new CardDisable(handler, this, CardConfigsParameters);
            DragState = new CardDrag(handler, camera, this, CardConfigsParameters);
            HoverState = new CardHover(handler, this, CardConfigsParameters);
            DrawState = new CardDraw(handler, this, CardConfigsParameters);
            DiscardState = new CardDiscard(handler, this, CardConfigsParameters);

            RegisterState(IdleState);
            RegisterState(DisableState);
            RegisterState(DragState);
            RegisterState(HoverState);
            RegisterState(DrawState);
            RegisterState(DiscardState);

            Initialize();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        CardIdle IdleState { get; }
        CardDisable DisableState { get; }
        CardDrag DragState { get; }
        CardHover HoverState { get; }
        CardDraw DrawState { get; }
        CardDiscard DiscardState { get; }
        CardConfig CardConfigsParameters { get; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void Hover() => PushState<CardHover>();

        public void Disable() => PushState<CardDisable>();

        public void Enable() => PushState<CardIdle>();

        public void Select() => PushState<CardDrag>();

        public void Unselect() => Enable();

        public void Draw() => PushState<CardDraw>();

        public void Discard() => PushState<CardDiscard>();

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}