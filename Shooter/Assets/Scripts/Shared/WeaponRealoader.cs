using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRealoader : MonoBehaviour {
    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;
    [SerializeField]Container inventory;


    int ammo;
    public int shotsFiredInClip;
    bool isReloading;

    public int RoundsRemaingInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }
    public bool IsReloading
    {
        get
        {
            return isReloading;
        }
    }

    void Awake()
    {
        
    }
    public void Reload(){
        if (isReloading)
            return;

        isReloading = true;
        print("Reload started");
        GameManager.Instance.Timer.Add(ExecuteReload, reloadTime);

    }

    public void ExecuteReload()
    {
        print("Reload executed");
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;


        if (ammo < 0)
            ammo = 0;
        shotsFiredInClip += -ammo;


    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
    }
}
