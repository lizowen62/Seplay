using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject parent;
    public GameObject cible;
    public GameObject management;
    public GameObject panel;
    public GameObject help;
    public GameObject zoom;
    public Image panelle;

    public void Cancel()
    {
        string result = "";

        if (parent.GetComponent<send>().selected.Count != 0 && management.GetComponent<SolutionHandler>().combination.Count != 0)
        {
            parent.GetComponent<send>().selected.RemoveAt(parent.GetComponent<send>().selected.Count - 1);
            parent.gameObject.GetComponent<send>().num -= 1;
            management.GetComponent<SolutionHandler>().combination.RemoveAt(management.GetComponent<SolutionHandler>().combination.Count - 1);
        }
    }

    public void Before ()
    {
        parent.GetComponent<send>().previous();
    }

    public void Next()
    {
        parent.GetComponent<send>().next();
    }

    public void ZoomIn()
    {
        Sprite zooming = parent.GetComponent<send>().tmp;
        StartCoroutine("FadeIn");
        zoom.GetComponent<Image>().overrideSprite = zooming;
        panel.SetActive(true);
    }

    public void Displayhelp()
    {
        help.SetActive(true);
    }

    public void Hidehelp()
    {
        help.SetActive(false);
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = panelle.GetComponent<Image>().color;
            c.a = f;
            panelle.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
