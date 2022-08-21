using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int walkSpeed = 3;
    public int sprintSpeed = 6;
    private int currentSpeed;

    public int walkForce = 20;
    public int sprintForce = 30;
    public int currentMoveForce;

    public int jumpForce = 100;

    public float fallMultiplier = 2.5f;

    public Transform body;

    public Hitbox hitbox;

    private Rigidbody2D rigidBody;
    
    private float horizontalInput;
    private float verticalInput;

    private Vector2 velocity;

    private bool isJumping;
    private bool onGround;

    private int attackOffset = 1;

    public void OnStart() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnUpdate() {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput > 0) {
            body.transform.localScale = new Vector3(1,body.transform.localScale.y,body.transform.localScale.z);
            attackOffset = 1;
        }
        else if(horizontalInput < 0) {
            body.transform.localScale = new Vector3(-1,body.transform.localScale.y,body.transform.localScale.z);
            attackOffset = -1;
        }

        if(Input.GetButton("Sprint") && onGround) {
            currentSpeed = sprintSpeed;
            currentMoveForce = sprintForce;
        }
        else if(onGround) {
            currentSpeed = walkSpeed;
            currentMoveForce = walkForce;
        }

        if(Input.GetButtonDown("Jump") && onGround) {
            isJumping = true;
        }

        if(Input.GetButtonDown("Attack")) {
            Instantiate(hitbox,new Vector3(body.transform.position.x+attackOffset,body.transform.position.y,body.transform.position.z),hitbox.transform.localRotation,transform);
        }
        
    }

    public void OnFixedUpdate() {

        if(rigidBody.velocity.y < 0) {
            rigidBody.gravityScale = fallMultiplier;
        }
        else {
            rigidBody.gravityScale = 1;
        }

        if(isJumping) {
            rigidBody.AddForce(jumpForce * Vector2.up,ForceMode2D.Impulse);
            isJumping = false;
        }

        if(Mathf.Abs(rigidBody.velocity.x) <= currentSpeed) {
            rigidBody.AddForce(currentMoveForce * new Vector2(horizontalInput,0));
        }

    }

    public void OnTriggerEnter2D(Collider2D other) {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x,rigidBody.velocity.y/2);
    }

    public void OnTriggerStay2D(Collider2D other) {
        onGround = true;
    }

    public void OnTriggerExit2D(Collider2D other) {
        onGround = false;
    }

}