using System;
using UnityEngine;

namespace ZCard
{
    [RequireComponent(typeof(CardGraveyard))]
    public class CardGraveyardSorter : MonoBehaviour
    {
        [SerializeField]
        Transform graveyardPosition;

        [SerializeField] CardConfig parameters;

        ICardPile CardGraveyard { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void Awake()
        {
            CardGraveyard = GetComponent<CardGraveyard>();
            CardGraveyard.OnPileChanged += Sort;
        }

        //--------------------------------------------------------------------------------------------------------------

        public void Sort(ICard[] cards)
        {
            if (cards == null)
                throw new ArgumentException("Can't sort a card list null");

            var lastPos = cards.Length - 1;
            var lastCard = cards[lastPos];
            var gravPos = graveyardPosition.position + new Vector3(0, 0, -5);
            var backGravPos = graveyardPosition.position;

            //move last
            lastCard.MoveToWithZ(gravPos, parameters.MovementSpeed);

            //move others
            for (var i = 0; i < cards.Length - 1; i++)
            {
                var card = cards[i];
                card.MoveToWithZ(backGravPos, parameters.MovementSpeed);
            }
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}