using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Scripts.Manager
{
    public class WeaponManager : MonoBehaviour
    {
        [Header("Weapons Prefabs")] 
        [SerializeField] private List<GameObject> primary = new List<GameObject>();
        [SerializeField] private List<GameObject> secondary = new List<GameObject>();
        [SerializeField] private List<GameObject> throwable = new List<GameObject>();

        [Header("FX")] 
        [SerializeField] private GameObject gunFlash;
        
        public GameObject GetPrimary()
        {
            // var rand = new Random();
            // return primary[rand.Next(0, primary.Count - 1)];
            return primary[0];
        }
    }
}