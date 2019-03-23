using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    //new class
    [System.Serializable]   
   public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool LockMouse;//to control the runSpeed for walk

    }

    [SerializeField]float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float sprintSpeed;

    [SerializeField]MouseInput MouseControl;

    private MoveController m_moveController;
    public MoveController MoveController
    {
        get
        {
            if (m_moveController == null)
                m_moveController = GetComponent<MoveController>();
            return m_moveController;

        }
    }

    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }
   
    InputController playerInput;
    Vector2 mouseInput;

    private void Awake()
    {
        GameManager.FixIssue();
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        if (MouseControl.LockMouse)//to hide the mouse o the screen
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update () {

        Move();
        LookAround();

    }
    void Move()
    {
        if (PlayerInfo.Instance.getPlayerAlive() == false)
            return;
        float moveSpeed = runSpeed;//by default
        //Reference to the controlling the game manager
        if (playerInput.IsWalking)
        {
            //aSour.Play();
            print("walk");
            moveSpeed = walkSpeed;
        }
        if (playerInput.IsSprinting)
            moveSpeed = sprintSpeed;

        if (playerInput.IsCrouched)
            moveSpeed = crouchSpeed;
        Vector3 direction = new Vector3(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed, 0f);
        //Debug.Log(direction);
        MoveController.Move(direction);

    }

    void LookAround()//look around funtion calling in update function 
    {
        if (PlayerInfo.Instance.getPlayerAlive() == false)
            return;
        //mouse Input 
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);//x axis

        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);//y axis 

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
    }


}
