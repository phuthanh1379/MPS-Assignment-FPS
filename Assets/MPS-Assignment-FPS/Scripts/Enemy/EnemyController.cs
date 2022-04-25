using System;
using System.Collections.Generic;
using Scripts.Characteristics;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        // private List<Vector3> _patrolPoints = new List<Vector3>();
        
        private GameObject _bloodSplatterFx;
        private HitPoint _hitPoint;
        private bool _isDead = false;
        
        public void Init(GameObject bloodSplatterFx, float initialRotY)
        {
            _bloodSplatterFx = bloodSplatterFx;
            // Position
            transform.localPosition = new Vector3(10f, 0f, 10f);
            transform.localRotation = Quaternion.Euler(0f, initialRotY , 0f);
            // HP
            _hitPoint = new HitPoint(3, 3);
            _isDead = false;
            // Add collider
            gameObject.AddComponent<CapsuleCollider>().center = new Vector3(0f, 1.5f, 0f);
            GetComponent<CapsuleCollider>().height = 3f;
            // // Init patrolPoints
            // _patrolPoints = patrolPoints;
        }

        public void Hit(Vector3 point)
        {
            _hitPoint.CurrentPoint -= 1;
            if (_hitPoint.CurrentPoint <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var blood = Instantiate(_bloodSplatterFx, transform);
                blood.transform.localPosition = point;
            }
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * 0.002f);
        }
    }
}