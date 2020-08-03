using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankHeadshot : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            //Debug.Log("Head Collided");
            GetComponent<tankScript>().headCollided();
            Destroy(other.gameObject);
        }
        if (other.tag == "shotgunBullet")
        {
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
