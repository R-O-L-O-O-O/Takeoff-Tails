using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject pausetext;
    public bool paused;
    public Animator anim;

    public float transitionTime = 1f;
    public float transitionAnimationTime = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        gameOver.SetActive(false);
        pausetext.SetActive(false);
        Time.timeScale = 1;

        GetComponent<AudioSource>();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        GetComponent<AudioSource>().Stop();
        StartCoroutine(FadeTransition());
        StartCoroutine(LoadTitle());
    }

    IEnumerator LoadTitle()
    {
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(0);
    }

    IEnumerator FadeTransition()
    {
        yield return new WaitForSecondsRealtime(transitionAnimationTime);
        anim.SetTrigger("FadeOut");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            if (paused == false)
            {
                pausetext.SetActive(false);
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
            if (paused == true)
            {
                pausetext.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
        }
    }
}
