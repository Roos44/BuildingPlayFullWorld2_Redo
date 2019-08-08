using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public GameObject Platform;

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        Debug.Log("I am in");

        

    }
}

