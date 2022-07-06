using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    #endregion
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
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
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //Vector2 newPos = new Vector2( transform.position.x,transform.position.y);
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (0f < movementX )
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }else if(movementX < 0f)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }


    }
}
