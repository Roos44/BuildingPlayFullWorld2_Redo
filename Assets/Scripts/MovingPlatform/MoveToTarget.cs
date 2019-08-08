using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

    public bool isTriggered;
    //float xPos;
    //float yPos;

    //public GameObject targetChild;

    public Vector3 targetPosition;

    public float speedModifier;
    //private Rigidbody2D prbg; //Player Rigidbody Gravety

    //public Rigidbody2D Prbg { get => prbg; set => prbg = value; }

    void Start()
    {
        //Find target child's position specifically, use editor variables until then
        targetPosition = this.gameObject.transform.GetChild(0).position;
        //prbg = GetComponent<Rigidbody2D>();
    }

   /* private void Update()
    {
        if(isTriggered){

            prbg.gravityScale *= 1;

        }
    }
    */


    void FixedUpdate()
    {
        //Debug.Log(targetPosition);
        if(isTriggered)
        {
            Vector3 pos = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * speedModifier);
            transform.position = new Vector3(pos.x, pos.y, 0);

            //GameObject playerObject = GameObject.Find("Player").gameObject;
           // playerObject.GetComponent<Rigidbody2D>();

        

        }

    }
}
