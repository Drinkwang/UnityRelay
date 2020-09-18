using System;
using UnityEngine;

namespace ZCard
{
    [RequireComponent(typeof(IPlayerHand))]
    public class PlayerHandBender : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        void Awake()
        {
            PlayerHand = GetComponent<IPlayerHand>();
            CardRenderer = CardPrefab.GetComponent<SpriteRenderer>();
            PlayerHand.OnPileChanged += Bend;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Fields and Properties

        [SerializeField] CardConfig parameters;

        [SerializeField] 
        CardComponent CardPrefab;

        [SerializeField] 
        Transform pivot;

        SpriteRenderer CardRenderer { get; set; }
        float CardWidth => CardRenderer.bounds.size.x;
        IPlayerHand PlayerHand { get; set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        void Bend(ICard[] cards)
        {
            if (cards == null)
                throw new ArgumentException("Can't bend a card list null");

            var fullAngle = -parameters.BentAngle;
            var anglePerCard = fullAngle / cards.Length;
            var firstAngle = CalcFirstAngle(fullAngle);
            var handWidth = CalcHandWidth(cards.Length);

            var pivotLocationFactor = pivot.CloserEdge(Camera.main, Screen.width, Screen.height);

            //calc first position of the offset on X axis
            var offsetX = pivot.position.x - handWidth / 2;

            for (var i = 0; i < cards.Length; i++)
            {
                var card = cards[i];

                //set card Z angle
                var angleTwist = (firstAngle + i * anglePerCard) * pivotLocationFactor;

                //calc x position
                var xPos = offsetX + CardWidth / 2;

                //calc y position
                var yDistance = Mathf.Abs(angleTwist) * parameters.Height;
                var yPos = pivot.position.y - yDistance * pivotLocationFactor;

                //set position
                if (!card.IsDragging && !card.IsHovering)
                {
                    var zAxisRot = pivotLocationFactor == 1 ? 0 : 180;
                    var rotation = new Vector3(0, 0, angleTwist - zAxisRot);
                    var position = new Vector3(xPos, yPos, card.transform.position.z);

                    var rotSpeed = parameters.RotationSpeed;
                    card.RotateTo(rotation, rotSpeed);
                    card.MoveTo(position, parameters.MovementSpeed);
                }

                //increment offset
                offsetX += CardWidth + parameters.Spacing;
            }
        }

        static float CalcFirstAngle(float fullAngle)
        {
            var magicMathFactor = 0.1f;
            return -(fullAngle / 2) + fullAngle * magicMathFactor;
        }

        float CalcHandWidth(int quantityOfCards)
        {
            var widthCards = quantityOfCards * CardWidth;
            var widthSpacing = (quantityOfCards - 1) * parameters.Spacing;
            return widthCards + widthSpacing;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}