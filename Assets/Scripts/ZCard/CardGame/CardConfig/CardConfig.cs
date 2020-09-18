using UnityEngine;

namespace ZCard
{
    [CreateAssetMenu(menuName = "Card Config")]
    public class CardConfig : ScriptableObject
    {
        [Header("Disable")] [SerializeField] [Range(0.1f, 1)]
        public float DisabledAlpha;

        #region Hover
        [Header("Hover")] [SerializeField] [Range(0, 4)]
        public float HoverHeight;

        [SerializeField]
        public bool HoverRotation;

        [SerializeField] [Range(0.9f, 2f)]
        public float HoverScale;

        [SerializeField] [Range(0, 25)]
        public float HoverSpeed;
        #endregion

        #region Bend
        [Header("Bend")] [SerializeField] [Range(0f, 1f)]
        public float Height;

        [SerializeField] [Range(0f, -5f)]
        public float Spacing;

        [SerializeField] [Range(-60, 60)]
        public float BentAngle;
        #endregion

        #region Movement
        [Header("Rotation")] [SerializeField] [Range(0, 60)] 
        public float RotationSpeed;

        [Header("Movement")] [SerializeField] [Range(0, 15)] 
        public float MovementSpeed;

        [Header("Scale")] [SerializeField] [Range(0, 15)]
        public float ScaleSpeed;
        #endregion

        [Header("Draw")] [SerializeField] [Range(0, 1)] 
        public float StartSizeWhenDraw;

        [Header("Discard")] [SerializeField] [Range(0, 1)]
        public float DiscardedSize;
        
        [Button]
        public void SetDefaults()
        {
            DisabledAlpha = 0.5f;

            HoverHeight = 0.6f;
            HoverRotation = false;
            HoverScale = 1.3f;
            HoverSpeed = 15f;

            Height = 0.1f;
            Spacing = -1.8f;
            BentAngle = -20;

            RotationSpeed = 20;
            MovementSpeed = 4;
            ScaleSpeed = 7;

            StartSizeWhenDraw = 0.05f;
            DiscardedSize = 0.5f;
        }
    }
}