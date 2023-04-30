using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (박영준) Tile 클릭 시 이벤트 발생 스크립트.
public class Tile : MonoBehaviour
{
    private static Color selectColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    private static Tile previousTile = null;

    SpriteRenderer render;
    Collider2D myColider;
    bool isSelect = false;

    private Vector2[] adjacentDir = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private bool matchFound = false;


    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        myColider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        if (render.sprite == null || PlayManager.inst.IsShifting)
            return;

        if (isSelect)
            Deselect();
        else
        {
            if (previousTile == null) // 첫 클릭
                Select();
            else
            {
                Debug.Log(previousTile.gameObject);
                // 4방향 인접 오브젝트 중 지금 클릭중인 오브젝트가 있을 경우 실행.
                if (GetAllAdjcentTiles().Contains(previousTile.gameObject))
                {
                    Debug.Log("hi");
                    SwapSprite(previousTile.render);
                    previousTile.Deselect();
                }
                else // 아닐 경우
                {
                    previousTile.GetComponent<Tile>().Deselect(); // 전 클릭 취소
                    Select(); // 현재 클릭 활성화.
                }

            }
        }
    }

    private void Select()
    {
        isSelect = true;
        render.color = selectColor;
        previousTile = gameObject.GetComponent<Tile>();
    }
    void Deselect()
    {
        isSelect = false;
        render.color = Color.white;
        previousTile = null;
    }

    public void SwapSprite(SpriteRenderer _render)
    {
        if (render.sprite == _render.sprite) // 고른 sprite와 옮긴 sprite가 같을 경우 return
            return;

        Sprite tempSprite = _render.sprite;
        _render.sprite = render.sprite;
        render.sprite = tempSprite;
    }

    private GameObject GetAdjcent(Vector2 _dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _dir);
        if (hit.collider != null)
        {
            return hit.collider.gameObject; // 탐색 오브젝트가 있을 경우 해당 gameobject return
        }


        return null; // 아무것도 탐색 못할 시에는 null return
    }
    private List<GameObject> GetAllAdjcentTiles()
    {
        List<GameObject> adjcentTiles = new List<GameObject>();
        myColider.enabled = false;
        for (int i = 0; i < adjacentDir.Length; i++)
            adjcentTiles.Add(GetAdjcent(adjacentDir[i])); // U,D,L,R 4방향 인접 오브젝트 체크

        myColider.enabled = true;
        return adjcentTiles;
    }
}
