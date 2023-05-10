using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;

//주현
public class TitleScreen : MonoBehaviour
{
    public TMP_Text Text;
    public GameObject MakeNicknameWindow;
    

    bool isPossibleScreenTouch = false;
    bool isNewUser = true;

    public void LoginSuccess()
    {
        //신규유저인지판단
        GPGSBinder.Inst.LoadCloud("Nickname", (success, data) => isNicknameExist(data));
    }

    void isNicknameExist(string nickname) // 닉네임이 존재하는가?
    {
        if (nickname != "") //닉네임이 존재한다면
        {
            isNewUser = false; //신규유저가 아님
        }
        Text.text = "화면을 터치하세요.";
        isPossibleScreenTouch = true;
    }

    public void ScreenTouch() //OnClick
    {
        if(isPossibleScreenTouch)//로그인에 성공하였다면
        {
            if (isNewUser) //신규 유저라면 닉네임 만들기
            {
                MakeNickname();
            }
            else // 신규유저가 아니라면 메인화면 띄우기
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void MakeNickname()
    {
        MakeNicknameWindow.SetActive(true);
    }
}
