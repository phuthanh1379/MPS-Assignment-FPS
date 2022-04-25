using Scripts.Characteristics;
using Scripts.Weapon;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public GunController gunController;
        public HitPoint playerHP;
        public bool IsDead;

        private void Update()
        {
            if (playerHP == null) return;
            if (playerHP.CurrentPoint <= 0)
                Die();
        }

        public void Init()
        {
            // Gun
            if (gunController == null)
            {
                gunController = gameObject.AddComponent<GunController>();
            }
            gunController.Init();
            
            // HP
            playerHP = new HitPoint(10, 10);
            IsDead = false;
            // transform.localPosition = new Vector3(9f, 1f, 1f);
        }

        private void Die()
        {
            // Do something
            IsDead = true;
        }
    }
}