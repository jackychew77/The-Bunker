﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedTorsoshot : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            //Debug.Log("Torso Collided");
            GetComponent<rangedScript>().torsoCollided();
            Destroy(other.gameObject);
        }
        if (other.tag == "shotgunBullet")
        {
            GetComponent<rangedScript>().shotgunBulletCollided();
        }
        if (other.tag == "meleeBullet")
        {
            GetComponent<rangedScript>().meleeBulletCollided();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}