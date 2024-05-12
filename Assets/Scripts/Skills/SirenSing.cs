using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenSing : MonoBehaviour
{
    bool isPulling, isCounting = false;
    Transform player;
    InventoryManager inv;
    public Item potion;
    AudioSource audioSource;
    public AudioClip noti, ding;
    public Transform rock;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inv = GameObject.Find("GameController").GetComponent<InventoryManager>();
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPulling) {
            rock.GetComponent<PolygonCollider2D>().enabled = true;
            player.GetComponent<Rigidbody2D>().AddForce((rock.position - player.position).normalized * 190);
            if (!isCounting)
                StartCoroutine(Timer());
        }

    }
    IEnumerator Timer() {
        isCounting = true;
        yield return new WaitForSeconds(5);
        print("Die: SirenSing");
        player.GetComponent<PlayerController>().Die();
        yield return new WaitForSeconds(1f);
        isPulling = false;
        isCounting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPulling = true;

        if (inv.SearchItem(potion) != null)
        {
            inv.SearchItem(potion).Activate();
            audioSource.PlayOneShot(noti);
        }

        GetComponent<BoxCollider2D>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        if (inv.SearchItem(potion) != null)
            inv.SearchItem(potion).Deselect();
    }

    IEnumerator FadeIn() {
        float currentTime = 0;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(0, 0.62f, currentTime / 1f);
            transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, newA);
            yield return null;
        }
        yield break;
    }

    IEnumerator FadeOut()
    {
        float currentTime = 0;
        float A = transform.GetChild(1).GetComponent<SpriteRenderer>().color.a;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(A, 0, currentTime / 1f);
            transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, newA);
            yield return null;
        }
        yield break;
    }

    public void Pacify() {
        StopAllCoroutines();
        isPulling = false;
        isCounting = false;
        rock.GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(FadeOut());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        GameObject.Find("sing").GetComponent<SpriteRenderer>().enabled = true;
        audioSource.PlayOneShot(ding);
        if (rock.GetComponent<PolygonCollider2D>())
            rock.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
