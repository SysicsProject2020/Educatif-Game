using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class PlayerMvt : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Animator anim;
    private Vector3 moveDirection = Vector3.zero;
    public float rotationspeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            
           // moveDirection = transform.TransformDirection(moveDirection);

            
            //    transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0));
            // characterController.Move(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime);
            // transform.Rotate(0, Input.GetAxis("Horizontal")*rotationspeed*Time.deltaTime, 0);
            LockOnTarget();
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                characterController.Move(transform.forward * speed * Time.deltaTime);
                anim.SetFloat("zSpeed", 1);
            }
            else
            {
                anim.SetFloat("zSpeed", 0);
            }
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                characterController.Move(moveDirection * speed * Time.deltaTime);
                anim.SetTrigger("jump");
            }
            
            
        }
        else
        {
            characterController.Move(moveDirection*speed * Time.deltaTime);
        }
       
        moveDirection.y -= gravity * Time.deltaTime;

        
        //characterController.Move(transform.forward* Time.deltaTime);

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)


        // Move the controller
      

    }
    void LockOnTarget()
    {
        Vector3 test = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if (test- Vector3.zero != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(test);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationspeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
       
       
    }
}