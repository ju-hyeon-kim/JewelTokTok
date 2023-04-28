using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (�ڿ���) �÷��̽��۽� board ���� �� ����.
public class PlayManager : MonoBehaviour
{
    // �ʿ� ���۳�Ʈ
    public Transform Cubes; // block ������Ʈ ��Ƶ� �θ� Ʈ������.
    public GameObject Cube; // block ������.
    Block[,] blocklist = null; // ��� block�� list
    public List<Sprite> characters = new List<Sprite>();
    // ���� ũ�� ����x���� (8x8)
    [SerializeField] int width = 8;
    [SerializeField] int height = 8;

    public static PlayManager inst = null;

    public bool IsShifting { get; set; }

    void Start()
    {
        inst = GetComponent<PlayManager>();

        MakeBoard();
    }

    void MakeBoard() // ���� ����� -> ���� ó��: ó�� ������� �����ǿ��� '����!'�� �־�� �ȵ�
    {
        blocklist = new Block[width, height];
        //����
        float Interval = 0.625f;

        Sprite[] previousLeft = new Sprite[height]; // ���� line block ( �ٷ� ���� ��� )
        Sprite previousBelow = null; // ���� block ( �ٷ� ���� ��� )

        for (int w = 0; w < width; w++)
        {
            for(int h  = 0; h < height; h++)
            {
                GameObject cube = Instantiate(Cube, Cubes);
                cube.transform.position += new Vector3(w * Interval, h * Interval, 0);
                blocklist[w, h] = cube.GetComponent<Block>();

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(characters);
                possibleCharacters.Remove(previousLeft[h]); // ù ���� null, �� ��° �ٺ��� check
                possibleCharacters.Remove(previousBelow); // ���� block Ȯ��.

                // ���� sprite ������
                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
                cube.GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[h] = newSprite;
                previousBelow = newSprite;
            }
        }
    }
}
