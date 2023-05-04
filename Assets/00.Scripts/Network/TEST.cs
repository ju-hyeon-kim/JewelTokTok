using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public TMP_Text text;

    string log = "";

    public void LoginButton() // onclick
    {
        GPGSBinder.Inst.Login((success, localUser) =>
            log = $"{success}, {localUser.userName}, {localUser.id}, {localUser.state}, {localUser.underage}");
        text.text = log;
    }

    

    /*void OnGUI()
    {
        Vector3 pos = new Vector3 (0, 300, 0);
        GUI.matrix = Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one * 3);

        if (GUILayout.Button("ClearLog"))
            log = "";

        if (GUILayout.Button("Login"))
            GPGSBinder.Inst.Login((success, localUser) =>
            log = $"{success}, {localUser.userName}, {localUser.id}, {localUser.state}, {localUser.underage}");

        if (GUILayout.Button("Logout"))
            GPGSBinder.Inst.Logout();
       
        GUILayout.Label(log);
    }*/
}
