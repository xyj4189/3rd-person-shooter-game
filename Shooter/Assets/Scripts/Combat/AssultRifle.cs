using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//inherit the script from the shooter instead of the monobehavior
public class AssultRifle : Shooter {
    AudioSource aSour;
    private void Start ()
    {
        aSour = GetComponent<AudioSource>();
    }
    public override void Fire()
    {

        base.Fire();
        if (canFire)
        {
            aSour.PlayOneShot(aSour.clip,1);
            print("fire");
        }
    }

    public void Update()
    {
        if (GameManager.Instance.InputController.Reload)
        {
            Reload();
        }

    }
}
