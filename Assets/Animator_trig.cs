using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class Animator_trig : MonoBehaviour {
    private Animator animator;
    private CharacterController controller;
    public Rigidbody rb;
    public float speed =10.0f;
    public float turn_speed = 60.0f;
    public Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    public float jumpHeight=5000f;
    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Anim",1);
        }
        else
        {
            animator.SetInteger("Anim", 0);
        }

        if (Input.GetAxis("Jump")>0 && controller.isGrounded)
        {
            animator.SetInteger("Jump", 1);
            rb.AddForce(transform.up * jumpHeight);
        }
        else
        {
            animator.SetInteger("Jump", 0);
        }

        if (controller.isGrounded)
        {
            if(Input.GetAxis("Vertical")>0)
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            else
                moveDirection = Vector3.zero;
        }
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0,turn*turn_speed*Time.deltaTime,0);
        controller.Move(moveDirection*Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        if (transform.position.y<-10)
        {
            transform.position = Vector3.zero;
        }
	}
}
