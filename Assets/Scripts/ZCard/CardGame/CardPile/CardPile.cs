using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZCard
{
    public abstract class CardPile : MonoBehaviour, ICardPile
    {
        #region Unitycallbacks
        protected virtual void Awake()
        {
            Cards = new List<ICard>();
            Clear();
        }
        #endregion

        #region Properties
        public List<ICard> Cards { get; private set; }
        event Action<ICard[]> onPileChanged = hand => { };
        public Action<ICard[]> OnPileChanged
        {
            get => onPileChanged;
            set => onPileChanged = value;
        }
        #endregion

        #region Operations
        public virtual void AddCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Add(card);
            card.transform.SetParent(transform);
            NotifyPileChange();

            card.Draw();
        }

        public virtual void RemoveCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);

            NotifyPileChange();
        }

        [Button]
        protected virtual void Clear()
        {
            var childCards = GetComponentsInChildren<ICard>();
            foreach (var uiCardHand in childCards)
                Destroy(uiCardHand.gameObject);

            Cards.Clear();
        }

        [Button]
        public void NotifyPileChange() => onPileChanged?.Invoke(Cards.ToArray());

        #endregion
    }
}
