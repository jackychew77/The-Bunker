using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullet : MonoBehaviour {
    Animator anim;
    public GameObject Bullet, shotgunBullet , meleeBullet, shotgunObj, augObj, macheteObj;
    public Transform BulletSpawnLocation, fpcCamera;
    public AudioClip smgSound, shotgunSound, macheteSound, smgReload, shotgunReload;
    public AudioClip smgSwapSound, shotgunSwapSound, macheteSwapSound;
    private AudioSource source;
    private float volLowRange = .5f, volHighRange = 1.0f;
    private int[] ammo = { 8, 30, 0 }, maxAmmo = { 8, 30, 0 }, totalAmmo = { 35, 90, 0 };
    public Text ammoUI, weaponUI;
    private int weapon = 0; //0 = shotgun;    1=AUG;     2 = Machete;
    private float shotgunFireRate, macheteFireRate, fireRate = 0.10f, cooldown, switchWeap;
    private float shotgunReloadTime = 2.0f, smgReloadTime = 1.5f;
    public static bool wep0Fire, wep1Fire, wep2Fire, wep0Reload, wep1Reload, wep2Reload, wepSwitch;
    public static int currWep;
    // Use this for initialization
    void Start() {
        source = GetComponent<AudioSource>();
        cooldown = fireRate;
        wep0Fire = false;
        wep1Fire = false;
        wep2Fire = false;
    }

    // Update is called once per frame
    void Update() {
        ammoUI.text = "AMMO : " + ammo[weapon] + "/" + totalAmmo[weapon];
        if (weapon == 0)
        {
            currWep = 0;
            weaponUI.text = "Shotgun";
            maxAmmo[weapon] = maxAmmo[weapon];
        }
        else if (weapon == 1)
        {
            currWep = 1;
            weaponUI.text = "AUG";
            maxAmmo[weapon] = maxAmmo[weapon];

        }
        else if (weapon == 2)
        {
            currWep = 2;
            weaponUI.text = "Machete";
            maxAmmo[weapon] = maxAmmo[weapon];

        }

        if (Input.GetMouseButtonDown(0) && ammo[weapon] > 0 && weapon == 0 && switchWeap <= 0 && shotgunReloadTime <= 0)     //shotgun
        {
            if (shotgunFireRate <= 0.0f)
            {
                GameObject clone = Instantiate(shotgunBullet, BulletSpawnLocation.position, BulletSpawnLocation.rotation);
                clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 65.0f;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(shotgunSound, vol);
                ammo[weapon]--;
                shotgunFireRate = 1.0f;             //shotgun FIRERATE
            }            
        }
        if (shotgunFireRate <= 0.1f && shotgunFireRate >= -0.001f)
        {
            wep0Fire = false;
        }
        if (shotgunFireRate == 1.0f)
        {
            wep0Fire = true;
        }
        if (shotgunFireRate > -0.001f)
        {
            shotgunFireRate -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0) && ammo[weapon] > 0 && weapon == 1 && switchWeap <= 0 && smgReloadTime <= 0)     //AUG
        {
            if (cooldown <= 0)
            {
                GameObject clone = Instantiate(Bullet, BulletSpawnLocation.position, BulletSpawnLocation.rotation);
                clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 85.0f;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(smgSound, vol);
                ammo[weapon]--;
                cooldown = fireRate;
            }   
        }
        if (cooldown <= 0.1f && cooldown >= -0.001f)
        {
            wep1Fire = false;
        }
        if (cooldown == fireRate)
        {
            wep1Fire = true;
        }
        if (cooldown > -0.001f)
        {
            cooldown -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && weapon == 2 && switchWeap <= 0)     //Machete
        {
            if (macheteFireRate <= 0.0f)
            {
                GameObject clone = Instantiate(meleeBullet, BulletSpawnLocation.position, BulletSpawnLocation.rotation);
                clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 35.0f;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(macheteSound, vol);
                macheteFireRate = 0.5f;             //machete FIRERATE

            }
        }
        if (macheteFireRate <= 0.1f && macheteFireRate >= -0.001f)
        {
            wep2Fire = false;
        }
        if (macheteFireRate == 0.5f)
        {
            wep2Fire = true;
        }
        if (macheteFireRate > -0.001f)
        {
            macheteFireRate -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(weapon == 0 && shotgunReloadTime <= 0 && switchWeap <= 0.0f && ammo[weapon] < maxAmmo[weapon] && totalAmmo[weapon] > 0)
            {
                reload();
                source.PlayOneShot(shotgunReload);
                shotgunReloadTime = 2.0f;
            }
            if (weapon == 1 && smgReloadTime <= 0 && switchWeap <= 0.0f && ammo[weapon] < maxAmmo[weapon] && totalAmmo[weapon] > 0)
            {
                reload();
                source.PlayOneShot(smgReload);
                smgReloadTime = 1.5f;
            }
        }
        if (shotgunReloadTime <= 0.1f && shotgunReloadTime >= -0.01f)
        {
            wep0Reload = false;
        }
        if (shotgunReloadTime == 2.0f)
        {
            wep0Reload = true;
        }
        if (shotgunReloadTime > -0.01f)        //switchweapon timer
        {
            shotgunReloadTime -= Time.deltaTime;
        }

        if (smgReloadTime <= 0.1f && smgReloadTime >= -0.01f)
        {
            wep1Reload = false;
        }
        if (smgReloadTime == 1.5f)
        {
            wep1Reload = true;
        }
        if (smgReloadTime > -0.01f)        //switchweapon timer
        {
            smgReloadTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && weapon != 0)
        {
            weapon = 0; //shotgun
            switchWeap = 1.0f;      //switchweapon cooldown
            source.PlayOneShot(shotgunSwapSound);
            shotgunObj.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weapon != 1)
        {
            weapon = 1; //AUG
            switchWeap = 1.0f;      //switchweapon cooldown
            source.PlayOneShot(smgSwapSound);
            augObj.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && weapon != 2)
        {
            weapon = 2; //Machete
            switchWeap = 1.0f;      //switchweapon cooldown
            source.PlayOneShot(macheteSwapSound);
            macheteObj.SetActive(true);
        }
        if (switchWeap <= 0.1f && switchWeap >= -0.01f)
        {
            wepSwitch = false;
        }
        if (switchWeap == 1.0f)
        {
            wepSwitch = true;
        }
        if (switchWeap > -0.01f)        //switchweapon timer
        {
            switchWeap -= Time.deltaTime;
        }
    }
        
    private void reload()           //reload
    {
        if (totalAmmo[weapon] >= maxAmmo[weapon])
        {
            totalAmmo[weapon] = totalAmmo[weapon] - (maxAmmo[weapon] - ammo[weapon]);
            ammo[weapon] = maxAmmo[weapon];
        }
        else if (totalAmmo[weapon] > 0 && totalAmmo[weapon] < maxAmmo[weapon])
        {
            if (maxAmmo[weapon] > (totalAmmo[weapon] + ammo[weapon]))
            {
                ammo[weapon] = ammo[weapon] + totalAmmo[weapon];
                totalAmmo[weapon] = 0;
            }
            else
            {
                totalAmmo[weapon] = totalAmmo[weapon] - (maxAmmo[weapon] - ammo[weapon]);
                ammo[weapon] = ammo[weapon] + totalAmmo[weapon];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ammopack")
        {
            Debug.Log("Picked Ammo");
            totalAmmo[weapon] += maxAmmo[weapon];
            Destroy(other.gameObject);
        }
    }
}
