using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject MakeNicknameWindow;

    public void ScreenTouch() //OnClick
    {
        if (isNewUser()) //�ű� ������� �г��� �����
        {
            MakeNickname();
        }
        else // �ű������� �ƴ϶�� ����ȭ�� ����
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
