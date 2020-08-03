using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunAnimScript : MonoBehaviour
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
        if (ShootBullet.currWep == 0)
        {
            if (ShootBullet.wep0Fire == true)
            {
                anim.SetBool("shoot", true);
            }
            if (ShootBullet.wep0Fire == false)
            {
                anim.SetBool("shoot", false);
            }
            if (ShootBullet.wep0Reload == true)
            {
                anim.SetBool("reload", true);
                anim.SetBool("shoot", false);
            }
            if (ShootBullet.wep0Reload == false)
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
        if (ShootBullet.currWep != 0)
        {
                gameObject.SetActive(false);
            //gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
