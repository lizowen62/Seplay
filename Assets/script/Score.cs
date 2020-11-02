using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Data data;
    public TextMeshProUGUI m_text;

    // Start is called before the first frame update
    void Start()
    {
        int d = (int)(Data.counter * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        string tmp = String.Format("{0:00}:{1:00}", minutes, seconds);
        m_text.text = tmp + " secondes";
    }

    public void reboot()
    {
        Data.difficulty += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void to_menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
