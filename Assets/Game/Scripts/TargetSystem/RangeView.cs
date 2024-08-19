using UnityEngine;

namespace Game
{

    public abstract class RangeView
    {
        protected float size = 1f;
        public GameObject GameObject { get; protected set; }
        [field: SerializeField] public Collider Collider { get; protected set; }

        public RangeView(GameObject gameObject, float size)
        {
            this.size = size;
            GameObject = gameObject;

        }

        protected abstract Collider GenerateCollider(GameObject gameObject, float size);

        public Collider RegenerateCollider()
        {
            return GenerateCollider(GameObject, size);
        }

        public Collider RegenerateCollider(float size)
        {
            return GenerateCollider(GameObject, size);
        }

    }
}
