using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    //Associa ao Inventario
    Inventory inventory;

    //Guarda todos os slots no Vertice
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        
        inventory = Inventory.instance;


        //Quando o iventario muda muda o ui junto
        inventory.onItemChangecallback += UpdateUI;

        //Pega em todos os slots do iventario e guarda no array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        //passa por todos os slots
        for (int i = 0; i < slots.Length; i++)
        {
            //Se tiver algo adiciona o item ao slot
            if (i < inventory.items.Count)
            {
                //Adiciona o item ao slot
                slots[i].AddItem(inventory.items[i]);
            }
            //Sesão apaga o item do slot
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
