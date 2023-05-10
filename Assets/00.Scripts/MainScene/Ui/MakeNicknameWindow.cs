using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MakeNicknameWindow : MonoBehaviour
{
    public TMP_InputField InputField;
    public NoticeWindow NoticeWindow;

    public GameObject TitleScreen;

    string reason = "";

    public void SellectButton() //onclick
    {
        //확인 버튼을 누르면
        if (isPossibleName()) // 닉네임이 규칙에 맞는지 검사
        {
            //해당 닉네임으로 결정할지 물어봄
            NoticeWindow.WindowSetting("해당 닉네임으로 결정하시겠습니까?",false , SaveNickname);
        }
        else
        {
            //규칙에 맞지 않는다고 알려줌
            NoticeWindow.WindowSetting(reason, true);
            reason = "";
        }
        NoticeWindow.gameObject.SetActive(true);
    }

    bool isPossibleName() 
    {
        string Name = InputField.text;

        if(Name == "")   //빈 텍스트인지 확인
        {
            reason = "텍스트를 입력하지 않았습니다. 다시 입력하여 주세요.";
            return false;
        }
        else if(Name.Length > 8) // 8자리를 넘는지 확인
        {
            reason = "닉네임 길이가 8자리를 넘었습니다. 다시 일력하여 주세요.";
            return false;
        }
        else if(!Regex.IsMatch(Name, "^[0-9a-zA-Z가-힣]*$")) // 한글, 영어, 숫자만 입력 가능
        {
            reason = "닉네임은 한글, 영어, 숫자로만 지을 수 있습니다.. 다시 일력하여 주세요.";
            return false;
        }
        return true;
    }

    void SaveNickname()
    {
        //클라우드 저장
        GPGSBinder.Inst.SaveCloud("Nickname", InputField.text, success => SuccessSaveNickname());
    }

    void SuccessSaveNickname()
    {
        NoticeWindow.WindowSetting("닉네임 저장이 완료되었습니다.", true, OffScreens);
    }

    void OffScreens()
    {
        TitleScreen.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
