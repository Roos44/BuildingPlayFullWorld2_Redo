using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour{


    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;


    public GameObject player;

    /* void Start()
     {
         player = GameObject.FindGameObjectWithTag("player");

 //        StartCoroutine(MoveOverField());
     }*/


    void fixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);


        transform.position = new Vector4(posX, posY, transform.position.z);
    }



        //void Update()
        //{
        //}
        //Coroutine, speciale functie die gepauzeerd kan worden, begint altijd met IEnumerator
        // IEnumerator MoveOverField()
        //  {
        //float timer = .0f;
        //while (timer < .5f)
        // {
        //    timer += Time.deltaTime;//deltaTime is de tijd tussen het vorige frame en het huidige frame
        //   transform.position -= new Vector3(5f * Time.deltaTime, .0f, .0f);
        //  yield return 0; //Pauzeer de coroutine en ga het volgende frame weer verder
        //  }
        // yield return new WaitForSeconds(.5f); //Pauzeer de coroutine en ga over een halve seconde weer verder

        // while (timer < 1.5f)
        //  {
        //   timer += Time.deltaTime;
        //   transform.position += new Vector3(5f * Time.deltaTime, .0f, .0f);
        //  yield return 0;
    }
