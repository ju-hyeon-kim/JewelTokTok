using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NicknameDataRemove : MonoBehaviour
{
    public TMP_Text Text;

    public void RemoveButton() //onclick
    {
        GPGSBinder.Inst.DeleteCloud("Nickname", success => SuccessRemove()); // �г��� ����Ÿ ����
    }

    void SuccessRemove() //������ �����ϸ�
    {
        //��ư�� "�г��� ���� �Ϸ�" �ؽ�Ʈ ǥ��
        Text.text = "�г��� ���� �Ϸ�";
    }
}
