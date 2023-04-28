using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ÁÖÇö
public class MainManager : MonoBehaviour
{
    public void StartButton() // OnClick
    {
        SceneManager.LoadScene("Play");
    }
}
