using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    /*private Ray ra;
    private RaycastHit hit;
    */
    public float rotate_speed=5f;

    Ray ray;
    float raylength = 1.5f;
    RaycastHit hit;
    GameObject[] myObjArray;
    private bool chickColl=false;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width  /  2,  Screen.height  /  2,  0));
        if (Physics.Raycast(ray, out hit, raylength))
        {

            //hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
            //Debug.DrawLine(ray.origin, hit.point, Color.black);
            //print(hit.transform.name);
            //print(hit.transform.tag);


            if (hit.transform.tag == "moveable" && (Input.mouseScrollDelta.y != 0))
            {
                Vector3 rote;
                rote.x = Input.mouseScrollDelta.y*rotate_speed * Camera.main.transform.rotation.eulerAngles.x/360;
                rote.y = Input.mouseScrollDelta.y*rotate_speed * (GameObject.FindWithTag("Player").transform.rotation.eulerAngles.y-180)/180;
                print(rote.y);
                hit.transform.Rotate(rote.y, rote.y ,0 ,Space.World);
            }

                if (hit.transform.tag == "moveable" && Input.GetMouseButtonDown(0))
            {
                print("click dowm");
                hit.rigidbody.useGravity = false;
                chickColl = true;
            }

            if (hit.transform.tag == "moveable" && Input.GetMouseButton(0) && chickColl)
            {
                hit.transform.LookAt(GameObject.FindWithTag("Player").transform);
                hit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.5f));
            }



            //if (hit.transform.tag == "moveable" && Input.GetMouseButtonDown(0))


        }
        else
        {
            if (chickColl)
            {
                print("out");
                myObjArray = GameObject.FindGameObjectsWithTag("moveable");
                for (int i = 0; i < myObjArray.Length; i++)
                {
                    myObjArray[i].GetComponent<Rigidbody>().useGravity = true;
                    print("run" + i);
                }
                chickColl = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            print("click up");
            myObjArray = GameObject.FindGameObjectsWithTag("moveable");
            for (int i = 0; i < myObjArray.Length; i++)
            {
                myObjArray[i].GetComponent<Rigidbody>().useGravity = true;
                print("run" + i);
            }
        }


        /*if (Input.GetMouseButton(0))
        {
            ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit))
            {
                hit.collider.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.collider.gameObject.transform.position.z));
            }
        }*/
    }




}