using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Camera ca;
    private Ray ra;
    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ra = ca.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit))
            {
                hit.collider.gameObject.transform.position = ca.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.collider.gameObject.transform.position.z));
            }
        }
    }
}