using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public GameObject HiddenObject;

    private void OnTriggerEnter2D()
    {

        Debug.Log("I am in");

        HiddenObject.SetActive(true);

    }
}