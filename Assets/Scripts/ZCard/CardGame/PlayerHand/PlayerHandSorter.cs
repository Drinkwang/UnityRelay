using System;
using UnityEngine;

namespace ZCard
{
    [RequireComponent(typeof(IPlayerHand))]
    public class PlayerHandSorter : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        const int OffsetZ = -1;
        ICardPile PlayerHand { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void Awake()
        {
            PlayerHand = GetComponent<IPlayerHand>();
            PlayerHand.OnPileChanged += Sort;
        }

        //--------------------------------------------------------------------------------------------------------------

        public void Sort(ICard[] cards)
        {
            if (cards == null)
                throw new ArgumentException("Can't sort a card list null");

            var layerZ = 0;
            foreach (var card in cards)
            {
                var localCardPosition = card.transform.localPosition;
                localCardPosition.z = layerZ;
                card.transform.localPosition = localCardPosition;
                layerZ += OffsetZ;
            }
        }

        //--------------------------------------------------------------------------------------------------------------
    }
}