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
    private string JUMP_ANIMATION = "Jump";

    private string MONSTERS_TAG = "Monsters";
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
        anim.SetBool(JUMP_ANIMATION, false);
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
            anim.SetBool(JUMP_ANIMATION, true);
            justJump = false;
        }
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxis("Horizontal");
        if (isGrounded)
        {
            anim.SetBool(JUMP_ANIMATION, false);
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
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            justJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(MONSTERS_TAG))
        {
            Destroy(gameObject);
        }
    }
}
