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

//����
public class TitleScreen : MonoBehaviour
{
    public TMP_Text Text;
    public GameObject MakeNicknameWindow;
    

    bool isPossibleScreenTouch = false;
    bool isNewUser = true;

    public void LoginSuccess()
    {
        //�ű����������Ǵ�
        GPGSBinder.Inst.LoadCloud("Nickname", (success, data) => isNicknameExist(data));
    }

    void isNicknameExist(string nickname) // �г����� �����ϴ°�?
    {
        if (nickname != "") //�г����� �����Ѵٸ�
        {
            isNewUser = false; //�ű������� �ƴ�
        }
        Text.text = "ȭ���� ��ġ�ϼ���.";
        isPossibleScreenTouch = true;
    }

    public void ScreenTouch() //OnClick
    {
        if(isPossibleScreenTouch)//�α��ο� �����Ͽ��ٸ�
        {
            if (isNewUser) //�ű� ������� �г��� �����
            {
                MakeNickname();
            }
            else // �ű������� �ƴ϶�� ����ȭ�� ����
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
