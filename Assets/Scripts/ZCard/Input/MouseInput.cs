using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZCard
{
    public interface IMouseInput :
        IPointerClickHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler,
        IDropHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        new Action<PointerEventData> OnPointerClick { get; set; }
        new Action<PointerEventData> OnPointerDown { get; set; }
        new Action<PointerEventData> OnPointerUp { get; set; }

        new Action<PointerEventData> OnBeginDrag { get; set; }
        new Action<PointerEventData> OnDrag { get; set; }
        new Action<PointerEventData> OnEndDrag { get; set; }
        new Action<PointerEventData> OnDrop { get; set; }

        new Action<PointerEventData> OnPointerEnter { get; set; }
        new Action<PointerEventData> OnPointerExit { get; set; }

        Vector2 MousePosition { get; }
        DragDirection DragDirection { get; }
    }

    public enum DragDirection
    {
        None,
        Down,
        Left,
        Top,
        Right
    }


    [RequireComponent(typeof(Collider))]
    public class MouseInput : MonoBehaviour, IMouseInput
    {
        //----------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        void Awake()
        {
            if (Camera.main.GetComponent<PhysicsRaycaster>() == null)
                throw new Exception(GetType() + " needs an " + typeof(PhysicsRaycaster) + " on the MainCamera");
        }

        #endregion

        #region Drag Direction

        DragDirection GetDragDirection()
        {
            var currentPosition = Input.mousePosition;
            var normalized = (currentPosition - oldDragPosition).normalized;
            oldDragPosition = currentPosition;

            if (normalized.x > 0)
                return DragDirection.Right;

            if (normalized.x < 0)
                return DragDirection.Left;

            if (normalized.y > 0)
                return DragDirection.Top;

            return normalized.y < 0 ? DragDirection.Down : DragDirection.None;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Delegates 

        Action<PointerEventData> IMouseInput.OnPointerDown { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerUp { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerClick { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnBeginDrag { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnDrag { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnEndDrag { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnDrop { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerEnter { get; set; } = eventData => { };
        Action<PointerEventData> IMouseInput.OnPointerExit { get; set; } = eventData => { };

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Properties and Fields

        Vector3 oldDragPosition;
        DragDirection IMouseInput.DragDirection => GetDragDirection();
        Vector2 IMouseInput.MousePosition => Input.mousePosition;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Unity Mouse Events

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) =>
            ((IMouseInput) this).OnBeginDrag.Invoke(eventData);

        void IDragHandler.OnDrag(PointerEventData eventData) => ((IMouseInput) this).OnDrag.Invoke(eventData);

        void IDropHandler.OnDrop(PointerEventData eventData) => ((IMouseInput) this).OnDrop.Invoke(eventData);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) => ((IMouseInput) this).OnEndDrag.Invoke(eventData);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerClick.Invoke(eventData);

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerDown.Invoke(eventData);

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerUp.Invoke(eventData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerEnter.Invoke(eventData);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) =>
            ((IMouseInput) this).OnPointerExit.Invoke(eventData);

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}