using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // recebe os valores do item
    public Item item;

    //verifica se ouve alguma interação com os colliders
    private void OnTriggerEnter(Collider other)
    {
        //verifica se foi com o collider do player que interagio
        if (other.gameObject.layer == 3)
        {
            //manda mensaguem para a consola
            Debug.Log("Apanhaste o Item " + item.name);

            //Adiciona ao iventario
            bool wasPickUp = Inventory.instance.Add(item);

            //SE foi apanhado destroi o msm
            if (wasPickUp)
            {
                item.gameObject = gameObject;

                gameObject.SetActive(false);
            }



        }
    }
}
