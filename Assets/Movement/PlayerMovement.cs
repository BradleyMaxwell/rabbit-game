using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    private CharacterController controller;
    private PlayerActions playerActions; // used to listen for the movement input of the player

    // Start is called before the first frame update
    void Awake ()
    {
        playerActions = new PlayerActions();
        controller = GetComponent<CharacterController>();
    }

    void OnEnable () 
    {
        playerActions.Enable();
    }

    void OnDisable ()
    {
        playerActions.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        // change the velocity of the player based on what their input is in a given frame
        Vector2 moveInput = playerActions.Playing.Move.ReadValue<Vector2>();
        if (moveInput.magnitude > 0)
        {
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y); // change the velocity based on the vertical and horizontal movement input
            controller.Move(moveDirection * movementSpeed * Time.deltaTime); // apply the velocity of the player every frame
        }
    }


}
