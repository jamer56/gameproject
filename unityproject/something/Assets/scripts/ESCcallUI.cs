using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCcallUI : MonoBehaviour
{ 
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
