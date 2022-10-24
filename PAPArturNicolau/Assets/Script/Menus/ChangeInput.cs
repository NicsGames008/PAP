using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeInput : MonoBehaviour
{
    EventSystem system;
    public Selectable firstInput;

    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
        firstInput.Select();
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

    }
}
