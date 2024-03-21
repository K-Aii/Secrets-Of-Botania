using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce;
    Rigidbody2D rb;
    private float xInput;

    Animator anim;
    //Vector2 lookDirection = new Vector2(1, 0);

    bool isFacingR = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        FlipSprite();

        //Vector2 move = new Vector2(xInput, yInput);

        //if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        //{
        //    lookDirection.Set(move.x, move.y);
        //    lookDirection.Normalize();
        //}

        //anim.SetFloat("MoveX", lookDirection.x);
        //anim.SetFloat("MoveY", lookDirection.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector2.up * jumpforce);
            rb.velocity = Vector2.up * jumpforce;
            print("jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Bend");
        }
    }

    private void FixedUpdate()
    {
        //========PLAYER MOVEMENT=======
        //transform.position += (new Vector3(xInput, yInput, 0)) * speed * Time.deltaTime;
        rb.velocity = new Vector3(xInput, rb.velocity.y, 0) * speed;
        //Vector2 movePos = new Vector2(xInput, yInput) * speed * Time.fixedDeltaTime;
        //Vector2 newPos = (Vector2)transform.position + movePos;
        //rb.MovePosition(newPos);
    }

    void FlipSprite() {
        if (isFacingR && xInput < 0 || !isFacingR && xInput > 0) {
            isFacingR = !isFacingR;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }
}
