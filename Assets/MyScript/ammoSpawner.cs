using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoSpawner : MonoBehaviour
{
    public GameObject spawnObj;
    private float cooldown;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0.0f)       //spawn rate
        {
            spawn();
            cooldown = 15.0f;
        }
        cooldown -= Time.deltaTime;
    }
    public void spawn()
    {
        Instantiate(spawnObj, transform.position, transform.rotation);
    }
}
