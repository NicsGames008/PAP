using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //Abre caminho para o icon
    public Image icon;

    //Abre caminho para o butão
    public Button removeButton;
    public GameObject player; 

    //Abre caminho para o item
    Item item;

    //Adiciona o item ao slot
    public void AddItem(Item newItem)
    {
        //Diz q o item daquele slot é o q foi apanhado
        item = newItem;

        //faz o sprit do slot tomara o valor do sprite do item
        icon.sprite = item.icon;
        //E o spiret do slot visivel
        icon.enabled = true;

        //faz com q o butão de remover do inventario possa ser visivel
        removeButton.interactable = true;
    }

    //Da clear ao slot
    public void ClearSlot()
    {
        //Diz q o item esta sem nada
        item = null;

        //Faz o sprite n ser visivel e n tem nada la dentro
        icon.sprite = null;
        icon.enabled = false;

        //Faz com q o butão de remover fique invisivel
        removeButton.interactable = false;
    }


    //Remove do inevtario
    public void OnRemoveButton()
    {
        //sabe qual a possiçaó do item
        Vector3 itemNewPosition = new Vector3();

        itemNewPosition.x = player.transform.position.x;
        itemNewPosition.y = (float)0.63;
        itemNewPosition.z = player.transform.position.z + (float)1;

        //troca a possição antica pela nova
        item.gameObject.transform.position = itemNewPosition;

        //faz o item re aparecer
        item.gameObject.SetActive(true);

        //Quando chamado, chama o metedo do iventario e diz para remover X item
        Inventory.instance.Remove(item);
    }

    //Quando o utilizador carrega apra usar o itme este metedo é ativado
    public void OnUseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
