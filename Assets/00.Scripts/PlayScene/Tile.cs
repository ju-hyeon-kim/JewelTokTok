using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (�ڿ���) Tile Ŭ�� �� �̺�Ʈ �߻� ��ũ��Ʈ.
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
            if (previousTile == null) // ù Ŭ��
                Select();
            else
            {
                Debug.Log(previousTile.gameObject);
                // 4���� ���� ������Ʈ �� ���� Ŭ������ ������Ʈ�� ���� ��� ����.
                if (GetAllAdjcentTiles().Contains(previousTile.gameObject))
                {
                    Debug.Log("hi");
                    SwapSprite(previousTile.render);
                    previousTile.Deselect();
                }
                else // �ƴ� ���
                {
                    previousTile.GetComponent<Tile>().Deselect(); // �� Ŭ�� ���
                    Select(); // ���� Ŭ�� Ȱ��ȭ.
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
        if (render.sprite == _render.sprite) // �� sprite�� �ű� sprite�� ���� ��� return
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
            return hit.collider.gameObject; // Ž�� ������Ʈ�� ���� ��� �ش� gameobject return
        }


        return null; // �ƹ��͵� Ž�� ���� �ÿ��� null return
    }
    private List<GameObject> GetAllAdjcentTiles()
    {
        List<GameObject> adjcentTiles = new List<GameObject>();
        myColider.enabled = false;
        for (int i = 0; i < adjacentDir.Length; i++)
            adjcentTiles.Add(GetAdjcent(adjacentDir[i])); // U,D,L,R 4���� ���� ������Ʈ üũ

        myColider.enabled = true;
        return adjcentTiles;
    }
}
