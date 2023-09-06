using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName="Turret Shop Setting")]
    public class TurretSettings : ScriptableObject
    {
        public GameObject TurretPrefabs;
        public int TurretShopCost;
        public Sprite TurretShopSprite;
    }

