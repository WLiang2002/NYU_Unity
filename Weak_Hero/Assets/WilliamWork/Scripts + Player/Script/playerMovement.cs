
using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPow;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator animate;
    private float horiInput;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        //getting reference from object
        body = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horiInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        
        //Flipping the player
        if (horiInput > 0.01f){
            transform.localScale = Vector3.one;
        }
        else if (horiInput < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && onGround())
            Jump();
        
        //set animate parameters
        animate.SetBool("Run", horiInput != 0);
        animate.SetBool("Grounded", onGround());
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPow);
        animate.SetTrigger("Jump");
       
    }



    private bool onGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,
            0.1f, groundLayer);
        return raycastHit.collider != null;
    }

  public bool canAttack()
    {
        return horiInput == 0 && onGround(); 
    }
   
}


