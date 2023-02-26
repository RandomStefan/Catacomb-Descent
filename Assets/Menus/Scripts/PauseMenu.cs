using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup gameHUD;
    public CanvasGroup pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            CloseCanvasGroup(gameHUD);
            OpenCanvasGroup(pauseMenu);
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        CloseCanvasGroup(pauseMenu);
        OpenCanvasGroup(gameHUD);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    // Helper functions

    private void OpenCanvasGroup(CanvasGroup cg)
    {
        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    private void CloseCanvasGroup(CanvasGroup cg)
    {
        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
