using System.Collections;
using UnityEngine;

public class userSelect : MonoBehaviour
{
    string url = "http://localhost/API/userSelect.php";
    public string[] userData;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW users = new WWW(url);
        yield return users;
        string userDataString = users.text;
        userData = userDataString.Split(';');

        print(GetValueData(userData[0], "UserName"));
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
