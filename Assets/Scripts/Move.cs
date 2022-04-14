using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed,dirX,dirY;
    private bool facingRight = true;
    private float moveInput;
    public Animator animator;
    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 20f;
    }

    // Update is called once per frame
    void Update(){

        animator.SetFloat("Horizontal" , Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
    void FixedUpdate(){

        moveInput = Input.GetAxis("Horizontal");
        
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
