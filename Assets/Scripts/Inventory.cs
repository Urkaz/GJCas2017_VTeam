using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    public enum Items
    {
        NONE,
        CargoKey,
        SteamKey,
        Pipe1,
        Pipe2,
        Pipe3
    };

    //inventory has the id of object
    public List<Items> inventory = new List<Items>();
    

    //Add id of object
    public void addObject(Items item)
    {
        inventory.Add(item);
    }
    
    //Remove id of object
    public void removeObject(Items item)
    {
        inventory.Remove(item);
    }

    //Search for object, if found return true if not false
    public bool findObject(Items item)
    {
        return inventory.IndexOf(item) > -1 ? true : false;
    }

    /*public bool ContainsKeyDoor()
    {
        return inventory.Contains(Items.CargoKey);
    }*/

    public bool Contains(Items item)
    {
         return inventory.Contains(item);
    }

    public void ResetInventory() {
        inventory.Clear();
    }
}
