using System;

namespace ZCard
{
    public interface ICardPile
    {
        Action<ICard[]> OnPileChanged { get; set; }
        void AddCard(ICard uiCard);
        void RemoveCard(ICard uiCard);
    }
}