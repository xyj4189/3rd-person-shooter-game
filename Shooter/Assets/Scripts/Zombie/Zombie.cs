using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int damage = 1;
    public int coinsToPlayer = 5;

    public float speed = 1.0f;

    public float minDist = 10f;

    public float attackDistance = 1f;

    public bool isAlive;

    private bool canAttack;
    private bool playerInRange;


    // Use this for initialization
    void Start () {
        isAlive = true;
        canAttack = true;
        playerInRange = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isAlive)
        {
            //transform.Translate (0, 0, speed * Time.deltaTime);

            playerInRange = false;

            transform.LookAt(UIManager.Instance.getPlayer());
            if (Vector3.Distance(transform.position, UIManager.Instance.getPlayer().position) <= attackDistance)
            {

                // transform.position += transform.forward * speed * Time.deltaTime;
                this.GetComponent<Animator>().SetBool("attack", true);
                this.GetComponent<Animator>().SetBool("walk", false);
                this.GetComponent<Animator>().SetBool("idle", false);
                playerInRange = true;
                attack();

            }
            else if (Vector3.Distance(transform.position, UIManager.Instance.getPlayer().position) <= minDist)
            {


                transform.position += transform.forward * speed * Time.deltaTime;
                this.GetComponent<Animator>().SetBool("walk", true);
                this.GetComponent<Animator>().SetBool("attack", false);
                this.GetComponent<Animator>().SetBool("idle", false);

            }
            else if (Vector3.Distance(transform.position, UIManager.Instance.getPlayer().position) > minDist)
            {
                this.GetComponent<Animator>().SetBool("walk", false);
                this.GetComponent<Animator>().SetBool("attack", false);
                this.GetComponent<Animator>().SetBool("idle", true);
            }
        }

    }

    void attack()
    {
        if (playerInRange == true && canAttack == true)
        {
            canAttack = false;
            StartCoroutine(reAttack());
            UIManager.Instance.getPlayer().gameObject.GetComponent<PlayerInfo>().Hurt(damage);
        }
    }

    IEnumerator reAttack()
    {
        yield return new WaitForSecondsRealtime(1f);
        canAttack = true;

    }

    void OnTriggerEnter(Collider collider)
    {
        
        /*if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerInfo>().Hurt(damage);
        }*/
    }

    public int getDamage()
    {
        return damage;
    }

    public int getCoinsToPlayer()
    {
        return coinsToPlayer;
    }
}
