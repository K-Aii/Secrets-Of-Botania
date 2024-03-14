using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rb;
    private float xInput, yInput;

    Animator anim;
    Vector2 lookDirection = new Vector2(1, 0);

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
        yInput = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(xInput, yInput);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        anim.SetFloat("MoveX", lookDirection.x);
        anim.SetFloat("MoveY", lookDirection.y);
        anim.SetFloat("Speed", move.magnitude);
    }

    private void FixedUpdate()
    {
        //========PLAYER MOVEMENT=======
        //transform.position += (new Vector3(xInput, yInput, 0)) * speed * Time.deltaTime;
        Vector2 movePos = new Vector2(xInput, yInput) * speed * Time.fixedDeltaTime;
        Vector2 newPos = (Vector2)transform.position + movePos;
        rb.MovePosition(newPos);
    }
}
