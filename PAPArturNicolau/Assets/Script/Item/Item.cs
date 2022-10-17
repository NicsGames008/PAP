using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//"Blueprint" para todos os items
[CreateAssetMenu(fileName = "New Item",menuName = "Invetory/Item")]
public class Item : ScriptableObject
{
    //Nome do item
    new public string name = "New Name";
    //Icon do item
    public Sprite icon = null;
    //Sabe se é default
    public bool isDefaulItem = false;
}
