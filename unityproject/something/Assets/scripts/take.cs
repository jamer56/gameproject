using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take : MonoBehaviour
{
    Ray ray;
    float raylength = 1.5f;
    RaycastHit hit;
    GameObject[] myObjArray;
    Vector3 posdelta;

    private bool flag_clean_Gravity_one  =  false;
    private bool moveable =  false;
    private string take_name="";


    public Vector3 addForce; //Õ{ÕûÁ¦¶È
    public float maxdistance;
    void Start()
    {
        
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, raylength))
        {
            
            if (hit.transform.tag == "moveable" && Input.GetMouseButtonDown(0))
            {
                flag_clean_Gravity_one = true;
                take_name = hit.transform.name;
                moveable  =  true;
            }
            if (hit.transform.tag != "moveable")
            {
                //moveable = false;
            }

            
            if (hit.transform.name != take_name)
            {
                //moveable = false;
            }

        }
        else
        {
            //moveable  =  false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveable = false;
        }

        if (moveable && Input.GetMouseButton(0))
        {
            GameObject.Find(take_name).GetComponent<Rigidbody>().useGravity = false;
            posdelta = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.5f)) - GameObject.Find(take_name).transform.position;
            if (Mathf.Abs(posdelta.x) < maxdistance && Mathf.Abs(posdelta.y) < maxdistance && Mathf.Abs(posdelta.z) < maxdistance)
            {
                //hit.rigidbody.AddForce(posdelta.x*addForce.x,posdelta.y*addForce.y,posdelta.z*addForce.z);
                GameObject.Find(take_name).GetComponent<Rigidbody>().AddForce(posdelta.x * addForce.x, posdelta.y * addForce.y, posdelta.z * addForce.z);
                //hit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.5f));
            }
            else
            {
                Debug.Log("tooFast");
                moveable = false;
            }
            
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