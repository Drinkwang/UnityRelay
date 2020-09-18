using UnityEngine.EventSystems;

namespace ZCard
{
    /// <summary>
    ///     Battlefield Zone.
    /// </summary>
    public class ZoneBattleField : BaseDropZone
    {
        protected override void OnPointerUp(PointerEventData eventData) => CardHand?.PlaySelected();
    }
}