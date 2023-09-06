using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelect;
    public static Action OnTurretSold;
    
    private bool active = true;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowTurretShop()
    {
        UIManager.UI.TurretShop.SetActive(true);
        Debug.Log("1");
    }

}
