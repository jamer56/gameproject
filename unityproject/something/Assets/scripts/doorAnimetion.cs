using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimetion : MonoBehaviour
{
    private bool isopen = false;
    private bool flagOne = true;
    public string AnimationName = "open1";
    Animation doorAnimation;

    void Start()
    {
        doorAnimation = this.GetComponent<Animation>();
    }

    void Update()
    {
        flagOne  =  true;
        if(Input.GetKeyDown(KeyCode.F) && isopen == false && flagOne && doorAnimation[AnimationName].time == 0)
        {
            doorAnimation[AnimationName].speed = 1F;
            doorAnimation.Play(AnimationName);
            Debug.Log("OpenDoor");
            isopen = true;
            flagOne  =  false;
        }

        if(Input.GetKeyDown(KeyCode.F) && isopen == true && flagOne && doorAnimation[AnimationName].time == 0)
        {
            doorAnimation[AnimationName].time = doorAnimation[AnimationName].length;
            doorAnimation[AnimationName].speed = -1F;
            doorAnimation.Play(AnimationName);
            Debug.Log("CloseDoor");
            isopen = false;
            flagOne = false;
        }
        //Debug.Log(doorAnimation[AnimationName].time);
    }
}
