using System;
using System.Collections;
using UnityEngine;

namespace ZCard
{
    public abstract class MotionBaseCard
    {
        public Action OnFinishMotion = () => { };

        protected MotionBaseCard(ICard handler) => Handler = handler;

        public bool IsOperating { get; protected set; }

        protected virtual float Threshold => 0.01f;

        protected Vector3 Target { get; set; }

        protected ICard Handler { get; }

        protected float Speed { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        public void Update()
        {
            if (!IsOperating)
                return;

            if (CheckFinalState())
                OnMotionEnds();
            else
                KeepMotion();
        }
        protected abstract bool CheckFinalState();

        protected virtual void OnMotionEnds() => OnFinishMotion?.Invoke();

        protected abstract void KeepMotion();

        public virtual void Execute(Vector3 vector, float speed, float delay = 0, bool withZ = false)
        {
            Speed = speed;
            Target = vector;
            if (delay == 0)
                IsOperating = true;
            else
                Handler.MonoBehavior.StartCoroutine(AllowMotion(delay));
        }

        IEnumerator AllowMotion(float delay)
        {
            yield return new WaitForSeconds(delay);
            IsOperating = true;
        }

        public virtual void StopMotion() => IsOperating = false;
    }
}