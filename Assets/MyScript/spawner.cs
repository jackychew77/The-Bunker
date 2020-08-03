using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject[] spawnObj;
    private float spawnRate0 = 15.0f, spawnRate1 = 25.0f, spawnRate2 = 35.0f, cooldown0, cooldown1, cooldown2;
    //private int[] spawnNum = { 1, 1, 1 };
    
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(cooldown0 < 0)
        {
            spawn0();
            cooldown0 = spawnRate0;
        }
        cooldown0 -= Time.deltaTime;
        if (cooldown1 < 0)
        {
            spawn1();
            cooldown1 = spawnRate1;
        }
        cooldown1 -= Time.deltaTime;
        if (cooldown2 < 0 && spawnObj.Length > 2)
        {
            spawn2();
            cooldown2 = spawnRate2;
        }
        cooldown2 -= Time.deltaTime;

    }
    public void spawn0()
    {
        //for (int i = 0; i < spawnNum[0]; i++)
        {
            Instantiate(spawnObj[0], transform.position, transform.rotation);
        }
    }
    public void spawn1()
    {
        //for (int i = 0; i < spawnNum[1]; i++)
        {
            Instantiate(spawnObj[1], transform.position, transform.rotation);
        }
    }
    public void spawn2()
    {
        //for (int i = 0; i < spawnNum[2]; i++)
        {
            Instantiate(spawnObj[2], transform.position, transform.rotation);
        }
    }
}
