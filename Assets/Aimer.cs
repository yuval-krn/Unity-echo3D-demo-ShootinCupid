using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    Vector3 toGoto = new Vector3(0.0f, 0.0f, 0.0f);
    bool moving = false;
    TimeandScoreUpdater TandSKeeper;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        TandSKeeper = GameObject.Find("TimeKeeper").GetComponent<TimeandScoreUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray1;
        Vector3 fingPos = new Vector3(-9.7f, 17.7f, -14);
        if (Input.touchCount > 0 && (Input.touches[0].phase == TouchPhase.Began
            || Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary))
        {
            ray1 = Camera.main.ScreenPointToRay(Input.touches[0].position);
            fingPos = ray1.GetPoint(60);
            fingPos.z = -14;
        }
        if (!moving)
        {
                transform.LookAt(fingPos);
                transform.Rotate(0, 180, 0);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
                toGoto = fingPos;
                moving = true;
                Debug.Log(toGoto.ToString());
        }

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, toGoto, 0.5f);
            //Debug.Log(transform.position.ToString());
            //Debug.Log(toGoto.ToString());
            if (Vector3.Distance(transform.position, toGoto) < 0.5f)
            {
                moving = false;
                transform.position = new Vector3(-15.8f, 19.2f, 62f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
             }
        }

#if UNITY_EDITOR
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = ray.GetPoint(60);
        mousePos.z = -14;

        if (!moving)
        {
            transform.LookAt(mousePos);
            transform.Rotate(0, 180, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {

            toGoto = mousePos;
            moving = true;
            Debug.Log(toGoto.ToString());
        }

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, toGoto, 0.5f);
            //Debug.Log(transform.position.ToString());
            //Debug.Log(toGoto.ToString());
            if (Vector3.Distance(transform.position, toGoto) < 0.5f)
            {

                moving = false;
                transform.position = new Vector3(-15.8f, 19.2f, 62f);
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
#endif
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("We hit something!");
        moving = false;
        transform.position = new Vector3(-15.8f, 19.2f, 62f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        TandSKeeper.scoreAdd();
    }
}
