﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class augBullet : MonoBehaviour {
    private float bulletDura = 3.0f;
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