using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Decline());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x - 1.1f, player.position.y, transform.position.z);
    }

    IEnumerator Decline() {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
