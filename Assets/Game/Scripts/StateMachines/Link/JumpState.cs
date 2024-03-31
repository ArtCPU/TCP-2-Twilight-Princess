using UnityEngine;
namespace Game.State
{
    public class JumpState : BaseState
    {
        PlayerMovement playerMovement;
        public JumpState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
        }

        public override void Enter()
        {
            playerMovement = character.GetComponent<PlayerMovement>();
            playerMovement.SetJumpVariables();
            playerMovement.Jump();
            Debug.Log("Entered the JUMP state");
        }

        public override void Exit()
        {
            playerMovement.ResetGravityVector();
            playerMovement.ResetJumpVector();
            Debug.Log(" Exited the JUMP state");
        }

        public override void FixedUpdate()
        {
            if (playerMovement.IsGrounded() && !playerMovement.IsIdle())
            {
                playerMovement.SetState(playerMovement.stateMachine.StateFactory.Run);
            }

            if (playerMovement.IsGrounded() && playerMovement.IsIdle())
            {
                playerMovement.SetState(playerMovement.stateMachine.StateFactory.Idle);
            }

            if (!playerMovement.IsGrounded())
            {
                playerMovement.AplyGravity();
            }

            playerMovement.Move();

        }

        public override void Update()
        {
            
        }
    }
}