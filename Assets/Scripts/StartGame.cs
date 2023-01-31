using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator anim;
    public float transitionAnimationTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.anyKeyDown)
        {
            Debug.Log("Game Started!");
            StartCoroutine(FadeTransition());
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator FadeTransition()
    {
        yield return new WaitForSecondsRealtime(transitionAnimationTime);
        anim.SetTrigger("FadeOut");
    }
}
