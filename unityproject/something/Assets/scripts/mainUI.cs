using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainUI : MonoBehaviour
{


    private void Start()
    {
        gameObject.transform.parent.gameObject.transform.GetChild(2).GetChild(1).GetComponent<Slider>().value  =  options.dpiValue;
        //gameObject.transform.parent.gameObject.transform.GetChild(2).GetChild(1).GetComponent<Slide>().Value =

    }
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("clickPlay");
    }

    public void exitGame()
    {
        Application.Quit();
        print("exitGame");
    }
    public void dpiChange(float Value)
    {
        options.dpiValue = Value;
        print(options.dpiValue);
    }
}
