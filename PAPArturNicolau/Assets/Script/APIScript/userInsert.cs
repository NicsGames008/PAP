using System;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class userInsert : MonoBehaviour
{
    //Guarda o local da API
    string url = "http://localhost/API/userInsert.php";
    //Recebe os valores das caixas
    public TMP_InputField insertUsername, insertPassword, insertEmail, confirmPassword;
    public GameObject background, erroUser, erroPass, erroConfPass, erroEmail, passDiferente;


    public void AddUser()
    {
        //sabe se as infos estam certas
        bool valUsername = false, valEmail = false, valPass = false;

        #region Username
        if (ValidateUsername(insertUsername.text))
        {
            valUsername = true;
            print("Username passou");
            erroUser.SetActive(false);
        }
        else
        {
            print("Username erro");
            erroUser.SetActive(true);
        }
        #endregion

        #region Email
        //Valida de o email esta de acordo com o pedido
        if (ValidateEmail(insertEmail.text))
        {
            valEmail = true;
            print("email passou");
            erroEmail.SetActive(false);

        }
        else
        {
            print("email erro");
            erroEmail.SetActive(true);
        }
        #endregion

        #region PassWord
        //Valida de o email esta de acordo com o pedido
        if (ValidatePassword(insertPassword.text))
        {
            //valida se o confirmar a pass
            if (ValidatePassword(confirmPassword.text))
            {
                //escoal a mensg de erro
                erroConfPass.SetActive(false);
                //Ve se a pass e cofirmar pass são iguais
                if (confirmPassword.text == insertPassword.text)
                {
                    //se tudo estiver certo passa
                    valPass = true;
                    print("pass passou");
                    passDiferente.SetActive(false);
                }
                //se for diferente manda uma mnsg de erro
                else
                    passDiferente.SetActive(true);
            }
            //SE não manda uma mesng de erro
            else
                erroConfPass.SetActive(true);
        }
        //SE nãoi der manda uma msng de erro
        else
        {
            print("pass erro");
            erroPass.SetActive(true);
        }
        #endregion

        //ve se esta tudo certo, se sim manda tudo para a BD
        if (valEmail && valPass && valUsername)
        {
            AddUserDB(insertUsername.text, insertEmail.text, insertPassword.text);
            BackLogin();
        }
    }

    //Metedo que muda de ecrã
    public void BackLogin()
    {
        background.transform.LeanMoveLocal(new Vector3(800, 0, 0), 0.7f).setEaseInBack().setIgnoreTimeScale(true);
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

    #region Username
    // Valida se o nome esta certo
    public bool ValidateUsername(string username)
    {
        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(username))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    #region Email
    // Valida se o nome esta certo
    public bool ValidateEmail(string email)
    {
        //Ve se tem o que é preciso
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(email) || !emailRegex.IsMatch(email))
        {
            //Retorna um Erro
            return false;
        }

        //Se estver tudo certo deica passar
        return true;
    }
    #endregion

    #region Palavra Passe
    // Valida se a palavra passe esta certo
    public bool ValidatePassword(string Password)
    {
        //Verifica se exete o limite e é null
        if (String.IsNullOrEmpty(Password) || Password.Length > 25)
        {
            //Retorna um Erro
            return false;
        }
        //Se estver tudo certo deica passar
        return true;
    }
    #endregion
}
