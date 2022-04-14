using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveNew : MonoBehaviour
{
    private bool facingRight = true;
    private float moveInput;
    public Animator animator;    
    private Rigidbody2D rb;
    public float dirX, dirY, speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal" , CrossPlatformInputManager.GetAxis("Horizontal"));
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(dirX,dirY);
                moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(dirX,dirY);

	    if (moveInput > 0 && facingRight == false){
            flip();
        }
        else if(facingRight == true && moveInput < 0 ){
             flip();
        }
    }
    void flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
