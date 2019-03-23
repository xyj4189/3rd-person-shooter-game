using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerenter : MonoBehaviour {

    public static playerenter instance = null;
    // Use this for initialization

    private void Awake()
    {
        instance = this;
    }
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
              GateAnimation.instance.anim.SetBool("dooropen", true);
          //  GateAnimation.instance.anim.enabled = true;
            GateAnimation.instance.anim.SetBool("doorclose", false);
            Debug.Log("player");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //  GateAnimation.instance.anim.enabled = false;
            GateAnimation.instance.anim.SetBool("dooropen", false);
            GateAnimation.instance.anim.SetBool("doorclose", true);
            Debug.Log("player");
        }

    }
}
