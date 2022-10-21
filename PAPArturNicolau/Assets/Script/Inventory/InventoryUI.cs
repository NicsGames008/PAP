using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    //Associa ao Inventario
    Inventory inventory;

    public GameObject inventoryUI;

    public Transform cam;

    //Guarda todos os slots no Vertice
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {


        inventory = Inventory.instance;

        //Faz com que o inventarios fique inveivel loco de inicio
        //inventoryUI.SetActive(!inventoryUI.activeSelf);

        //Quando o iventario muda muda o ui junto
        inventory.onItemChangecallback += UpdateUI;

        //Pega em todos os slots do iventario e guarda no array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //Quando o utilizador carregar na tecla responsavel por abrir o iventario...
        if (Input.GetButtonDown("Inventory"))
        {
            //Ve se o rato esta preso no meu do ecra
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            //Torna o rato invisivel ou visivel, depende de como estava antes
            Cursor.visible = !Cursor.visible;

            //Mostra o canvas do msm
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }


        Vector3 newcampositon = new Vector3(cam.position.x, cam.position.y, cam.position.z);

        cam.position = new Vector3(0,1,0); ;

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
