using Game.Controller;

namespace Game.State
{
    public abstract class LinkBaseState : BaseState
    {
        protected LinkController linkController;
        protected new LinkStateMachine stateMachine;
        public LinkBaseState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine)
        {
            stateMachine = currentStateMachine;
            this.linkController = linkController;
        }

    }
}