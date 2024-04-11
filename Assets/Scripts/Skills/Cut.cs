using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    Rigidbody2D rb;
    float distance;
    GameObject player;
    BoxCollider2D treeCollider;
    public AudioClip fell;
    AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        treeCollider = GameObject.FindWithTag("Interactable").GetComponent<BoxCollider2D>();
        audioSource = GameObject.FindWithTag("Interactable").GetComponent<AudioSource>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
        StartCoroutine(Decline());
    }

    void Update()
    {

    }


    IEnumerator Decline()
    {
        float currentTime = 0;
        while (currentTime < 0.5f)
        {
            currentTime += Time.deltaTime;
            float newS = Mathf.Lerp(1, 0, currentTime / 0.5f);
            transform.localScale = new Vector3(newS, newS, newS); 
            yield return null;
        }
        Destroy(gameObject);
        yield break;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.collider);
        //monsters(tag) take damage

        //tree cut down
        if (other.collider.tag == "Interactable") {
            //StartCoroutine(TreeFall(other.collider.gameObject));
            GameObject tree = other.collider.gameObject;
            tree.transform.rotation = tree.transform.rotation * Quaternion.Euler(0, 0, -90);
            audioSource.PlayOneShot(fell);

            other.collider.GetComponent<CutTree>().collide = true;
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), treeCollider, false);
            other.collider.GetComponent<CapsuleCollider2D>().enabled = false;

        }

        if (other.collider.tag == "Mobs") {
            Destroy(other.collider.gameObject);
        }

        Destroy(gameObject);
    }

    IEnumerator TreeFall(GameObject tree)
    {
        //Debug.Log(tree.transform.rotation * Quaternion.Euler(0, 0, -90));
        float currentTime = 0;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            //float newS = Mathf.Lerp(1, 0, currentTime / 1f);
            tree.transform.rotation = Quaternion.Slerp(tree.transform.rotation, Quaternion.Euler(tree.transform.rotation.x, tree.transform.rotation.y, 90f), currentTime / 1f);
            yield return null;
        }
        yield break;
    }
}