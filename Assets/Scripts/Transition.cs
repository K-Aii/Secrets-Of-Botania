using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public int nextLevel;
    BlackFade fade;
    bool stay;


    public static Transition instance;

    public void Awake()
    {
        fade = FindObjectOfType<BlackFade>();
        stay = false;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(GameObject.Find("Canvas"));
        }
        //else {
        //    Destroy(GameObject.Find("Canvas"));
        //}

        if (fade.GetComponent<Image>().color.a == 1)
            StartCoroutine(fade.FadeIn(1f));
    }

    private void Update()
    {
        if (fade.completed && stay)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }


    //public void NextLevel() {
    //    StartCoroutine(LoadLevel());
    //}

    //IEnumerator LoadLevel() {
    //    yield return new WaitForSeconds(2);
    //    SceneManager.LoadSceneAsync(nextLevel);

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            stay = true;
            StartCoroutine(fade.FadeOut(1f));
        }
    }


}
