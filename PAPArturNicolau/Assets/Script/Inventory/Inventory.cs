using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Syngleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Mais de uma instaces do inventario encontrado");
            return;
        }
        instance = this;
    }
    #endregion

    //sabe quando ouve alguma mudança no iventario
    public delegate void OnItemChange();
    public OnItemChange onItemChangecallback;

    public GameObject player;

    //Lista de todos os items que ha
    public List<Item> items = new List<Item>();

    //espaço maximo do iventario
    public int space = 6;

    //Adiciona o item
    public bool Add(Item item)
    {
        //Ve se n é o difaul
        if (!item.isDefaulItem)
        {
            //Ve se ha espaço para o item
            if (items.Count >= space)
            {
                //se n haver mand uma mensaguem de erro
                Debug.Log("Inventario cheio");
                return false;
            }
            //Se sim adicionao
            items.Add(item);

            //sabe quando ouve alguma mudança no iventario
            if (onItemChangecallback != null)
                onItemChangecallback.Invoke();
        }
        return true;
    }

    //remove o item do iventario
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangecallback != null)
            onItemChangecallback.Invoke();
    }
}
