using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class SolutionHandler : MonoBehaviour
{
    public static Data data;
    public Sprite[] square;
    public Sprite[] circle;
    public Sprite[] triangle;
    public GameObject[] childs;
    public List<int> combination  = new List<int>();
    public int difficulty;
    bool match;

    public TextMeshProUGUI m_Text;
    private float time_counter;
    private string form;
    private string way;
    private string formENG;
    private string wayENG;
    public int TYPE;
    public GameObject panel;
    public GameObject child;
    public List<int> solution = new List<int>();

    void Start()
    {
        int i = 0;
        TYPE = Random.Range(0, 3);
        switch (TYPE)
        {
            case 0:
                form = "triangle";
                formENG = "triangle";
                child.GetComponent<send>().sprites = triangle;
                break;
            case 1:
                form = "carrée";
                formENG = "square";
                child.GetComponent<send>().sprites = square;
                break;
            case 2:
                form = "cercle";
                formENG = "circle";
                child.GetComponent<send>().sprites = circle;
                break;
            case 3:
                form = "cercle";
                formENG = "circle";
                child.GetComponent<send>().sprites = circle;
                break;
        }
        generate(form);
        if (Data.Lang == 1 || Data.Lang == 0 )
        {
            m_Text.text = "Veuillez former un " + form + " de " + way;
            Data.forme = form;
        } else if (Data.Lang == 2)
        {
            m_Text.text = "please form a " + formENG + " from " + wayENG;
            Data.forme = "carré";
        }
        foreach (var human in solution)
        {
            Debug.Log(human);
        }
    }

    void feedback(int tmp)
    {
        if (Data.difficulty <= 1)
        {
            
        }

    }

    bool verify()
    {
        if (solution.Count == combination.Count)
        {
            foreach (int item in solution)
            {
                if (combination.Contains(item))
                {
                    Debug.Log("you pass");
                }
                else
                {
                    return false;
                }
                return true;
            }
        }
        return false;
    }

    void generate(string forme)
    {
        var Rand = Random.Range(0, 2);
        switch (Rand)
        {
            case 0:
                way = "droite à gauche";
                wayENG = "right to left";
                solution.Add(0);
                solution.Add(1);
                solution.Add(2);
                child.GetComponent<send>().Base = 0;
                break;
            case 1:
                way = "gauche à droite";
                wayENG = "left to right";
                solution.Add(3);
                solution.Add(4);
                solution.Add(5);
                child.GetComponent<send>().Base = 0;
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Data.counter += Time.deltaTime;
        if (verify())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
