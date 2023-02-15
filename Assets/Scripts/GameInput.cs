using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameInput : MonoBehaviour {

    [SerializeField] private PlayerMovement boyControl;
    [SerializeField] private PlayerMovement girlControl;

    private PlayerMovement currentCharacter;

    public void Awake() {
        currentCharacter = boyControl; 
    }
    public void Update() {
        SwitchCharacterControl();
        currentCharacter.PlayerMove(GetMovementVector()); 
    }

    public Vector2 GetMovementVector() {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x += -1; 
        }

        if (Input.GetKey(KeyCode.D)) {
            inputVector.x += 1;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            inputVector.y += 1;
        }
        
        return inputVector; 
    }
    
    public void SwitchCharacterControl() {
        if (Input.GetKeyDown(KeyCode.F)) {
            if (currentCharacter == boyControl) {
                currentCharacter = girlControl;
            } else {
                currentCharacter = boyControl; 
            }
        }
    }


}
