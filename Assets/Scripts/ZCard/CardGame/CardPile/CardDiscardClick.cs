using UnityEngine;
using UnityEngine.EventSystems;

namespace ZCard
{
    /// <summary>
    ///     Dicard/Play cards when the object is clicked.
    /// </summary>
    [RequireComponent(typeof(IMouseInput))]
    public class CardDiscardClick : MonoBehaviour
    {
        PlayerHandUtils Utils { get; set; }
        IMouseInput Input { get; set; }

        void Awake()
        {
            Utils = transform.parent.GetComponentInChildren<PlayerHandUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += PlayRandom;
        }

        void PlayRandom(PointerEventData obj) => Utils.PlayCard();
    }
}