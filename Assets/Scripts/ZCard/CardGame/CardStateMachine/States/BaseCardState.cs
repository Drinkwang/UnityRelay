
namespace ZCard
{
    public abstract class BaseCardState : IState
    {
        const int LayerToRenderNormal = 10;
        const int LayerToRenderTop = 11;

        //--------------------------------------------------------------------------------------------------------------

        #region Constructor

        protected BaseCardState(ICard handler, BaseStateMachine fsm, CardConfig parameters)
        {
            Fsm = fsm;
            Handler = handler;
            Parameters = parameters;
            IsInitialized = true;
        }

        #endregion

        protected ICard Handler { get; }
        protected CardConfig Parameters { get; }
        protected BaseStateMachine Fsm { get; }
        public bool IsInitialized { get; }

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        protected virtual void MakeRenderFirst()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                Handler.Renderers[i].sortingOrder = LayerToRenderTop;
        }

        protected virtual void MakeRenderNormal()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                if (Handler.Renderers[i])
                    Handler.Renderers[i].sortingOrder = LayerToRenderNormal;
        }

        protected void Enable()
        {
            if (Handler.Collider)
                EnableCollision();
            if (Handler.Rigidbody)
                Handler.Rigidbody.Sleep();

            MakeRenderNormal();
            RemoveAllTransparency();
        }

        protected virtual void Disable()
        {
            DisableCollision();
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            foreach (var renderer in Handler.Renderers)
            {
                var myColor = renderer.color;
                myColor.a = Parameters.DisabledAlpha;
                renderer.color = myColor;
            }
        }


        protected void DisableCollision() => Handler.Collider.enabled = false;
        protected void EnableCollision() => Handler.Collider.enabled = true;
        protected void RemoveAllTransparency()
        {
            foreach (var renderer in Handler.Renderers)
                if (renderer)
                {
                    var myColor = renderer.color;
                    myColor.a = 1;
                    renderer.color = myColor;
                }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region FSM

        void IState.OnInitialize()
        {
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void OnExitState()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnNextState(IState next)
        {
        }

        public virtual void OnClear()
        {
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}