using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;
using graphQLClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExampleQuery : MonoBehaviour
{

    public string querystring;
    private string scene;
    public GameObject _self;
    public static Data data;
    public UnityEngine.UI.Text display;

    void Awake()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        GraphQuery.url = "https://seplay-api.azurewebsites.net/graphql/";
    }


    public void AddTime()
    {
        //GraphQuery.onQueryComplete += DisplayResult;
        if (Data.ok == 1)
        {
            var tim = (double)Data.counter;
            var tom = tim.ToString();
            var str = tom.Replace(",", ".");
            var tmp = System.DateTime.Now;
            Debug.Log(tmp.ToString());
            GraphQuery.variable["date"] = tmp.ToString("yyyy-MM-dd\\THH:mm:ss\\Z"); ;
            GraphQuery.variable["difficulty"] = Data.difficulty;
            GraphQuery.variable["shape"] = Data.forme;
            GraphQuery.variable["completionTime"] = str;
            GraphQuery.POST(querystring);
        }
    }

    string ParseData(string query, string queryName)
    {
        JObject obj = JsonConvert.DeserializeObject<JObject>(query);
        return JsonConvert.SerializeObject(obj["data"][queryName]);
    }
}
