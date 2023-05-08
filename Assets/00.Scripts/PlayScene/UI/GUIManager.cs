using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager inst;

    [SerializeField] TMPro.TMP_Text Txt_Score = null;
    [SerializeField] TMPro.TMP_Text Txt_Timer = null;

    private int score;

    public float maxTimer;
    private float curTimer;
    private bool isEnoughTime = true;

    private void Awake()
    {
        inst = this;
        score = 0; Txt_Score.text = score.ToString();
        curTimer = maxTimer;
        isEnoughTime = true;
    }
    private void Update()
    {
        if(isEnoughTime)
            TimeAttack();
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
    public float Timer
    {
        get { return curTimer; }
        set
        {
            curTimer = value;
        }
    }

    private void TimeAttack()
    {
        curTimer -= Time.deltaTime;
        Txt_Timer.text = curTimer.ToString("F2");

        if(curTimer <= 0.0f)
        {
            curTimer = 0.0f;
            isEnoughTime = false;
        }
    }
}
