using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour
{
    int UD = 0;
    float ud = 1;
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        if (UD > 0)
        {

            ud = -1f;
        }
        else if (UD < 0)
        {
            ud = 1f;
        }
        this.transform.Translate(new Vector3(0, ud/5f, 0));
        UD += (int)ud;
        StartCoroutine(Timer());
    }
}
