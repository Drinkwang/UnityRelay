
namespace ZCard
{
    public class CardDisable : BaseCardState
    {
        public CardDisable(ICard handler, BaseStateMachine fsm, CardConfig parameters) : base(handler, fsm,
            parameters)
        {
        }

        public override void OnEnterState() => Disable();
    }
}