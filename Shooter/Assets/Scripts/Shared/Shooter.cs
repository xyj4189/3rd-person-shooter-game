using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] float rateOfFire = 0.3f;
    [SerializeField] Projectile projectile;

    [HideInInspector]
    public Transform Muzzle;
    private WeaponRealoader realoader;

    float nextFireAllowed;
    public bool canFire;
    void Start()
    {

        rateOfFire = 0.3f;
    }
	// Use this for initialization
	void Awake () {
        Muzzle = transform.Find("Muzzle");
        realoader = GetComponent<WeaponRealoader>();
        rateOfFire = 0.3f;
    }

    public void Reload()
    {
        if (realoader == null)
            return;
        realoader.Reload();
    }
    public virtual void Fire()
    {
        //print("Fire1");
        canFire = false;

        if (Time.time < nextFireAllowed)

            return;

        if(realoader!= null)
        {
            if (realoader.IsReloading)
                return;
            if (realoader.RoundsRemaingInClip == 0)
                return;

            realoader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOfFire;
        //Instantiate the projectile;

        Instantiate(projectile, Muzzle.position, Muzzle.rotation);
       
        canFire = true;
    }
    
	
}
