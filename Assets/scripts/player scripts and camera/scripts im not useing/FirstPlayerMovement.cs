using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FirstPlayerMovement : MonoBehaviour
{// i think varriables   
    
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;

    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask Groundmask;

    public int MaxJumps;
    private int CurrentJump = 1;
    private bool CanJumpAgain = true;

    Vector3 velocity;
    bool isgrounded;

    #region Guns&Levels
    [System.Serializable]
    public struct Vector2i
    {
        public string Gun;
        [Range(0, 100)]
        public int AvailableAtLevel;
        public bool isAvailable;
    }

    [Header("Level and Guns")]
    public int PlayerLevel = 0;
    public List<Vector2i> AllGuns = new List<Vector2i>();
    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Guns&Levels
        // Level down when i press number 1 on keyboard (cannot have negative level)
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerLevel > 0)
        {
            PlayerLevel = PlayerLevel - 1;
        }
        // Level up when i press number 2 on keyboard (cannot go above 100 levels)
        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerLevel < 100)
        {
            PlayerLevel = PlayerLevel + 1;
        }
        // Check all gun list
        for (int i = 0; i < AllGuns.Count; i++)
        {
            // check the player level if is bigger then the unlock level of the gun
            if (PlayerLevel > AllGuns[i].AvailableAtLevel)
            {
                // if true
                // make the gun available
                Vector2i temp = AllGuns[i];
                temp.isAvailable = true;
                AllGuns[i] = temp;
            }
            else
            {
                // if false
                // make the gun unavailable
                Vector2i temp = AllGuns[i];
                temp.isAvailable = false;
                AllGuns[i] = temp;
            }
        }
        #endregion

        // ground checker for gravity so gravity doesnt go be r serk
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, Groundmask);
        // checks if its grounded or not
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }

        // geting directions for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // variable to move
        Vector3 move = transform.right * x + transform.forward * z;
        // code movement
        controller.Move(move * speed * Time.deltaTime);

        // code to for jump     
        if(Input.GetButtonDown ("jump") && CurrentJump < MaxJumps && CanJumpAgain /*&& isgrounded*/)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);

            CurrentJump++;
        }//  decetcs if ur on the ground and if ur not its false
        else if (CurrentJump >= MaxJumps)
        {
            CanJumpAgain = false;
        }
        // checks if ur on the ground and if u are its true
        if (isgrounded)
        {
            CanJumpAgain = true;
            CurrentJump = 1;
        }

        // velocity gravity
        velocity.y += gravity * Time.deltaTime;

        // moveing velocity to player
        controller.Move(velocity * Time.deltaTime);

    }
}
