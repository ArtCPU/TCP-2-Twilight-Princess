using UnityEngine;
namespace Game.State
{
    public class IdleState : BaseState
    {
        PlayerMovement playerMovement;
        public IdleState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            playerMovement = character.GetComponent<PlayerMovement>();
        }

        public override void Enter()
        {
            playerMovement.UpdateMoveDirection();
            Debug.Log("Entered the IDLE state");
        }

        public override void Exit()
        {
            Debug.Log("Exited the IDLE state");
        }

        public override void FixedUpdate()
        {
            if (playerMovement.IsIdle())
            {
                playerMovement.UpdateMoveDirection();
            }

            if (!playerMovement.IsIdle())
            {
                playerMovement.SetState(playerMovement.stateMachine.StateFactory.Run);
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