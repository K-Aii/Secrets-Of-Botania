using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkFade : MonoBehaviour
{
    SpriteRenderer ink;
    bool started;
    
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        ink = GameObject.Find("ink").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ink.enabled && !started)
            StartCoroutine(InkSplash());
    }


    IEnumerator InkSplash()
    {
        started = true;
        yield return new WaitForSeconds(0.7f);
        float currentTime = 0;
        while (currentTime < 2f)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(1, 0, currentTime / 2f);
            ink.color = new Color(0, 0, 0, newA);
            yield return null;
        }
        ink.enabled = false;
        started = false;
    }
}
