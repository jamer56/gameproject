using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravity;

    private Vector3 velocity;

    private MeshCollider cc;

    void Start()
    {
        cc = GetComponent<MeshCollider>();
    }

    void Update()
    {
        velocity.y = -2f;

        velocity.y -= gravity * Time.deltaTime;
    }
}
