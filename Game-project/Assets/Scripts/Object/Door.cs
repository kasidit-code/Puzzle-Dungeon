using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    button
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                //Does player have a key ?
                if(playerInventory.nunmberOfKeys > 0)
                {
                    //remove a player key
                    playerInventory.nunmberOfKeys --;
                    //If so, then call open
                    Open();
                }
            }
        }
    }
    public void Open()
    {
        //Turn off the door's sprite renderer
        doorSprite.enabled = false;
        //set open to true
        open = true;
        //turn off the door's box collider
        physicsCollider.enabled = false;
    }

    public void Close()
    {

    }
}
