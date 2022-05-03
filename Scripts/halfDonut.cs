using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfDonut : MonoBehaviour
{
    private Animator animCont;
    private int min = 2;
    private int max = 5;
    private float setTriggerTime;
    private float stopWatch;

    private void Start()
    {
        animCont = GetComponent<Animator>();
        setTriggerTime = Random.Range(min, max);
    }

    private void FixedUpdate()
    {
        stopWatch += Time.deltaTime;
        if (stopWatch>=setTriggerTime)
        {
            animCont.SetTrigger("move");
            stopWatch = 0.0f;
            setTriggerTime = Random.Range(min, max);
        }
    }
}
