using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool playerMoving;
    public Vector2 lastMove;
    public float ClampMoveX;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    //public float attackTime;
    //private float attackTimeCounter;
    //private bool attacking2;
    //public float attackTime2;
    //private float attackTimeCounter2;
    //private bool hasJBeenPressed;

    public string startPoint;

    private SFXManager sfxMan;


    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        lastMove = new Vector2(0, -1f);

    }

    // Update is called once per frame
    void Update()
    {


         playerMoving = false;
          if (!attacking)
          {
              moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
              if (Input.GetAxisRaw("Horizontal") != 0)
              {
                  anim.SetFloat("ClampMoveX", Input.GetAxisRaw("Horizontal"));
              }
              if(moveInput != Vector2.zero)
              {
                  myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                  playerMoving = true;
                  lastMove = moveInput;
              }
              else
              {
                  myRigidbody.velocity = Vector2.zero;
              }

            /*if (Input.GetKeyDown(KeyCode.J))
            {
                sfxMan.playerAttack.Play();
                myRigidbody.velocity = Vector2.zero;

                if (hasJBeenPressed == true) //(Input.GetKeyDown(KeyCode.J))
                {
                    attackTimeCounter2 = attackTime2;
                    attacking2 = true;
                    anim.SetBool("Attack2", true);
                    hasJBeenPressed = false;
                }
                else
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    anim.SetBool("Attack", true);
                    hasJBeenPressed = true;
                }
            }
        }
            if (attackTimeCounter > 0)
            {
                attackTimeCounter -= Time.deltaTime;
            }

            if (attackTimeCounter <= 0)
            {
                attacking = false;
                anim.SetBool("Attack", false);
            }
        if (attackTimeCounter2 > 0)
        {
            attackTimeCounter2 -= Time.deltaTime;
        }

        if (attackTimeCounter2 <= 0)
        {
            attacking2 = false;
            anim.SetBool("Attack2", false);*/
        }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        
    }
}
