
namespace ZCard
{
    public interface ICard : IStateMachineHandler, ICardComponents, ICardTransform, ICardData
    {
        IPlayerHand Hand { get; }
        bool IsDragging { get; }
        bool IsHovering { get; }
        bool IsDisabled { get; }
        bool IsPlayer { get; }
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
        void Draw();
        void Discard();
    }
}