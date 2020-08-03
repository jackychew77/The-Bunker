using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class macheteAnimScript : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootBullet.currWep == 2)
        {
            if (ShootBullet.wep2Fire == true)
            {
                anim.SetBool("shoot", true);
            }
            if (ShootBullet.wep2Fire == false)
            {
                anim.SetBool("shoot", false);
            }
            if (ShootBullet.wepSwitch == true)
            {
                anim.SetBool("switch", true);
            }
            if (ShootBullet.wepSwitch == false)
            {
                anim.SetBool("switch", false);
            }
        }
        if (ShootBullet.currWep != 2)
        {
            gameObject.SetActive(false);
            //gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
