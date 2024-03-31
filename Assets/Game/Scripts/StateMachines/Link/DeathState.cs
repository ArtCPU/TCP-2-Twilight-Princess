using UnityEngine;

namespace Game.State
{
    public class DeathState : BaseState
    {
        private PlayerMovement playerMovement;
        private Life life;
        public DeathState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            playerMovement = character.GetComponent<PlayerMovement>();
            life = character.GetComponent<Life>(); 
        }

        public override void Enter()
        {
            Debug.Log("You Died!");
        }

        public override void Exit()
        {
            life.IncreaseLife(10);
        }

        public override void FixedUpdate()
        {
            playerMovement.SetState(playerMovement.stateMachine.StateFactory.Idle);
        }

        public override void Update()
        {
            
        }
    }
}