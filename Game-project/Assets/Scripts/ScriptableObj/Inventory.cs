using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int nunmberOfKeys;

    public void AddItem(Item itemToAdd)
    {
        // Is the item a key
        if(itemToAdd.isKey)
        {
            nunmberOfKeys++;
        }else{
            if(!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }

}
