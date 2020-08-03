using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedTorsoshot : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            //Debug.Log("Torso Collided");
            GetComponent<speedScript>().torsoCollided();
            Destroy(other.gameObject);
        }
        if (other.tag == "shotgunBullet")
        {
            Destroy(other.gameObject);
            GetComponent<speedScript>().shotgunBulletCollided();
        }
        if (other.tag == "meleeBullet")
        {
            GetComponent<speedScript>().meleeBulletCollided();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
