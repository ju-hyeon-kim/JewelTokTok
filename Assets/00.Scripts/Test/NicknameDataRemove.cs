using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NicknameDataRemove : MonoBehaviour
{
    public TMP_Text Text;

    public void RemoveButton() //onclick
    {
        GPGSBinder.Inst.DeleteCloud("Nickname", success => SuccessRemove()); // 닉네임 데이타 삭제
    }

    void SuccessRemove() //삭제에 성공하면
    {
        //버튼에 "닉네임 삭제 완료" 텍스트 표시
        Text.text = "닉네임 삭제 완료";
    }
}
