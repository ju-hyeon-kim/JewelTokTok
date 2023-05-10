using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// (박영준) 플레이시 아이템버튼 UI 스크립트
public class PlayableItem : MonoBehaviour
{
    private Color selectColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);

    [SerializeField] GameObject go_RanibowSelect;
    [SerializeField] UnityEngine.UI.Image img_RainbowBomb;
    [SerializeField] UnityEngine.UI.Image img_StopWatch;

    bool isUsedRainbowBomb = false; // 'RainbowBomb' 아이템을 사용했는지 여부 bool값
    bool isUsedStopWatch = false; // 'StopWatch' 아이템을 사용했는지 여부 bool값
 
    public void Btn_RainbowBomb()
    {
        go_RanibowSelect.SetActive(true);
    }
    public void Btn_SelectRainbow(int _tileNum)
    {
        PlayManager.inst.RainbowBombItem(_tileNum);
        img_RainbowBomb.color = selectColor;
    }
    public void Btn_StopWatch()
    {
        GUIManager.inst.isStopWatch = true;
        img_StopWatch.color = selectColor;
    }
}
