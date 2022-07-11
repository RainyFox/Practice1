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

    bool leftClick;

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

        //Change face direction
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Find direction
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;
      
        // make sure x, y is 1
        direction = new Vector2(direction.x/Mathf.Abs(direction.x),direction.y/Mathf.Abs(direction.y));
        Debug.Log(direction);

        leftClick = Input.GetMouseButton(0);
        if (0 < direction.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        if (isGrounded && leftClick)
        {
            anim.SetBool(JUMP_ANIMATION, false);
            //TODO: set correct unit magnitude
            rb.velocity = new Vector2(direction.x * moveForce, rb.velocity.y);
        }
        else if(isGrounded)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void AnimatePlayer()
    {
        if (leftClick)
        {
            anim.SetBool(WALK_ANIMATION, true);
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
