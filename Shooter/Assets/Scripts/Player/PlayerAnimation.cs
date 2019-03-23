using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    AudioSource aSour;
    //reference to the animation
    private void Start ()
    {
        aSour = GetComponent<AudioSource>();
    }
    Animator animator;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();//reference to the children
    }

    void Update()
    {
        if (PlayerInfo.Instance.getPlayerAlive() == false)
        {
            animator.SetFloat("Vertical", 0);
            return;
        }
        if(GameManager.Instance.InputController.Vertical > 0)
        {
            if(!aSour.isPlaying)
                aSour.PlayOneShot(aSour.clip,1);
        }
            
        animator.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);

        animator.SetBool("IsWalking", GameManager.Instance.InputController.IsWalking);
        animator.SetBool("IsSprinting", GameManager.Instance.InputController.IsSprinting);
        animator.SetBool("IsCrouched", GameManager.Instance.InputController.IsCrouched);
    }
}
