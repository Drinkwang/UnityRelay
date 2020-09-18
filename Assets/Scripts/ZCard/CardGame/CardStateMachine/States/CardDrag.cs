﻿// using Extensions;
using UnityEngine;

namespace ZCard
{
    public class CardDrag : BaseCardState
    {
        public CardDrag(ICard handler, Camera camera, BaseStateMachine fsm, CardConfig parameters) : base(
            handler, fsm, parameters) =>
            MyCamera = camera;
        //--------------------------------------------------------------------------------------------------------------

        Vector3 StartEuler { get; set; }
        Camera MyCamera { get; }

        //--------------------------------------------------------------------------------------------------------------


        Vector3 WorldPoint()
        {
            var mousePosition = Handler.Input.MousePosition;
            var worldPoint = MyCamera.ScreenToWorldPoint(mousePosition);
            return worldPoint;
        }

        void FollowCursor()
        {
            var myZ = Handler.transform.position.z;
            Handler.transform.position = WorldPoint().WithZ(myZ);
        }

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public override void OnUpdate() => FollowCursor();

        public override void OnEnterState()
        {
            //stop any movement
            Handler.Movement.StopMotion();

            //cache old values
            StartEuler = Handler.transform.eulerAngles;

            Handler.RotateTo(Vector3.zero, Parameters.RotationSpeed);
            MakeRenderFirst();
            RemoveAllTransparency();
        }

        public override void OnExitState()
        {
            //reset position and rotation
            if (Handler.transform)
            {
                Handler.RotateTo(StartEuler, Parameters.RotationSpeed);
                MakeRenderNormal();
            }

            DisableCollision();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}