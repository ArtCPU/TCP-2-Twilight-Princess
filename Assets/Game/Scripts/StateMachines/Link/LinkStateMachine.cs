using System.Diagnostics;
using Game.Controller;
using Game.Input;

namespace Game.State
{
    public class LinkStateMachine : StateMachine
    {
        public LinkStateFactory StateFactory { get; private set; }
        public LinkController LinkController { get; private set; }
        public LinkInputController InputController { get; private set; }

        private HitReceiver hitReceiver;
        private void Awake()
        {
            LinkController = GetComponent<LinkController>();
            InputController = GetComponent<LinkInputController>();
            StateFactory = new LinkStateFactory(LinkController, this);
            CurrentState = StateFactory.Idle;
            hitReceiver = GetComponentInChildren<HitReceiver>();
        }

        private void OnEnable()
        {
            hitReceiver.Hit += OnHit;
        }
        private void Start()
        {
            InputController.SetActive(true);
        }
        public void TryPerformIdle()
        {
            if (LinkController.PhysicsProcessor.IsGrounded && InputController.MovementDirection.magnitude <= 0)
            {
                SetState(StateFactory.Idle);
            }
        }
        public void TryPerformWalk()
        {
            if (LinkController.PhysicsProcessor.IsGrounded && InputController.Walk.IsPressed() && InputController.MovementDirection.magnitude > 0 &&
                InputController.MovementDirection.magnitude <= 0.5f)
            {
                SetState(StateFactory.Walk);
            }
        }
        public void TryPerformRun()
        {
            if (LinkController.PhysicsProcessor.IsGrounded && InputController.Walk.IsPressed() && InputController.MovementDirection.magnitude >= 0.6)
            {
                SetState(StateFactory.Run);
            }
        }
        public void TryPerformJump()
        {
            if (!LinkController.PhysicsProcessor.IsGrounded && !LinkController.PhysicsProcessor.IsOnStairs)
            {
                SetState(StateFactory.Jump);
            }
        }
        public void TryPerformCombat()
        {
            if(LinkController.PhysicsProcessor.IsGrounded && InputController.Attack.IsPressed())
            {
                SetState(StateFactory.CombatState);
            }
        }

        public void TryPerformGuard()
        {
            if (LinkController.PhysicsProcessor.IsGrounded && InputController.Guard.IsPressed())
            {
                SetState(StateFactory.Guard);
            }

        }
        public void TryPerformAim()
        {

        }

        public void TryPerformTargetLock()
        {
            if (LinkController.TargetManager.Targets.Count > 0 && InputController.TargetLock.WasPressedThisFrame())
            {
                SetState(StateFactory.TargetLock);
            }
        }

        public void OnHit(HitController attackerHitController)
        {
            SetState(StateFactory.Hurt);
            UnityEngine.Debug.Log(attackerHitController == null);
            LinkController.CombatData.DecreaseHP(attackerHitController.AttackerCombatData.Attack);
        }

        public void TryPerformDeath()
        {

        }


        private void OnDisable()
        {
            hitReceiver.Hit -= OnHit;
        }
    }
}