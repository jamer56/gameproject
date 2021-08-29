using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take : MonoBehaviour
{
    Ray ray;
    float raylength = 1.5f;
    RaycastHit hit;
    GameObject[] myObjArray;

    private bool flag_clean_Gravity_one  =  false;
    private bool moveable =  false;
    private string take_name="";

    void Start()
    {

    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            flag_clean_Gravity_one = true;
            if (hit.transform.tag == "moveable" && Input.GetMouseButtonDown(0))
            {
                take_name = hit.transform.name;
                moveable  =  true;
            }
            if (hit.transform.tag != "moveable")
            {
                moveable = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                moveable =  false;
            }
            if (hit.transform.name != take_name)
            {
                moveable = false;
            }
            if (moveable && Input.GetMouseButton(0))
            {
                hit.rigidbody.useGravity = false;
                hit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.5f));
            }
        }
        else
        {
            moveable  =  false;
        }
        if (moveable != true && flag_clean_Gravity_one)
        {
            CleanUseGravity();
            flag_clean_Gravity_one  =  false;
        }

    }

    void CleanUseGravity()
    {
        myObjArray = GameObject.FindGameObjectsWithTag("moveable");
        for (int i = 0; i < myObjArray.Length; i++)
        {
            myObjArray[i].GetComponent<Rigidbody>().useGravity = true;
            print("run" + i);
        }
    }

    
}