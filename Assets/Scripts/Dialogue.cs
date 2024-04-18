using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    Transform player;

    public bool left = true;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.position = new Vector3(player.position.x + 2, player.position.y + 2, transform.position.z);
        }
        else 
        { 
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            transform.position = new Vector3(player.position.x - 2, player.position.y + 2, transform.position.z);
        }
        

    }
}
