using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class send : MonoBehaviour
{
    public static Data data;
    private int Limit;
    public int Base= 0 ;
    public Sprite[] sprites;
    public int num = 0;
    public Sprite tmp;
    public GameObject manager;
    public ArrayList selected = new ArrayList();
    public int Rand;
    public int Current;
    private bool isRotating = false;
    public bool clicked;
    SpriteRenderer rend;

    void Start()
    {
        diff();
        Current = Random.Range(Base, Limit-1);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Current];
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
        gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
        StartCoroutine("FadeIn");
    }

    public void previous()
    {
        Current += 1;
        Debug.Log(Current);
        check();
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Current];
        StartCoroutine("FadeIn");
    }

    public void diff()
    {
        if (Data.difficulty <= 1)
        {
            Limit = 3;
        }
        else
        {
            Limit = 6;
        }
    }

    public void next()
    {
        Current -= 1;
        Debug.Log(Current);
        check();
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Current];
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        for (float f= 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void check ()
    {
        if ( Current >= sprites.Length )
        {
            Current = Base;
        } else if ( Current < Base )
        {
            Current = Base+Limit-1;
        }
    }


    void Update()
    {
        if (selected.Contains(Current))
        {
            GetComponent<SpriteRenderer>().material.color = new Color(0f, 0f, 0f, 0.5f);
        }
        tmp = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
