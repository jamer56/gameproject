using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loaslider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value  =  1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
