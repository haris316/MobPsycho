using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
     
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void MainMenu(){
        SceneManager.LoadScene("Map");
    }

    public void SuperMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume(){
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused=false;
    }
    public void Pause(){
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused=true;
    }
}
