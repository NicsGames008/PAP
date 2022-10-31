using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class userInsert : MonoBehaviour
{
    //Guarda o local da API
    string url = "http://localhost/API/userInsert.php";
    //Recebe os valores das caixas
    public TMP_InputField insertUsername, insertPassword, insertEmail, confirmPassword;

    //AddUserDB(insertUsername.text, insertEmail.text, insertPassword.text);

    public void AddUser()
    {
        //sabe se as infos estam certas
        bool valEmail, valPass;

        #region Email
        //Valida de o email esta de acordo com o pedido
        if (ValidateEmail(insertEmail.text))
        {
            valEmail = true;
            print("email passou");
        }
        else
        //print("email erro"); 
        #endregion

        #region PassWord
        //Valida de o email esta de acordo com o pedido
        if (ValidatePassword(insertPassword.text))
        {
            valPass = true;
            print("pass passou");
        }
        else
            print("pass erro"); 
        #endregion
    }

    #region Adiciona a BD
    //Adiciona as infos a BD
    public void AddUserDB(string username, string email, string password)
    {
        //Var que vair ter os POST's para a API
        WWWForm form = new WWWForm();

        //da os valores aos post's da API
        form.AddField("addUsername", username);
        form.AddField("addEmail", email);
        form.AddField("addPassword", password);

        //Chama a APi, e executas as coisas
        WWW www = new WWW(url, form);
    }
    #endregion

    #region Email
    // Valida se o nome esta certo
    public bool ValidateEmail(string email)
    {
        //Verifica se exete o limite e é null
        if (email.Length == 1 || !email.Contains("@") && !email.Contains(".com") || !email.Contains(".pt"))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    public bool ValidatePassword(string Password)
    {
        print(Password.Length);
         
        if (String.IsNullOrEmpty(Password))
        {
            return false;
        }

        return true;
    }








    #region Palavra Passe
    // Valida se a palavra passe esta certo
    public static bool ValidarPassWord(string PassWord)
    {
        //Verifica se exete o limite e é null
        if (PassWord.Length > 25 && String.IsNullOrEmpty(PassWord))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion
}
