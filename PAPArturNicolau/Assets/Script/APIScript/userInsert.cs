using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class userInsert : MonoBehaviour
{
    string url = "http://localhost/API/userInsert.php";
    public TextMeshProUGUI insertUsername, insertPassword, insertEmail;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per framea
    void Update()
    {

    }

    public void AddUser()
    {
        string ajuda = insertUsername.text;

        Debug.Log(ajuda);
        //AddUser(insertUsername.GetComponent<Text>().text, insertEmail.GetComponent<Text>().text, insertPassword.GetComponent<Text>().text);
    }

    public void AddUserDB(string username, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("addUsername", username);
        form.AddField("addEmail", email);
        form.AddField("addPassword", password);

        WWW www = new WWW(url, form);
    }
}
