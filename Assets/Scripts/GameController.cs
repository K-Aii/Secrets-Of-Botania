using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject player;
    public AudioClip fall_scream;
    BlackFade fade;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        fade = FindObjectOfType<BlackFade>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.transform.position);

        //if (player.transform.position.y < -15) {
        //    player.GetComponent<AudioSource>().PlayOneShot(fall_scream);
        //    StartCoroutine(fade.FadeOut(1f));
        //    player.transform.position = new Vector3(-7f,0,0);
        //}
    }
}
