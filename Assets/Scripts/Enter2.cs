using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter2 : MonoBehaviour
{

    public GameObject Platform;

    private void OnTriggerEnter2D()
    {

        Debug.Log("I am in");

        Platform.GetComponent<SpriteRenderer>().enabled = true;

    }
}
