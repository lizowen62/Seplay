using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using Boomlagoon.JSON;

public class ConnectApi : MonoBehaviour
{
    private string _username;
    private string _password;
    public static Data data;
    public TMP_InputField v_username;
    public TMP_InputField v_password;
    public TMP_InputField v_passwordvalid;
    public TMP_InputField v_emailvalid;
    public TextMeshProUGUI result;

    void Start()
    {
        //result.enabled = false;
    } 

    public void RegisterOnClick()
    {
        result.SetText("Loading");
        result.enabled = true;
        StartCoroutine(Request("https://seplay-api.azurewebsites.net/api/auth/register", 1));

    }

    public void LoginOnClick()
    {
        result.SetText("Loading");
        StartCoroutine(Request("https://seplay-api.azurewebsites.net/api/auth/login", 0));
    }


    IEnumerator Request(string url, int action)
    {
        _username = v_username.text;
        _password = v_password.text;

        JsonClass jsonForm = new JsonClass();
        jsonForm.username = _username;
        jsonForm.password = _password;
        string jsonStringTrial = JsonUtility.ToJson(jsonForm);
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringTrial);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();
        if (request.responseCode != 200)
        {
            string errorMessage = "";
            switch (request.responseCode)
            {
                case 400:
                    errorMessage = "Login/Password Incorrect";
                    break;
                case 401:
                    errorMessage = "Compte non autorisé";
                    break;
                case 404:
                    errorMessage = "Requête invalide";
                    break;
                case 500:
                    errorMessage = "Internal Server Error";
                    break;
                default:
                    errorMessage = "Default Error";
                    break;
            }
            result.SetText(errorMessage);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            var tmp = request.downloadHandler.text;
            var strArr = tmp.Split('"');
            Data.userId = strArr[7];
            Data.ok = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

