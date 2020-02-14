using UnityEngine;
using System.Collections;
public class BasicController : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    public float  transitionTime = .25f;
    private float speedLimit = 1.0f;
    public bool moveDiagonally = true;
    public bool mouseRotate = true;
    public bool keyboardRotate = false;
    private Vector3 moveDirection = Vector3.zero;
    public float jumpHeight = 3f;
    private float verticalSpeed = 0f;
    private float xVelocity = 0f;
    private float zVelocity = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (controller.isGrounded)
        {

            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
                speedLimit = 0.5f;
            else
                speedLimit = 1.0f;
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float xSpeed = h * speedLimit;
            float zSpeed = v * speedLimit;
           
            float Speed = Mathf.Sqrt(h * h + v * v);
            if (v != 0 && !moveDiagonally)
                xSpeed = 0;
            if (v != 0 && keyboardRotate)
                this.transform.Rotate(Vector3.up * h, Space.World);
            if (mouseRotate) this.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X")) * Mathf.Sign(v), Space.World);

            anim.SetFloat("zSpeed", zSpeed);
            anim.SetFloat("xSpeed", xSpeed);
            anim.SetFloat("Speed", Speed);
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("Jump", true); verticalSpeed = jumpHeight;
            }

            moveDirection = new Vector3(0, 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speedLimit;
            controller.Move(moveDirection * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("Discuss", true);
        }
        else { anim.SetBool("Discuss", false); }
       

    }
    void OnAnimatorMove() {
        Vector3 deltaPosition = anim.deltaPosition;
        //deltaPosition.z = anim.GetFloat("zSpeed");
        // deltaPosition.x = anim.GetFloat("xSpeed");
        
        
      

        if (controller.isGrounded)
        {
           // xVelocity = controller.velocity.x;
           // zVelocity = controller.velocity.z;
        }
        else
        {
            deltaPosition.x = xVelocity * Time.deltaTime;
            deltaPosition.z = zVelocity * Time.deltaTime;
            anim.SetBool("Jump", false);
        }
        deltaPosition.y = verticalSpeed * Time.deltaTime;
        controller.Move(deltaPosition);
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        if ((controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            verticalSpeed = 0;
        }
        Debug.Log(deltaPosition);
    }
}
    
