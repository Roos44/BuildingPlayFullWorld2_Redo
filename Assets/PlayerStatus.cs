using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerStatus : MonoBehaviour
{ 
    //Cache
    private AudioManager audioManager;
    public string GameOverSound;
    public string MoveSound;

    bool isDead;
    public GameObject GameRestScreen;

   // Rigidbody2D prb;                                //Player RigedBody
    public int playerHealth;
    //float dirX, moveSpeed = 5f;
    //public bool isTriggered;
    // Start is called before the first frame update



    void Start()
    {
        GameRestScreen.SetActive(false);
        isDead = false;
        //  prb = GetComponent<Rigidbody2D>();

        //Cache
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("O On Onon audiomaneger in scener");
        }
    }
    // Update is called once per frame
    // [System.Obsolete]
    void Update()
    {
        //Debug.Log(playerHealth);
        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead");
            Invoke("ResetGame", 4f);

        }

        if (transform.position.y <= -17 && isDead == false)
        {
            audioManager.PlaySound(GameOverSound);
            Invoke("ResetGame", 4f);
            isDead = true;
            GameRestScreen.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (this.gameObject.GetComponent<PlatformerCharacter2D>().isRunning == false)
        {
            Debug.Log("Player is running");
            audioManager.PlaySound(MoveSound);

        }
           
    }


    // private void FixedUpdate()
    // {
    //      prb.velocity = new Vector2(dirX, prb.velocity.y);
    // }

    void OnCollisionEnter2D(Collision2D col)         //                    /\  ()
    {                                                // het werk eindelijk ;-; /                               
        if (col.gameObject.name.Equals("MovingPlatform_ToTarget"))          
            this.transform.parent = col.transform;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("MovingPlatform_ToTarget"))
            this.transform.parent = null;
    }

    //public IEnumerable _Restart

    public float deathDelay;
    public void ResetGame()
    {

        Debug.Log("died");
               
        Application.LoadLevel(Application.loadedLevel);

    }
}
/*
    public void AttemptMove(PlatformerCharacter2D)
    {
       GameObject player = GameObject.Find("Player");
        player.GetComponent < PlatformerCharacter2D.>;   
    }
    */
