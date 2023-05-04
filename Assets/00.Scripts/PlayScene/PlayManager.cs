using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (�ڿ���) �÷��̽��۽� board ���� �� ����.
public class PlayManager : MonoBehaviour
{
    // �ʿ� ���۳�Ʈ
    public Transform tr_Tiles; // block ������Ʈ ��Ƶ� �θ� Ʈ������.
    public GameObject tile; // block ������.
    public GameObject[,] tiles; // ��� block�� list
    public List<Sprite> characters = new List<Sprite>();
    // ���� ũ�� ����x���� (8x8)
    [SerializeField] int width = 8;
    [SerializeField] int height = 8;

    public static PlayManager inst = null;

    public bool IsSliding { get; set; }

    void Start()
    {
        inst = GetComponent<PlayManager>();

        MakeBoard();
    }

    void MakeBoard() // ���� ����� -> ���� ó��: ó�� ������� �����ǿ��� '����!'�� �־�� �ȵ�
    {
        tiles = new GameObject[width, height];

        //����
        float Interval = 0.625f;

        Sprite[] previousLeft = new Sprite[height]; // ���� line block ( �ٷ� ���� ��� )
        Sprite previousBelow = null; // ���� block ( �ٷ� ���� ��� )

        for (int w = 0; w < width; w++)
        {
            for(int h  = 0; h < height; h++)
            {
                GameObject newTile = Instantiate(tile, tr_Tiles);
                tiles[w, h] = newTile;
                newTile.transform.position += new Vector3(w * Interval, h * Interval, 0);

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(characters);
                possibleCharacters.Remove(previousLeft[h]); // ù ���� null, �� ��° �ٺ��� check
                possibleCharacters.Remove(previousBelow); // ���� block Ȯ��.

                // ���� sprite ������
                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[h] = newSprite;
                previousBelow = newSprite;
            }
        }
    }

    public IEnumerator FindEmptyTiles()
    {
        for(int w = 0; w < width; w++)
            for(int h = 0; h < height; h++)
                if (tiles[w, h].GetComponent<SpriteRenderer>().sprite == null)
                {
                    yield return StartCoroutine(SlideDownTiles(w, h));
                    break;
                }
        yield return new WaitForSeconds(0.3f);
        for (int w = 0; w < width; w++) // Ÿ�ϵ� ���������� �ٽ� match�Ǵ°� �ֳ� Ȯ��.
            for (int h = 0; h < height; h++)
                tiles[w, h].GetComponent<Tile>().ClearAllMatches();
        
    }
    private IEnumerator SlideDownTiles(int _w, int _hStart, float slideDelay = 0.05f)
    {
        IsSliding = true;
        List<SpriteRenderer> renders = new List<SpriteRenderer>();
        int emptyCount = 0;

        for(int h = _hStart; h < height; h++)
        {
            SpriteRenderer render = tiles[_w, h].GetComponent<SpriteRenderer>();
            if (render.sprite == null)
                emptyCount++;
            renders.Add(render);
        }

        for(int i = 0; i < emptyCount; i++)
        {
            yield return new WaitForSeconds(slideDelay);
            for(int j = 0; j < renders.Count - 1; j++)
            {
                renders[j].sprite = renders[j + 1].sprite;
                renders[j + 1].sprite = GetNewSprite();

                if (j == renders.Count - 1)
                    renders[j + 1].sprite = GetNewSprite();
            }
        }
        IsSliding = false;
    }
    //private Sprite GetNewSprite(int _w, int _h)
    //{
    //    List<Sprite> newSprites = new List<Sprite>();
    //    newSprites.AddRange(characters);

    //    if(_w > 0)
    //}
    private Sprite GetNewSprite()
    {
        List<Sprite> newSprites = new List<Sprite>();
        newSprites.AddRange(characters);

        return newSprites[Random.Range(0, newSprites.Count)];
    }
}
