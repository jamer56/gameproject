using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed;

    public float jumpSpeed;

    private float horizontalMove, verticalMove;

    private Vector3 dir;

    public float gravity;

    private Vector3 velocity;

    public Transform groundCheck;

    public float checkRadius;

    public LayerMask groundLayer;

    public bool isGround;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = jumpSpeed;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && isGround)
        {
            moveSpeed = 10;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && isGround)
        {
            moveSpeed = 5;
        }

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);


        if(this.transform.position.y < -30)
        {
            this.transform.position  = new Vector3(0,1,-10);
        }
    }
}
