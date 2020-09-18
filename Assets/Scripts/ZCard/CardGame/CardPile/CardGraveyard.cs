using System;
using UnityEngine;

namespace ZCard
{
    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    ///     Card graveyard holds a register with cards played by the player.
    /// </summary>
    public class CardGraveyard : CardPile
    {
        [SerializeField]
        Transform graveyardPosition;

        //--------------------------------------------------------------------------------------------------------------

        IPlayerHand PlayerHand { get; set; }


        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        protected override void Awake()
        {
            base.Awake();
            PlayerHand = transform.parent.GetComponentInChildren<IPlayerHand>();
            PlayerHand.OnCardPlayed += AddCard;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Adds a card to the graveyard or discard pile.
        /// </summary>
        /// <param name="card"></param>
        public override void AddCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Add(card);
            card.transform.SetParent(graveyardPosition);
            card.Discard();
            NotifyPileChange();
        }


        /// <summary>
        ///     Removes a card from the graveyard or discard pile.
        /// </summary>
        /// <param name="card"></param>
        public override void RemoveCard(ICard card)
        {
            if (card == null)
                throw new ArgumentNullException("Null is not a valid argument.");

            Cards.Remove(card);
            NotifyPileChange();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}