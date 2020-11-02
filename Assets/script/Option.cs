using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Slider sliderval;
    public int difficulty;
    public int Lang;
    public static Data data;
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         difficulty = (int)sliderval.value;
        if (difficulty < 1)
        {
            m_Text.text = "Facile";
            if (Data.Lang == 2)
                m_Text.text = "Easy";
        } else
        {
            m_Text.text = "Normale";
            if (Data.Lang == 2)
                m_Text.text = "Normal";

        }
        if (difficulty == 2 )
        {
            m_Text.text = "Difficile";
            if (Data.Lang == 2)
                m_Text.text = "Hard";
        }

         Data.difficulty = difficulty;
         Data.Lang = Lang;
    }

    public void getLangFR()
    {
        Lang = 1;
    }

    public void getLangENG()
    {
       Lang = 2;
    }
}
