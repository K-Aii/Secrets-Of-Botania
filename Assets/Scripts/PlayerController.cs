using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpforce;
    Rigidbody2D rb;
    private float xInput;

    Animator anim;

    AudioSource audioSource;
    public AudioClip damaged, water;
    public bool isFalling = false;
    BlackFade fade;

    public bool isFacingR = true;
    public GameObject cutPrefab, jetPrefab, swimPrefab;//, bear, respawn1, respawn2;

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

        if (xInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else {
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();            
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

    public void Die() {
        audioSource.PlayOneShot(damaged);
        StartCoroutine(fade.FadeOut(1f));
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(1.5f);
        rb.velocity = new Vector2(0, 0);
        rb.simulated = false;
        transform.position = new Vector3(-7f, -1.25f, 0);
        //Instantiate(bear, respawn1.transform.position, respawn1.transform.rotation);
        StartCoroutine(fade.FadeIn(1f));
        rb.simulated = true;
        isFalling = false;
    }

    // ================= SKILLS =================

    public void Jump() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Floor"));     //ground check
        if (hit.collider != null)
        {
            rb.AddForce(Vector2.up * jumpforce);
        }
    }

    public void Cut() {
        GameObject cutEffect = Instantiate(cutPrefab, rb.position, Quaternion.identity);

        cutEffect.transform.localScale = isFacingR ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);      //flip sprite

        Vector2 lookDirection = isFacingR ? new Vector2(1,0) : new Vector2(-1,0);
        cutEffect.GetComponent<Cut>().Launch(lookDirection, 300);
    }

    public void Swim() {
        GameObject swimEffect = Instantiate(swimPrefab, rb.position + Vector2.left * 1.1f, Quaternion.identity);
    }

    public IEnumerator Jet() {
        rb.AddForce(Vector2.up * 100);
        rb.gravityScale = 1;
        transform.rotation = Quaternion.Euler(isFacingR ? new Vector3(0, 0, -90) : new Vector3(0, 0, 90));
        GetComponent<CapsuleCollider2D>().enabled = true;

        GameObject jetEffect = Instantiate(jetPrefab, rb.position, Quaternion.identity);
        audioSource.PlayOneShot(water);
        
        float currentTime = 0;
        while (currentTime < 0.3f)
        {
            currentTime += Time.deltaTime;
            if(isFacingR)
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0.3f, 0, 0), currentTime/0.3f);
            else
                transform.position = Vector3.Lerp(transform.position, transform.position - new Vector3(0.3f, 0, 0), currentTime / 0.3f);
            yield return null;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.gravityScale = 2;
        Destroy(jetEffect);
        
    }

    // WaterJet collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Octopus" ) {
            collision.enabled = false;
            Destroy(collision.gameObject);
        } 
    }
}
