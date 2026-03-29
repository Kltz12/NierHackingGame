using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;

 // Speed at which the player moves.
 public float speed = 5; 

 [SerializeField] private Camera cam;

 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }
 
 // This function is called when a move input is detected.
 void OnMove(InputValue movementValue)
    {
 // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

 // Store the X and Y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
{
    Vector3 movement = new Vector3(movementX, 0f, movementY);

    rb.linearVelocity = movement * speed;

    RotateToMouse();
}

void RotateToMouse()
{
    Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
    RaycastHit hit;

    // Shoot a ray onto the ground
    if (Physics.Raycast(ray, out hit))
    {
        Vector3 target = hit.point;
        target.y = transform.position.y;

        Vector3 direction = (target - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }
    }
}
}