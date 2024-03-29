using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 2.0f;
    float timer;
    public float changeTime = 1.0f;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            FlipSprite();
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        rb.MovePosition(position);
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
