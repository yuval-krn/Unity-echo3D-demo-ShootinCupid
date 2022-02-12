/**************************************************************************
* Copyright (C) echoAR, Inc. (dba "echo3D") 2018-2021.                    *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echo3D.co/terms, or another agreement                       *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    private bool handled = false;

    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string ObjectName = this.gameObject.name;

        switch (ObjectName)
        {
            case "kupid.glb":
                CupidBehav();
                break;
            case "arrow.glb":
                ArrowBehav();
                break;
            default:
                break;
        }
    }

    private void CupidBehav()
    {
        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();
        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;
        remoteTrans.EchoScale = false;

        if (!handled)
        {
            Debug.Log("I am Cupid");

            Vector3 cupPos = new Vector3(0, 0, 14);
            transform.position = cupPos;

            Quaternion cupRot = Quaternion.Euler(0, 180, 0);
            transform.rotation = cupRot;

            Vector3 cupScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.localScale = cupScale;

            //add cupid movement script
            CupidMover sc = this.gameObject.AddComponent<CupidMover>();
            //add box collider, set properties
            BoxCollider Cc = this.gameObject.AddComponent<BoxCollider>();
            Cc.center = new Vector3(18.7f, 42.5f, -6.3f);
            Cc.size = new Vector3(27.15f, 53.9f, 21.43f);

            handled = true;
        }      
    }

    private void ArrowBehav()
    {

        RemoteTransformations remoteTrans = this.GetComponent<RemoteTransformations>();
        remoteTrans.EchoPos = false;
        remoteTrans.EchoRot = false;
        remoteTrans.EchoScale = false;

        if (!handled)
        {
            Debug.Log("I am Arrow");

            Vector3 arrPos = new Vector3(-15.8f, 19.2f, 62f);
            transform.position = arrPos;

            Quaternion arrRot = Quaternion.Euler(0, 180, 0);
            transform.rotation = arrRot;

            Vector3 arrScale = new Vector3(15, 15, 9);
            transform.localScale = arrScale;

            //add aiming script
            Aimer ArrAim = this.gameObject.AddComponent<Aimer>();
            //add box collider, set properties
            BoxCollider Ac = this.gameObject.AddComponent<BoxCollider>();
            Ac.center = new Vector3(0, 0, 0);
            Ac.size = new Vector3(0.13f, 0.13f, 1.36f);
            Ac.isTrigger = true;
            //add rigidbody, set properties
            Rigidbody Ar = this.gameObject.AddComponent<Rigidbody>();
            Ar.useGravity = false;
            Ar.isKinematic = true;

            handled = true;
        }
        
    }
}

//Notes: Heart background pulled from https://pixabay.com/photos/background-texture-heart-red-2062206/
//under the Pixabay license: Free for commercial use, No attribution required