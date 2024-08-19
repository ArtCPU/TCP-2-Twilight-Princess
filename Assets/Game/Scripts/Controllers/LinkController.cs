using Game.Input;
using UnityEngine;
namespace Game.Controller
{
    [RequireComponent(typeof(CharacterController))]
    public class LinkController : MonoBehaviour, ICharacterController
    {
        [field: SerializeField] public LinkMovementData MovementData { get; private set; }
        [field: SerializeField] public LinkCombatData CombatData { get; private set; }
        public LinkAnimationController AnimationController { get; private set; }
        public LinkInputController InputController { get; private set; }
        public PhysicsProcessor PhysicsProcessor { get; private set; }
        public LinkActions LinkActions { get; private set; }
        public TargetManager TargetManager { get; private set; }
        public HitController HitController { get; private set; }

        void Awake()
        {
            PhysicsProcessor = GetComponent<PhysicsProcessor>();
            InputController = GetComponent<LinkInputController>();
            AnimationController = GetComponent<LinkAnimationController>();
            TargetManager = GetComponent<TargetManager>();
            LinkActions = new LinkActions(PhysicsProcessor, MovementData, InputController);
            CombatData = Instantiate(CombatData);
            CombatData.Initialize();
            HitController = new HitController(CombatData);
        }

    }
}

