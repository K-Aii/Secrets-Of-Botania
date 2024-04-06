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

    bool isFacingR = true;
    public GameObject cutPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpforce);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Bend");
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            Cut();
        }
    }

    private void FixedUpdate()
    {
         rb.velocity = new Vector3(xInput * speed, rb.velocity.y, 0);   //horizontal movement
    }

    void FlipSprite()
    {
        if (isFacingR && xInput < 0 || !isFacingR && xInput > 0)
        {
            isFacingR = !isFacingR;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    public void Cut() {
        GameObject cutEffect = Instantiate(cutPrefab, rb.position, Quaternion.identity);

        cutEffect.transform.localScale = isFacingR ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);      //flip sprite

        Cut cutScript = cutEffect.GetComponent<Cut>();
        Vector2 lookDirection = isFacingR ? new Vector2(1,0) : new Vector2(-1,0);
        cutScript.Launch(lookDirection, 300);

        //animator.SetTrigger("Launch");
    }
}
