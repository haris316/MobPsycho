using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinpicker : MonoBehaviour
{
    public static float coin = 0;
    public TextMeshProUGUI textcoins;
    public GameObject GameWonPanel;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "coin")
        {   
            coin++;
            textcoins.text = coin.ToString();
            Destroy(other.gameObject);
            if (coin.ToString() == "21"){
                GameWonPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        
    }
}
