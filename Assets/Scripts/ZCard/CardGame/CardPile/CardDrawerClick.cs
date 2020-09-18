using UnityEngine;
using UnityEngine.EventSystems;

namespace ZCard
{
    [RequireComponent(typeof(IMouseInput))]
    public class CardDrawerClick : MonoBehaviour
    {
        PlayerHandUtils CardDrawer { get; set; }
        IMouseInput Input { get; set; }

        void Awake()
        {
            CardDrawer = transform.parent.GetComponentInChildren<PlayerHandUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += DrawCard;
        }

        void DrawCard(PointerEventData obj) => CardDrawer.DrawCard();
    }
}