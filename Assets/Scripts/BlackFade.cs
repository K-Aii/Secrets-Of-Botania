using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    public bool isFading, completed;

    // Start is called before the first frame update
    void Start()
    {
        isFading = false;
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            StartCoroutine(FadeOut(1f));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(FadeIn(1f));
        }
    }

    public IEnumerator FadeIn(float fadeTime)  //black to trans
    {
        completed = false;
        float currentTime = 0;
        while (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(1, 0, currentTime / fadeTime);
            GetComponent<Image>().color = new Color(0, 0, 0, newA);
            yield return null;
        }
        yield return completed = true;
        yield return new WaitForSeconds(5);
        completed = false;
    }

    public IEnumerator FadeOut(float fadeTime)  //trans to black
    {
        completed = false;
        float currentTime = 0;
        while (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(0, 1, currentTime / fadeTime);
            GetComponent<Image>().color = new Color(0, 0, 0, newA);
            yield return null;
        }
        yield return completed = true;
        yield return new WaitForSeconds(5);
        completed = false;
    }

    public IEnumerator Fade()  //trans to black to trans
    {
        isFading = false;
        float currentTime = 0;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(0, 1, currentTime / 1f);
            GetComponent<Image>().color = new Color(0, 0, 0, newA);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        isFading = true;
        currentTime = 0;
        while (currentTime < 1f)
        {
            currentTime += Time.deltaTime;
            float newA = Mathf.Lerp(1, 0, currentTime / 1f);
            GetComponent<Image>().color = new Color(0, 0, 0, newA);
            yield return null;
        }
        isFading = false;
        yield break;
    }
}
