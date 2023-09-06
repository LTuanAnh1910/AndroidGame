using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager UI;
    public GameObject TurretShop;
    public GameObject TurretInfo;
    public GameController GC;

    public void Awake()
    {
        UI= this;
        GC = FindObjectOfType<GameController>();
    }

    public void CloseTurretShopPanel()
    {
        TurretShop.SetActive(false);
        GC.canClick = true;
    }

    public void CloseTurretInfo()
    {
        TurretInfo.SetActive(false);
        GC.canClick = true;
    }

    //public void SellTurret()
    //{
    //    Destroy(GC.Turret);
    //    TurretInfo.SetActive(false);
    //    GC.canClick = true;
    //}
}
