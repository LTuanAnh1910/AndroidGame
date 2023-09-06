using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layer;
    public LayerMask Gunlayer;
    public Vector3 turretPoint;
    public bool canClick = true;
    public GameObject Turret;
    public List<GameObject> ListTurret;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    public void Click()
    {
        if (canClick)
        {
            screenPosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            transform.position = worldPosition;
            Collider2D hit = Physics2D.OverlapCircle(worldPosition, .5f, layer);
            Collider2D hit1 = Physics2D.OverlapCircle(worldPosition, .5f, Gunlayer);

            if (hit != null && hit1 == null)
            {
                turretPoint = hit.transform.position;
                UIManager.UI.TurretShop.SetActive(true);
                canClick = false;

            }
            if (hit != null && hit1 != null)
            {
                int level = 0;
                int gunAtk = 0;
                int gunRange = 0;
                float gunReload = 0;
                int gunGold = 0;
                int upgradeGold = 0;
                int sellGold = 0;
                turretPoint = hit.transform.position;
                UIManager.UI.TurretShop.SetActive(false);
                Turret = hit1.gameObject;
                if (Turret.CompareTag("Normal"))
                {
                    NormalGun normalGun = Turret.GetComponent<NormalGun>();
                    level = normalGun.Level;
                    gunAtk = normalGun.Atk;
                    gunRange = normalGun.Range;
                    gunReload = normalGun.Reload;
                    gunGold = normalGun.Gold;
                    upgradeGold = normalGun.upgradeGold;
                    sellGold = normalGun.sellGold;

                }
                else if (Turret.CompareTag("Explosion"))
                {
                    ExplosionGun explosionGun = Turret.GetComponent<ExplosionGun>();
                    level = explosionGun.Level;
                    gunAtk = explosionGun.Atk;
                    gunRange = explosionGun.Range;
                    gunReload = explosionGun.Reload;
                    gunGold = explosionGun.Gold;
                    upgradeGold = explosionGun.upgradeGold;
                    sellGold = explosionGun.sellGold;
                }
                if (Turret == null)
                {
                    Debug.Log("null");
                }
                UIManager.UI.TurretInfo.SetActive(true);
                canClick = false;
                TurretInfo.turretInfo.setInfoText("Level: " + level, "Attack: " + gunAtk,
                    "Reload: " + gunReload, "Range: " + gunRange, "Gold: " + gunGold,
                    "Upgrade: " + upgradeGold, "Sell: " + sellGold);

            }
        }
    }

    public void checkUpdate()
    {
        if (Turret.CompareTag("Normal"))
        {
            NormalGun normalGun = Turret.GetComponent<NormalGun>();
            if (normalGun.upgradeGold <= Player.Gold)
            {
                Player.Gold = Player.Gold - normalGun.upgradeGold;
                normalGun.UpdateNormal();
                //normalGun.Atk = normalGun.Atk + 5;
                //normalGun.Range = normalGun.Range + 5;
                //normalGun.Reload = normalGun.Reload +5;
                //normalGun.Level = normalGun.Level + 1;
                TurretInfo.turretInfo.setInfoText("Level: " + normalGun.Level, "Attack: " + normalGun.Atk,
                        "Reload: " + normalGun.Reload, "Range: " + normalGun.Range, "Gold: " + normalGun.Gold,
                        "Upgrade: " + normalGun.upgradeGold, "Sell: " + normalGun.sellGold);
            }
            
        }
        if (Turret.CompareTag("Explosion"))
        {
            ExplosionGun explosionGun = Turret.GetComponent<ExplosionGun>();
            if (explosionGun.upgradeGold <= Player.Gold)
            {
                Player.Gold = Player.Gold - explosionGun.upgradeGold;
                explosionGun.UpdateExplo();
                //explosionGun.Atk = explosionGun.Atk + 5;
                //explosionGun.Range = explosionGun.Range + 5;
                //explosionGun.Reload = explosionGun.Reload + 5;
                //explosionGun.Level = explosionGun.Level + 1;
                TurretInfo.turretInfo.setInfoText("Level: " + explosionGun.Level, "Attack: " + explosionGun.Atk,
                        "Reload: " + explosionGun.Reload, "Range: " + explosionGun.Range, "Gold: " + explosionGun.Gold,
                        "Upgrade: " + explosionGun.upgradeGold, "Sell: " + explosionGun.sellGold);
            }
        }

    }

    public void SellTurret()
    {
        if (Turret.CompareTag("Normal"))
        {
            NormalGun normalGun = Turret.GetComponent<NormalGun>();
            Player.Gold = Player.Gold + normalGun.sellGold;
            Destroy(Turret);
            ListTurret.Remove(Turret);
            UIManager.UI.TurretInfo.SetActive(false);
            canClick = true;
        }
        else if (Turret.CompareTag("Explosion"))
        {
            ExplosionGun explosionGun = Turret.GetComponent<ExplosionGun>();
            Player.Gold = Player.Gold + explosionGun.sellGold;
            Destroy(Turret);
            ListTurret.Remove(Turret);
            UIManager.UI.TurretInfo.SetActive(false);
            canClick = true;
        }
    }
}    

