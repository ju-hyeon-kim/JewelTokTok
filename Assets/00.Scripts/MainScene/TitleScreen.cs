using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject MakeNicknameWindow;

    public void ScreenTouch() //OnClick
    {
        if (isNewUser()) //신규 유저라면 닉네임 만들기
        {
            MakeNickname();
        }
        else // 신규유저가 아니라면 메인화면 띄우기
        {
            this.gameObject.SetActive(false);
        }
    }

    bool isNewUser()
    {
        return false;
    }

    void MakeNickname()
    {
        MakeNicknameWindow.SetActive(true);
    }
}
