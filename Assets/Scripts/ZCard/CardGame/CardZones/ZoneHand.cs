using UnityEngine.EventSystems;

namespace ZCard
{
    /// <summary>
    ///     GameController hand zone.
    /// </summary>
    public class ZoneHand : BaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData) => CardHand?.Unselect();
    }
}