using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager inst;
    private Animator myAnim = null;

    [SerializeField] TMPro.TMP_Text Txt_Score = null;
    [SerializeField] TMPro.TMP_Text Txt_Timer = null;
    [SerializeField] TMPro.TMP_Text Txt_AddTimer = null;

    private int score;

    public float maxTimer;
    private float curTimer;
    private float addTimer;
    private string AddTime = "AddTime";
    private bool isEnoughTime = true;

    private void Awake()
    {
        inst = this;
        myAnim = GetComponent<Animator>();
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
    public void AddTimer(float _sec)
    {
        addTimer = _sec;
        Txt_AddTimer.text = "+" + addTimer.ToString() + " sec";
        myAnim.SetTrigger(AddTime);
    }
}
