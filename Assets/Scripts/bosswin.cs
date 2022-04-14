using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bosswin : MonoBehaviour
{
    public GameObject gameOverPanel;


    public void MainMenu(){
        SceneManager.LoadScene("Map");
    }
}
