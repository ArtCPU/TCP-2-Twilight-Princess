using Game.State;
using UnityEngine;

namespace Game.DamageSystem
{
    [RequireComponent(typeof(Life))]
    public class Damageable : MonoBehaviour
    {
        private LinkStateMachine stateMachine;
        public int DamageAmount {  get; private set; }
        private void Start()
        {
            stateMachine = GetComponent<LinkStateMachine>();
                //!= null? GetComponent<LinkStateMachine>() : null;
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Sword"))
        //    {
        //        DamageAmount = 1;
        //    }

        //    stateMachine.SetState(stateMachine.StateFactory.Hurt);
        //}

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.T))
        //    {
        //        DamageAmount = 1;
        //        stateMachine.SetState(stateMachine.StateFactory.Hurt);
        //    }
        //}
    }
}