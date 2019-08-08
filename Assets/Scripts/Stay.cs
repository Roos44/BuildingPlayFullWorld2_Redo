using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour
{
    public GameObject Platform;

    private void OnTriggerStay2D(Collider2D collision)
    {

        Platform.transform.position += Platform.transform.forward * Time.deltaTime;

    }
}
