using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TurretCard : MonoBehaviour
{
    public static Action<TurretSettings> OnPlaceTurret;
    [SerializeField] private Image turretImage;
    [SerializeField] private Text turretCost;
    public GameController GC;

    void Start()
    {
        GC = FindObjectOfType<GameController>();
    }
    public TurretSettings TurretLoaded { get; set; }

    public void SetupTurretButton(TurretSettings turretSettings)
    {
        TurretLoaded = turretSettings;
        turretImage.sprite = turretSettings.TurretShopSprite;
        turretCost.text = turretSettings.TurretShopCost.ToString();
    }

    public void PlaceTurret()
    {
        UIManager.UI.CloseTurretShopPanel();
        if (int.Parse(turretCost.text) <= Player.Gold)
        {
            UIManager.UI.CloseTurretShopPanel();
            GameObject a = Instantiate(TurretLoaded.TurretPrefabs, GC.turretPoint, Quaternion.identity);
            if (a.CompareTag("Normal"))
            {
                a.GetComponent<NormalGun>().isNew();
            }
            if (a.CompareTag("Explosion"))
            {
                a.GetComponent<ExplosionGun>().isNew();
            }
            GC.ListTurret.Add(a);
            GC.canClick = true;
            Player.Gold = Player.Gold - int.Parse(turretCost.text);
        }

    }
}
