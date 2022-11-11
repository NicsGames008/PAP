using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class userSelect : MonoBehaviour
{
    //Guarda o dominio da API
    string url = "http://localhost/API/userSelect.php";
    //Lista que guarda todos os valores da API
    public string[] userData;
    //Caixa de email e passaword que o utilizador pos
    public TMP_InputField insertPassword, insertEmail;
    public GameObject background, errorUser, errorPassword;

    private void Start()
    {
        StartCoroutine(test());
    }


    private void Update()
    {
        //le mais uma vez a data na API
        StartCoroutine(test());
    }

    //Le toda a data na API
    IEnumerator test()
    {
        //Executa a API
        WWW users = new WWW(url);
        yield return users;
        //recebe todos os dados
        string userDataString = users.text;
        //Guarda na lista
        userData = userDataString.Split(';');
    }


    //Metedo chamado quando o utilizador carrega no butão
    public void Login()
    {


        //tira 1 valor ao tamanhao do arrai para bater certo
        int index = userData.Length - 1;

        //passa por todo o tamanho do array para...
        for (int i = 0; i < index; i++)
        {
            //ver se ha algum email com o input que o utilizador pos
            if (GetValueData(userData[i], "email:") == insertEmail.text)
            {
                //e ve se a passe esta certa
                if (GetValueData(userData[i], "password:") == insertPassword.text)
                {
                    //passa para a proxima fasse e acaba com a procura
                    print("passou");
                    errorUser.SetActive(false);
                    errorPassword.SetActive(false);
                    OperServerSelect();
                    return;
                }
                //se a passe n estiver certa acaba com a procura e manda um mnsg de erro
                else
                {
                    errorPassword.SetActive(true);
                    print("pass n esta certa");
                    return;
                }
            }
        }
        //Se nada foi encontrado manda uma mensaguem de erro
        print("não ha conta");
        errorUser.SetActive(true);
    }



    //Pega um valor especifico da API
    string GetValueData(string data, string index)
    {
        //Le o index pedido quando é chamado o metedo e vai ler ate onde etsa o index pedido
        string value = data.Substring(data.IndexOf(index) + index.Length);
        //retira o trço de difição adicionada na API
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        //devolve o valor singular
        return value;
    }


    //Muda de janela
    public void OperServerSelect()
    {
        background.transform.LeanMoveLocal(new Vector3(0, 0, 0), 0.7f).setEaseInBack().setIgnoreTimeScale(true);
    }
}
