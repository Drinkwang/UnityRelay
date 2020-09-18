using UnityEngine;

namespace ZCard
{
    public interface ICardTransform
    {
        MotionBaseCard Movement { get; }
        MotionBaseCard Rotation { get; }
        MotionBaseCard Scale { get; }

        void MoveTo(Vector3 position, float speed, float delay = 0);
        void MoveToWithZ(Vector3 position, float speed, float delay = 0);
        void RotateTo(Vector3 euler, float speed);
        void ScaleTo(Vector3 scale, float speed, float delay = 0);
    }
}