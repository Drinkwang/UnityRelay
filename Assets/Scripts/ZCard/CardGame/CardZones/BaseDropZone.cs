using UnityEngine;
using UnityEngine.EventSystems;

namespace ZCard
{
    /// <summary>
    ///     Base zones where the user can drop a UI Card.
    /// </summary>
    [RequireComponent(typeof(IMouseInput))]
    public abstract class BaseDropZone : MonoBehaviour
    {
        protected IPlayerHand CardHand { get; set; }
        protected IMouseInput Input { get; set; }

        protected virtual void Awake()
        {
            CardHand = transform.parent.GetComponentInChildren<IPlayerHand>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerUp += OnPointerUp;
        }

        protected virtual void OnPointerUp(PointerEventData eventData)
        {
        }
    }
}