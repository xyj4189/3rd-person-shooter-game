using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour {
    public static GateAnimation instance = null;

    public Animator anim;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    void Start () {
        anim= GetComponent<Animator>();
        anim.SetBool("dooropen", false);
        anim.SetBool("doorclose", true);
        // anim.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
