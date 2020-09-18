using System;

namespace ZCard
{
    public class PlayerHand : CardPile, IPlayerHand
    {
        #region Properties
        public ICard SelectedCard { get; private set; }

        event Action<ICard> OnCardSelected = card => { };

        event Action<ICard> OnCardPlayed = card => { };

        Action<ICard> IPlayerHand.OnCardPlayed
        {
            get => OnCardPlayed;
            set => OnCardPlayed = value;
        }

        Action<ICard> IPlayerHand.OnCardSelected
        {
            get => OnCardSelected;
            set => OnCardSelected = value;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void SelectCard(ICard card)
        {
            SelectedCard = card ?? throw new ArgumentNullException("Null is not a valid argument.");

            //disable all cards
            DisableCards();
            NotifyCardSelected();
        }

        public void PlaySelected()
        {
            if (SelectedCard == null)
                return;

            PlayCard(SelectedCard);
        }

        public void PlayCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            SelectedCard = null;
            RemoveCard(card);
            OnCardPlayed?.Invoke(card);
            EnableCards();
            NotifyPileChange();

            PlayerHandUtils.CARD_ACTION = card.id;
            if (1!=card.id){
                PlayerHandUtils.CARD_ACT_DUR = 20;
            }
        }

        public void UnselectCard(ICard card)
        {
            if (card == null)
                return;

            SelectedCard = null;
            card.Unselect();
            NotifyPileChange();
            EnableCards();
        }

        public void Unselect() => UnselectCard(SelectedCard);

        public void DisableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Disable();
        }

        public void EnableCards()
        {
            foreach (var otherCard in Cards)
                otherCard.Enable();
        }

        [Button]
        void NotifyCardSelected() => OnCardSelected?.Invoke(SelectedCard);

        #endregion
    }
}