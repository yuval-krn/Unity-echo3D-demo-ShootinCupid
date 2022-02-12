using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroyer : MonoBehaviour
{

    GameObject cupid;
    GameObject arrow;

    public void PlayGame()
    {
        if (cupid && arrow)
        {
            cupid.SetActive(true);
            arrow.SetActive(true);
        }
        this.gameObject.SetActive(false);
        Debug.Log("Yes this code has run! " + this.gameObject.name);
    }

    public void EndGame()
    {
        cupid = GameObject.Find("kupid.glb");
        cupid.SetActive(false);
        arrow = GameObject.Find("arrow.glb");
        arrow.SetActive(false);

        this.gameObject.SetActive(true);
    }
}
