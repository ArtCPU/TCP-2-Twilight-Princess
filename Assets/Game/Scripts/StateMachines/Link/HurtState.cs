using UnityEngine;

namespace Game.State
{
    public class HurtState : BaseState
    {
        private Damageable damageable;
        private Life life;
        private PlayerMovement playerMovement;
        public HurtState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            damageable = character.GetComponent<Damageable>();
            life = character.GetComponent<Life>();
            playerMovement = character.GetComponent<PlayerMovement>();
        }

        public override void Enter()
        {
            GameEvents.Instance.Damage(damageable.DamageAmount);
        }

        public override void Exit()
        {
           
        }

        public override void FixedUpdate()
        {
            if (life.Death())
            {
                playerMovement.SetState(playerMovement.stateMachine.StateFactory.Death);
            }

            else playerMovement.SetState(playerMovement.stateMachine.PreviousState);
        }
        public override void Update()
        {
            
        }
    }
}