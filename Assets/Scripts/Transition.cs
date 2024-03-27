using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int nextLevel;
    public Animator transAnim;
    GameObject trans;

    public static Transition instance;

    public void Awake()
    {
        trans = GameObject.Find("trans");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(trans);
        }
        else {
            Destroy(trans);
        }
    }


    public void NextLevel() {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel() {
        transAnim.SetTrigger("fadeIn");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(nextLevel);
        transAnim.SetTrigger("fadeOut");

    }
    
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            NextLevel();
        }
    }


}
