using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icone : MonoBehaviour
{
    public static Data data;
    public Sprite[] sprites;
    private Image myIMGcomponent;

    void Start()
    {
        myIMGcomponent = this.GetComponent<Image>();
        if ( Data.forme == "cercle")
            myIMGcomponent.sprite = sprites[2];
        if (Data.forme == "carrée")
            myIMGcomponent.sprite = sprites[0];
        if (Data.forme == "triangle")
            myIMGcomponent.sprite = sprites[1];
    }
}
