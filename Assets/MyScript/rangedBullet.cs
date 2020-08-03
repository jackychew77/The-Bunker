using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedBullet : MonoBehaviour {
    private float bulletDura = 0.4f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bulletDura <= 0.0f)
        {
            Destroy(gameObject);
        }
        bulletDura -= Time.deltaTime;
    }
}
