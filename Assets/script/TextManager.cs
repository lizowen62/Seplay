using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public int i;
    public TextMeshProUGUI m_Text;

    public static Data data;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.Lang == 2 && i == 1)
        {
            gameObject.GetComponent<UnityEngine.UI.Text>().text = " this is a demo ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 2)
        {
            if (Data.Lang == 2)
            {
                gameObject.GetComponent<UnityEngine.UI.Text>().text = " Difficulty ";
            }
            else if (Data.Lang == 1)
            {
                gameObject.GetComponent<UnityEngine.UI.Text>().text = " Difficulté ";
            }
        }
        if (i == 3)
        {
            if (Data.Lang == 2)
            {
                m_Text.text = "if you find this exercise too easy you can start in other difficulty";
            }
        }

        if (i == 4)
        {
            if (Data.Lang == 2)
            {
                m_Text.text = "you did it in : ";
            }
        }

        if (i == 5)
        {
            if (Data.Lang == 2)
            {
                gameObject.GetComponent<UnityEngine.UI.Text>().text = " test your running memory ";
            }
        }
        if (i == 6)
        {
            if (Data.Lang == 2)
            {
                m_Text.text = "The goal of this game is, according to the instruction announced at the bottom of the screen, to build the shape indicated in the right direction:" + "\n" +  "- Select with the arrows on the side the right puzzle piece, in case of doubt click on the magnifying glass icon to zoom on it." + "\n" +  "-Validate your choice by clicking on it you can cancel your last choice at any time, a visual of your choices is available in the top left corner.";
            }
        }
        if (i == 8)
        {
            if (Data.Lang == 2)
            {
                m_Text.text = "Start Game";
            }
        }
        if (i == 9)
        {
            if (Data.Lang == 2)
            {
                m_Text.text = "Restart";
            }
        }
    }

    }
