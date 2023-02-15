using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpVelocity = 15f; 
    [SerializeField] private GameInput gameInput;

    private Rigidbody2D rigidBody2D;

    private bool isRunning;
    private bool isJumping;
    
    private void Awake() { 
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.isKinematic = true; //Remove later
    }

    public void PlayerMove(Vector2 inputVector) {
        //Move. 
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0);

        isRunning = moveDir != Vector3.zero; // Returns false when moveDir = zero. 
        isJumping = !(moveDir != Vector3.up);
        
        //TODO: This is bugged, I think its to do with having kinematic on, as it works without it on.
        if (isJumping) {
            rigidBody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
        transform.position += moveDir * (Time.deltaTime * moveSpeed); 
    }

    public bool IsRunning() {
        return isRunning; 
    }

    public bool IsJumping() {
        return isJumping; 
    }

}
