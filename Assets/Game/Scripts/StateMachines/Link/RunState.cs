using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.State
{
    public class RunState : BaseState
    {
        PlayerMovement playerMovement;
        public RunState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
        }
        
        
        public override void Enter()
        {
            playerMovement = character.GetComponent<PlayerMovement>();
            //Debug.Log("Entered the RUN state");
        }

        public override void Exit()
        {
            //Debug.Log("Exited the RUN state");
        }

        public override void FixedUpdate()
        {
            playerMovement.UpdateMoveDirection();
            if (playerMovement.IsIdle())
            {
                playerMovement.SetState(playerMovement.stateMachine.StateFactory.Idle);
            }

            if (!playerMovement.IsGrounded())
            {
                playerMovement.SetState(playerMovement.stateMachine.StateFactory.Jump);
            }
            playerMovement.Move();
        }

        public override void Update()
        {            
            
        }


            
    }
}