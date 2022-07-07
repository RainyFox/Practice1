using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//main branch
public class Player1 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private bool justJump = false;
    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        if (justJump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            justJump = false;
        }
    }

    void PlayerMoveKeyboard()
    {
        if (isGrounded)
        {
            movementX = Input.GetAxis("Horizontal");
            //transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * moveForce;
            rb.velocity = new Vector2(movementX * moveForce, rb.velocity.y);
        }
    }

    void AnimatePlayer()
    {
        if (0f < movementX)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0f)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        if (rb.velocity == Vector2.zero)
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        Debug.Log("Velocity: " + rb.velocity);
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            justJump = true;

            Debug.Log("y velocity: " + rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            //rb.velocity =  Vector2.zero;
        }
    }
}
