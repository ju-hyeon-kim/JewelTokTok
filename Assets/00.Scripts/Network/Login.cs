using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Login : MonoBehaviour
{
    public TMP_Text Text;

    public void LoginButton()
    {
        GPGSBinder.Inst.Login((success, localUser) =>
        Text.text = $"{success}, {localUser.userName}, {localUser.id}, {localUser.state}, {localUser.underage}");
    }
}
