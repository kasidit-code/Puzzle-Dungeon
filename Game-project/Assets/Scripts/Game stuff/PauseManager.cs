using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Animator animator;
    private bool isPaused;
    public GameObject pausePanel;
    public int movedScene;
    private int sceneToload;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            Resume();
        }
    }

    public void Resume()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Ouit(string sceneName)
    {
        FadeToScene(movedScene);
        Resume();
    }

    public void FadeToScene(int sceneName) {
        sceneToload = sceneName;
        animator.SetTrigger("FadeOut");
    }
    
    public void onFadeComplete() {
        SceneManager.LoadScene(sceneToload);
    }
    
}
