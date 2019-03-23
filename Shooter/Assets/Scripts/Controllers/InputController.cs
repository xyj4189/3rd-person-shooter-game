﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1;
    public bool Reload;
    public bool IsWalking;
    public bool IsSprinting;
    public bool IsCrouched;



	// Update is called once per frame
	void Update () {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");//fire
        Reload = Input.GetKey(KeyCode.R);//relaod
        IsWalking = Input.GetKey(KeyCode.LeftAlt);//walking
        IsSprinting = Input.GetKey(KeyCode.LeftShift);//sprinting
        IsCrouched= Input.GetKey(KeyCode.C);


    }
}
