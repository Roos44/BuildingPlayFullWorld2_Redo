using UnityEngine;
using UnityEngine.Audio;
using System;

namespace UnityStandardAssets._2D
{

    // [RequireComponent(typeof(SoundManager))]

    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private readonly float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private readonly bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = 0.8f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        public bool hasSoundPlayed;

        public bool isRunning = false;

        /*
        public AudioClip MoveSound1;
        public AudioClip MoveSound2;
        public AudioClip EffectSwoosh;
        public AudioClip EffectChime;
        public AudioClip gameOverSound;*/


        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            hasSoundPlayed = false;

        }

        public void Update()
        {
            
            if (m_Anim.GetFloat("Speed") >= 0.01f && m_Grounded)
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
            
        }

        public void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.K))
            { 
                SoundManager.PlaySound(SoundManager.Sound.MoveSound1);
            }
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
            //Debug.Log(m_Anim.GetInteger("Speed") + " anim speed variable");       
            /* if (m_Anim("vSpeed" != 90.01f)))
                 {
                       AudioClip.MoveSound1.playmode; }*/
        }
     
        public void Move(float move, bool crouch, bool jump)
        {
           
            
            //object latformerCharacter2D = null;
           // latformerCharacter2D.GetComponent<SoundManager>().RandomizeSfx();
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move * m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                
            }



        }

        private void Flip()
          {
              // Switch the way the player is labelled as facing.
             m_FacingRight = !m_FacingRight;

             // Multiply the player's x local scale by -1.
             Vector3 theScale = transform.localScale;
             theScale.x *= -1;
              transform.localScale = theScale;
          }


        /* if (m_Grounded == true)
             {
                 /*PlatformerCharacter2D.GetComponent<SoundManager>().RandomizeSfx();
                 GameObject player = GameObject.Find("Player");
                 gameObject.GetComponent < int Instance >;

            SoundManager.Instance.RandomizeSfx(MoveSound1, MoveSound2);
            }*/




    }

}