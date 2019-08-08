using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardLight_Main : MonoBehaviour
{
    readonly GameObject NewScenetrigger;
    public float raycastAngle;
    public bool raycastHit;

    public float timeBetweenInterval;
    public bool switchedOn;

    float timeLeft;

    Light thisLight;
    MeshRenderer thisMeshRenderer;

    private MeshCollider col;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        thisLight = GetComponent<Light>();
        thisMeshRenderer = GetComponent<MeshRenderer>();
        timeLeft = timeBetweenInterval;
        col = GetComponent<MeshCollider>();
        col.convex = true;
        col.isTrigger = true;
        rb2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            SwitchLight();
        }

    }

    void SwitchLight()
    {
        if (switchedOn)
        {
            thisLight.enabled = false;
            thisMeshRenderer.enabled = false;
            switchedOn = false;
            

        }
        else
        {
            thisLight.enabled = true;
            thisMeshRenderer.enabled = true;
            switchedOn = true;
            
        }


        timeLeft = timeBetweenInterval;
    }



    void OnTriggerEnter(Collider other)
    {
         Vector2 direction = other.transform.position - transform.position;
        if (other.gameObject.name == "Player")
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction.normalized);

            if(hit2D.collider == other)
            {
                Debug.Log(other);
            }
        }
    }

}
