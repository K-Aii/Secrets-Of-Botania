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

    AudioSource audioSource;
    public AudioClip damaged;
    public bool isFalling = false;
    BlackFade fade;

    public bool isFacingR = true;
    public GameObject cutPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        fade = FindObjectOfType<BlackFade>();
    }

    void Update()
    {
        //Debug.Log(rb.velocity.y);
        
        xInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Floor"));     //ground check
            if (hit.collider != null)
            {
                rb.AddForce(Vector2.up * jumpforce);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Bend");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Cut();
        }

        //if (transform.position.y < -15)
        //{
        //    transform.position = new Vector3(-7f, -1.25f, 0);       //respawn if fallen out of map
        //}

        if (rb.velocity.y < -10 && !isFalling)                      //drop damage
        {    
            isFalling = true;
            Die();
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

    void Die() {
        audioSource.PlayOneShot(damaged);
        StartCoroutine(fade.FadeOut(1f));
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(1.5f);
        rb.velocity = new Vector2(0, 0);
        rb.simulated = false;
        transform.position = new Vector3(-7f, -1.25f, 0);
        StartCoroutine(fade.FadeIn(1f));
        rb.simulated = true;
        isFalling = false;
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
