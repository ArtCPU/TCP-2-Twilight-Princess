using Game.Controller;
using UnityEngine;
namespace Game.State
{
    public class TargetLockState : LinkBaseState
    {
        private float lockOnDelay = 0.8f;
        private float elapsedTime;
        public TargetLockState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {
        }

        public override void Enter()
        {
            linkController.TargetManager.LockOnTarget();
        }

        public override void Exit()
        {
            linkController.TargetManager.ReleaseTarget();
            linkController.TargetManager.LookAtPlayer();
            elapsedTime = 0;
        }

        public override void FixedUpdate()
        {
            if (linkController.InputController.TargetLock.IsPressed())
            linkController.TargetManager.LookAtTarget(linkController.TargetManager.LockedTarget.transform);
            linkController.TargetManager.UpdateLockOnTarget();
            linkController.TargetManager.UpdateNextTargetWarning();
        }

        public override void Update()
        {
            VerifyDelayTime();

            if (elapsedTime > lockOnDelay)
            {
                stateMachine.TryPerformIdle();
                stateMachine.TryPerformWalk();
                stateMachine.TryPerformRun();
                stateMachine.TryPerformJump();
            }
        }

        private void VerifyDelayTime()
        {
            bool releasedThisFrame = linkController.InputController.TargetLock.WasReleasedThisFrame();
            bool pressedThisFrame = linkController.InputController.TargetLock.WasPressedThisFrame();
            if (releasedThisFrame)
            {
                linkController.TargetManager.LookAtPlayer();
                linkController.TargetManager.WarnNextTarget();
                elapsedTime += Time.deltaTime;
                return;
            }

            if (pressedThisFrame)
            {
                elapsedTime = 0;
                linkController.TargetManager.LockOnNextTarget();
                return;
            }

            if (elapsedTime != 0) elapsedTime += Time.deltaTime;
        }
    }
}