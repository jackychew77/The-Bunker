using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankTorsoshot : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            //Debug.Log("Torso Collided");
            GetComponent<tankScript>().torsoCollided();
            Destroy(other.gameObject);
        }
        if (other.tag == "shotgunBullet")
        {
            Destroy(other.gameObject);
            GetComponent<tankScript>().shotgunBulletCollided();
        }
        if (other.tag == "meleeBullet")
        {
            GetComponent<tankScript>().meleeBulletCollided();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
