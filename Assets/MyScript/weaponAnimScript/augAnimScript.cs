using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class augAnimScript : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("reload", false);
        anim.SetBool("shoot", false);
        anim.SetBool("switch", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootBullet.currWep == 1)
        {
            if (ShootBullet.wep1Fire == true)
            {
                anim.SetBool("shoot", true);
            }
            if (ShootBullet.wep1Fire == false)
            {
                anim.SetBool("shoot", false);
            }
            if (ShootBullet.wep1Reload == true)
            {
                anim.SetBool("reload", true);
                anim.SetBool("shoot", false);
            }
            if (ShootBullet.wep1Reload == false)
            {
                anim.SetBool("reload", false);
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
        if (ShootBullet.currWep != 1)
        {
            gameObject.SetActive(false);
            //gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
