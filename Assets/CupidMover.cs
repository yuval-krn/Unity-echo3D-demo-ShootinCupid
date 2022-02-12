using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidMover : MonoBehaviour
{
    bool going = true;
    Vector3 randLoc;
    private void Start()
    {
        randLoc = new Vector3(Random.Range(-51.0f, 25.0f), Random.Range(-4.0f, 30.0f), 14);
    }

    // Update is called once per frame
    void Update()
    {
        if (going)
        {
            transform.position = Vector3.MoveTowards(transform.position, randLoc, 0.25f);
        }
        if (Vector3.Distance(transform.position, randLoc) < 1.0f)
        {
            randLoc = new Vector3(Random.Range(-50.0f, 45.0f), Random.Range(-16.0f, 19.0f), 14);
        }

    }
}
