using Scripts.Characteristics;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public HitPoint playerHP;
        public bool IsDead;

        private void Update()
        {
            if (playerHP.CurrentPoint <= 0)
                Die();
        }

        public void Init()
        {
            IsDead = false;
        }

        private void Die()
        {
            // Do something
            IsDead = true;
        }
    }
}