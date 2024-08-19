using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{

    public enum TagTargets
    {
        Player = 1,
        Enemy = 2,
        NPC = 4
    }
    public class TargetDetector : MonoBehaviour
    {
        [ReadOnly(false)]
        protected Collider rangeCollider;
        public Collider RangeCollider => rangeCollider;
        [SerializeField] private TagTargets tagTargets;

        private List<Collider> targets = new();
        public List<Collider> Targets { get { return targets; } }
        public event Action<Collider> OnTargetEnter = delegate { };
        public event Action<Collider> OnTargetExit = delegate { };
       

        private void Awake()
        {
            rangeCollider = GetComponent<Collider>();
        }

        private void Start()
        {
            RemoveDuplicatedColliders(this.gameObject, rangeCollider);
        }
        private void OnEnable()
        {
            targets.Clear();
            targets.TrimExcess();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsTargetTag(tagTargets)) if (!targets.Contains(other))

                {
                    targets.Add(other);
                    //GameEvents.Instance.TargetView(other.gameObject.GetComponent<Targetable>());
                    OnTargetEnter(other);
                }
                else Debug.Log(other.gameObject.name);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsTargetTag(tagTargets))
                if (targets.Contains(other))
                {
                    targets.Remove(other);
                    //GameEvents.Instance.TargetUnview(other.GetComponent<Targetable>());
                    OnTargetExit(other);
                }
        }
        public void RemoveDuplicatedColliders(GameObject gameObject, Collider keepedCollider)
        {
            foreach (var collider in gameObject.GetComponents<Collider>())
            {
                if (keepedCollider != collider) Destroy(collider);
            }
        }
    }
}






