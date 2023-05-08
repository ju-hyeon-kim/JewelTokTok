using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager inst;

    [SerializeField] TMPro.TMP_Text Txt_Score = null;

    private int score;

    private void Awake()
    {
        inst = this;
        score = 0; Txt_Score.text = score.ToString();
    }

    public int Score
    {
        get { return score; }
        set 
        { 
            score = value; 
            Txt_Score.text = score.ToString(); 
        }
    }
}
