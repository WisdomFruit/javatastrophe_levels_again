using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public GameObject MovingPlatform;
    Vector3 MPPos1 = new Vector3();
    Vector3 MPPos2 = new Vector3();
    bool Moving;

    void Start()
    {
        // PRE-DEFINED POSITIONS FOR PLATFORMS
        if(MovingPlatform.gameObject.name == "movingplatformtest")
        {
            MPPos1 = new Vector3(11.5f, 4f, 0.12817f);
            MPPos2 = new Vector3(14f, 6.5f, 0.12817f);
            Moving = false;
        }
        else if (MovingPlatform.gameObject.name == "movingplatformtest2")
        {
            MPPos1 = new Vector3(12f, 9f, 0.12817f);
            MPPos2 = new Vector3(17.5f, 9f, 0.12817f);
            Moving = true;
        }

        StartCoroutine(SwitchPosition());

    }

    void Update()
    {
        
    }

    IEnumerator SwitchPosition()
    {
        if (!Moving)
        {
            while (true)
            {
                float timer = 1;
                while (timer > .0001)
                {
                    yield return new WaitForSeconds(timer);
                    MovingPlatform.GetComponent<Renderer>().enabled = !MovingPlatform.GetComponent<Renderer>().enabled;
                    timer /= 1.25f;
                }
                if (MovingPlatform.transform.localPosition == MPPos1)
                {
                    MovingPlatform.transform.localPosition = MPPos2;
                }
                else
                {
                    MovingPlatform.transform.localPosition = MPPos1;
                }
                MovingPlatform.GetComponent<Renderer>().enabled = true;

                yield return new WaitForSeconds(2);
            }
        }
        else
        {
            //Vector3 StartPos = MovingPlatform.transform.position;
            while (true)
            {
                float move = 0.001f;
                while(MovingPlatform.transform.localPosition.x <= MPPos2.x)
                {
                    MovingPlatform.transform.localPosition = MovingPlatform.transform.localPosition + new Vector3(.1f, 0.0f, 0.0f);
                    move /= 1.25f;
                    yield return new WaitForSeconds(move);
                }

                while (MovingPlatform.transform.localPosition.x >= MPPos1.x)
                {
                    MovingPlatform.transform.localPosition = MovingPlatform.transform.localPosition - new Vector3(.1f, 0.0f, 0.0f);
                    move *= 1.25f;
                    yield return new WaitForSeconds(move);
                }
            }
        }
    }
}
