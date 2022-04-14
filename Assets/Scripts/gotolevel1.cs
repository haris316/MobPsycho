using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gotolevel1 : MonoBehaviour
{
    public GameObject panelS;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel5;
    public GameObject panelF;
	// Use this for initialization
	void Start () {
        panelS.gameObject.SetActive(true);
		panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        panel5.gameObject.SetActive(false);
        panelF.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select Stage
                if (hit.transform.name == "Sphere1")
                {
                    SceneManager.LoadScene("Level 1");
                }
                else if (hit.transform.name == "Boy1")
                {
                    panel1.gameObject.SetActive(true);                    
                }
                else if (hit.transform.name == "Button1")
                {
                    panel1.gameObject.SetActive(false);                    
                }
                else if (hit.transform.name == "Sphere2")
                {
                    SceneManager.LoadScene("Level 2");
                }
                else if (hit.transform.name == "Boy2")
                {
                    panel2.gameObject.SetActive(true);                    
                }
                else if (hit.transform.name == "Button2")
                {
                    panel2.gameObject.SetActive(false);                    
                }                
                else if (hit.transform.name == "Sphere3")
                {
                    SceneManager.LoadScene("Level3");
                }
                else if (hit.transform.name == "Boy3")
                {
                    panel3.gameObject.SetActive(true);                    
                }
                else if (hit.transform.name == "Button3")
                {
                    panel3.gameObject.SetActive(false);                    
                }
                else if (hit.transform.name == "Sphere5")
                {
                    SceneManager.LoadScene("BossLevel");
                }
                else if (hit.transform.name == "Boy5")
                {
                    panel5.gameObject.SetActive(true);                    
                }
                else if (hit.transform.name == "Button5")
                {
                    panel5.gameObject.SetActive(false);                    
                }
                else if (hit.transform.name == "SphereF")
                {
                    panelF.gameObject.SetActive(true);                    
                }
                else if (hit.transform.name == "Button6")
                {
                    panelF.gameObject.SetActive(false);                    
                }
            }
        }

    }
}
