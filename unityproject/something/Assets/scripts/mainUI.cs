using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainUI : MonoBehaviour
{
    public static float dpiValue=100;

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
        dpiValue = Value;
        print(dpiValue);
    }
}
