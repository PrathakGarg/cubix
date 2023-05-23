using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public bool canJump = false;

    [SerializeField]
    private float jumpForce = 300f;

    [SerializeField]
    private float forwardForce = 500f;

    [SerializeField]
    private float sidewaysForce = 10f;

    [SerializeField]
    private float extraGravity = 200f;

    private readonly string GROUND_TAG = "Ground";

    private Rigidbody rb;
    private float movementX;
    private bool isGrounded = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && canJump) isJumping = true;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0f, 0f, forwardForce * Time.deltaTime));
        PlayerJump();
        PlayerSidewaysMovement();

        if (!isGrounded)
        {
            Vector3 vel = rb.velocity;
            vel.y -= extraGravity * Time.deltaTime;
            rb.velocity = vel;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) isGrounded = true;
    }

    void PlayerJump()
    {
        if (isJumping)
        {
            isJumping = false;
            isGrounded = false;
            rb.AddForce(new Vector3(0f, jumpForce * Time.deltaTime), ForceMode.Impulse);
        }
    }

    void PlayerSidewaysMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        // transform.position += sidewaysForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
        rb.AddForce(sidewaysForce * Time.deltaTime * new Vector3(movementX, 0f, 0f), ForceMode.Impulse);
    }
}
