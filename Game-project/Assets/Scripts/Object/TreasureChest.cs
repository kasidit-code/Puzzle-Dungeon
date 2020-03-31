﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{

    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if(isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("attack") && playerInRange)
        {
            if(!isOpen)
            {
                // Open chest
                OpenChest();
            }else{
                // chest is already open
                CheestOpened();
            }
        }
    }

    public void OpenChest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // Dialog text = contents text
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // raise the signal to the player to animate 
        raiseItem.Raise();
        // raise the context clue
        context.Raise();
        // set the chest opened
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
    }

    public void CheestOpened()
    {
        // Dialog off
        dialogBox.SetActive(false);
        // raise the signal to the player to stop animating
        raiseItem.Raise();
        playerInRange = false;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen) 
        {
            context.Raise();
            playerInRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }

}
