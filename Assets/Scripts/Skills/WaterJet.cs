using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJet : MonoBehaviour
{
    Transform player;
    PlayerController pc;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isFacingR)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = new Vector3(player.position.x - 1, player.position.y, transform.position.z);
        }
        else 
        { 
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = new Vector3(player.position.x + 1, player.position.y, transform.position.z);
        }

    }
}
