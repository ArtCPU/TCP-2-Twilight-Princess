using UnityEngine;
namespace Game.State
{
    public class Life : MonoBehaviour
    {
        [SerializeField] int maxLife;

        [Header("Press 'T' to do damage")]
        [SerializeField] int currentLife;

        private void Start()
        {
            currentLife = maxLife;
            GameEvents.Instance.OnDamage += DecreaseLife;
        }
        public void IncreaseLife(int amount)
        {
            currentLife+= amount;
        }
        public void DecreaseLife(int amount)
        {
            currentLife -= amount;     
        }
        public bool Death()
        {
            if (currentLife <= 0)
            {
                return true;
            }

            return false;
        }
    }
}