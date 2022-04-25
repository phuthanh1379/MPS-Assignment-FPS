using System;
using DG.Tweening;
using Scripts.Enemy;
using Scripts.Manager;
using UnityEngine;

namespace Scripts.Weapon
{
    public class GunController : MonoBehaviour
    {
        #region Variables

        public bool CanShoot { get; set; }
        public int BulletsPerMagazine { get; set; }
        public int Bullets { get; set; }
        public int RemainMagazine { get; set; }
        public int MaxNumberOfMagazine { get; set; }

        [SerializeField] private WeaponManager weaponManager;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject gunSplashPrefab;
        
        private GameObject _gun;
        private GameObject _gunSplash;
        private RaycastHit _hit;
        private bool _isShooting = false;

        // Constants
        private static readonly Vector3 BasePosition = new Vector3(0.5f, -0.5f, 0.5f);
        private static readonly Vector3 AimPosition = new Vector3(0f, -0.35f, 0.5f);

        #endregion

        public void Init()
        {
            // Settings
            BulletsPerMagazine = 30;
            Bullets = BulletsPerMagazine;
            MaxNumberOfMagazine = 3;
            RemainMagazine = MaxNumberOfMagazine;
            CanShoot = true;
            
            // Spawn gun
            _gun = Instantiate(weaponManager.GetPrimary(), mainCamera.transform);
            _gun.transform.localPosition = BasePosition;
            _gunSplash = Instantiate(gunSplashPrefab, _gun.transform);
            _gunSplash.transform.localPosition = new Vector3(0.02f, 0.15f, 1.25f);
            _gunSplash.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _gunSplash.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            _gunSplash.SetActive(false);
        }

        public void StartAim()
        {
            _gun.transform.DOLocalMove(AimPosition, 0.25f);
        }

        public void StopAim()
        {
            _gun.transform.DOLocalMove(BasePosition, 0.25f);
        }
        
        public void TryShoot()
        {
            if (Bullets <= 0)
            {
                TryReload();
                _isShooting = false;
            }
            else
            {
                Bullets--;
                _isShooting = true;
                // Debug.Log($"{Bullets}");
            }
        }

        public void TryReload()
        {
            if (RemainMagazine <= 0)
                Debug.Log("Out of ammo");
            else
            {
                Bullets = BulletsPerMagazine;
                RemainMagazine--;
                Debug.Log($"{Bullets}/{RemainMagazine*BulletsPerMagazine}");
            }
        }

        private void FixedUpdate()
        {
            if (!_isShooting)
            {
                _gunSplash.SetActive(false);
            }
            else
            {
                _gunSplash.SetActive(true);
                if (Physics.Raycast(
                    _gun.transform.position, 
                    _gun.transform.TransformDirection(Vector3.forward), 
                    out _hit, 
                    Mathf.Infinity)
                )
                {
                    // Debug.Log($"{_hit.collider.tag}, {_hit.collider.name},");
                    Debug.DrawRay(
                        _gun.transform.position, 
                        _gun.transform.TransformDirection(Vector3.forward) * _hit.distance, 
                        Color.yellow
                    );

                    if (_hit.collider.CompareTag("Enemy"))
                    {
                        _hit.collider.GetComponent<EnemyController>().Hit(_hit.point);
                    }
                
                }
                else
                {
                    Debug.DrawRay(
                        _gun.transform.position, 
                        _gun.transform.TransformDirection(Vector3.forward) * 1000, 
                        Color.white
                    );
                    Debug.Log("Did not Hit");
                }
                _isShooting = false;
            }
        }
    }
}