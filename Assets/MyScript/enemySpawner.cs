using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject spawnObj;
    private float spawnRate = 3.0f, cooldown;
    public GameObject[] spawner;
    private int currentS;
    // Use this for initialization
    void Start () {
        seperateSpawner();
    }

    // Update is called once per frame
    void Update () {
        if (cooldown == spawnRate)
        {
            //for (int i = 0; i<4; i++)
            {
                if(currentS != detection.agentAtArea)
                {
                    spawn();
                }
            }
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            cooldown = spawnRate;
        }
    }
    public void spawn()
    {
        Instantiate(spawnObj, transform.position, transform.rotation);
    }

    private void seperateSpawner()
    {
        if (gameObject.name == "s0")
        {
            currentS = 0;
        }
        if (gameObject.name == "s1")
        {
            currentS = 1;
        }
        if (gameObject.name == "s2")
        {
            currentS = 2;
        }
        if (gameObject.name == "s3")
        {
            currentS = 3;
        }
        if (gameObject.name == "s4")
        {
            currentS = 4;
        }
        if (gameObject.name == "s5")
        {
            currentS = 5;
        }
    }
}
