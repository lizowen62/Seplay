using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject manager;
    public GameObject panel;
    public GameObject[] childs;
    private int i = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool verify(int value, List<int> combination)
    {
            foreach (int item in combination)
            {
                if (item == value)
                {
                    return true;
                }
                return false;
            }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
            Debug.Log(hit.collider);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "cible" && hit.collider.gameObject.GetComponent<send>().num < 3)
                {
                    var tmp = hit.collider.gameObject.GetComponent<send>().Current;
                    if (!verify(tmp, manager.GetComponent<SolutionHandler>().combination ))
                    {
                        hit.collider.gameObject.GetComponent<send>().selected.Add(tmp);
                        var count = hit.collider.gameObject.GetComponent<send>().selected.Count;
                        hit.collider.gameObject.GetComponent<send>().num += 1;
                        manager.GetComponent<SolutionHandler>().combination.Add(tmp);
                        childs[count - 1].GetComponent<SpriteRenderer>().sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;
                        panel.SetActive(false);
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(104f, 101f, 101f, 0.5f);
                        i++;
                    }
                }
            }
        }
    }
}
