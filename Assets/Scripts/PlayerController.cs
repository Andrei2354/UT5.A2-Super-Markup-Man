using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private float gravity = 9.8f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        moveDirection = new Vector3(move.x * speed, moveDirection.y, move.z * speed);
        if (!controller.isGrounded){
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
    }
}
