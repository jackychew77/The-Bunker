using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunBullet : MonoBehaviour {
    private float scaleRate = 0.001f, cooldown, bulletDura = 0.5f, hp = 10;
    
        // Use this for initialization
        void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (bulletDura <= 0.0f)
        {
            Destroy(gameObject);
        }
        if (cooldown <= 0.0f)
        {
            cooldown = scaleRate;
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        }
        cooldown -= Time.deltaTime;
        bulletDura -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            hp -= 2;
            checkIfDie();
        }
    }
    private void checkIfDie()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
