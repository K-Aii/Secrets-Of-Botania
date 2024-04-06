using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.transform.position);

        if (player.transform.position.y < -15) {
            player.transform.position = new Vector3(-7f,0,0);
        }
    }
}
