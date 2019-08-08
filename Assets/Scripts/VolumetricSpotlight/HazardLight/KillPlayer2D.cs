using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer2D : MonoBehaviour
{
    GameObject player;


   void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hitTrigger");
        if(col.gameObject.name == "Player")
        {
            player = col.gameObject;
            player.GetComponent<PlayerStatus>().playerHealth = 0;
        }
    }
}
