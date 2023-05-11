using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

//주현
public class MainManager : MonoBehaviour
{
    public TitleScreen TitleScreen;
    public UserBar UserBar;

    void Awake()
    {
        GoogleLogin();
    }

    void GoogleLogin()
    {
        //GPGSBinder.Inst.Login((success, localUser) => LoginSuccess());
        GPGSBinder.Inst.Login();
        //string s = $"{success}, {localUser.userName}, {localUser.id}, {localUser.state}, {localUser.underage}");
    }

    void LoginSuccess()
    {
        TitleScreen.LoginSuccess();

        //유저바에 닉네임 넘겨주기
        //GPGSBinder.Inst.LoadCloud("Nickname", (success, data) => UserBar.LoginSuccess(data));
    }

    public void StartButton() // OnClick
    {
        SceneManager.LoadScene("Play");
    }
}
