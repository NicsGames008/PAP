using System.Collections;
using UnityEngine;

public class userSelect : MonoBehaviour
{
    //Guarda o dominio da API
    string url = "http://localhost/API/userSelect.php";
    //Lista que guarda todos os valores da API
    public string[] userData;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Executa a API
        WWW users = new WWW(url);
        yield return users;
        //recebe todos os dados
        string userDataString = users.text;
        //Guarda na lista
        userData = userDataString.Split(';');


        //print(GetValueData(userData[1], "password:"));
    }

    string GetValueData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }
}
