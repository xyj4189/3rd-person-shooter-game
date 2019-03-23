using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {
    [SerializeField] float inSeconds;
    public override void Die()
    {
        base.Die();
        PlayerInfo.Instance.killedZombie(this.gameObject.GetComponent<Zombie>().getCoinsToPlayer());
        this.GetComponent<Animator>().SetBool("die", true);
        Invoke("respawn",0.6f);

    }

    void respawn()
    {
        Destroy(gameObject);
        //GameManager.Instance.Respawner.D(gameObject, inSeconds);
    }

    void OnEnable()
    {
        Reset();
    }

    public override void TakeDamage(float amount)
    {
        //print("Remaining:  " + HitPointsRemaining);
        base.TakeDamage(amount);
    }
}
