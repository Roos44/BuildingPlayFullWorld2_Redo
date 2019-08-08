using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHit : MonoBehaviour
{


    //Or OnTriggerEnter2d but need rigidbody??
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            //Casts to parent, gets script MoveToTarget and sets its 'isTriggered' variable to true
            this.gameObject.GetComponentInParent<MoveToTarget>().isTriggered = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }











}
