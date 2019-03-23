using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Movement : MonoBehaviour {

    public float speed = 1.0f;

    public float minDist = 10f;

    public float attackDistance = 1f;

	public bool isAlive;

    private bool canAttack;

	// Use this for initialization
	void Start () {

		isAlive = true;
        canAttack = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isAlive)
        {
            //transform.Translate (0, 0, speed * Time.deltaTime);

            transform.LookAt(UIManager.Instance.getPlayer());
            if (Vector3.Distance(transform.position, UIManager.Instance.getPlayer().position) <= attackDistance)
            {

                // transform.position += transform.forward * speed * Time.deltaTime;
                this.GetComponent<Animator>().SetBool("attack", true);
                this.GetComponent<Animator>().SetBool("walk", false);
                this.GetComponent<Animator>().SetBool("idle", false);

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

        /*Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            Debug.Log(hit.collider.gameObject);
            if(hit.distance < distanceFromObstacle)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }*/
	}

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
}
