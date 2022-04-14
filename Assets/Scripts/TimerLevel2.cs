    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerLevel2 : MonoBehaviour
{

    public GameObject textDisplay;
    public GameObject gameWonPanel;
    public int secondsLeft = 15;
    public bool takingAway = false;
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        gameWonPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if(secondsLeft == 0)
        {
            gameWonPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft <10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else if(secondsLeft == 0)
        {
            gameWonPanel.SetActive(true);
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
    }

}
