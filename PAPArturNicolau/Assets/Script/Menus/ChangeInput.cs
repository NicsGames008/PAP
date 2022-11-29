using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeInput : MonoBehaviour
{
    EventSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        //quando caregar na tecla tab muda de caixa
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Le qual a proxima caixa
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            
            //Se hover uma caixa para ser selecionada seleciona
            if (next != null)
            {
                next.Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            //Le qual a proxima caixa
            Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();

            //Se hover uma caixa para ser selecionada seleciona
            if (previous != null)
            {
                previous.Select();
            }
        }
    }
}
