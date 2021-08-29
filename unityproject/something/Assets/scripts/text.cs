using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    private void Update()
    {   
        if(this.transform.position.y<-3)
        {
            Debug.Log("disable");
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.active = true;
        }
        else
        {
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.active = false;
        }
    }
}