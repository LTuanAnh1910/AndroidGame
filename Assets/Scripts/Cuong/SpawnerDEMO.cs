using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDEMO : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float counter; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime; 
        if (counter > 2)
        {
            Instantiate<GameObject>(enemy, transform.position, Quaternion.identity);
            counter = 0;
        }
    }
}
