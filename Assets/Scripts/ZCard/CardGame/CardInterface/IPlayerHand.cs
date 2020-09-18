using System;
using System.Collections.Generic;

namespace ZCard
{
    public interface IPlayerHand : ICardPile
    {
        List<ICard> Cards { get; }
        Action<ICard> OnCardPlayed { get; set; }
        Action<ICard> OnCardSelected { get; set; }
        void PlaySelected();
        void Unselect();
        void PlayCard(ICard uiCard);
        void SelectCard(ICard uiCard);
        void UnselectCard(ICard uiCard);
    }
}