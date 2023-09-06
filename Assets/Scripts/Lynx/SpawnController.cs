using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    public float counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if ((int)counter % 1.5 == 0 && counter >= 1.5)
        {
            counter = 0;
            Vector3 moveRandom = new Vector3(Random.Range(-12, 12), Random.Range(-5, 5));
            GameObject obj = Instantiate<GameObject>(enemy, moveRandom, Quaternion.identity);
        }
    }
}
