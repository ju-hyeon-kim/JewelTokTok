using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (�ڿ���) �÷��̽��۽� board ���� �� ����.
public class PlayManager : MonoBehaviour
{
    // �ʿ� ���۳�Ʈ
    public GameObject cube; // block ������.
    private GameObject[,] cubes;
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
        MakeBoard(0.625f, 0.625f);
    }

    void MakeBoard(float _xOffset, float _yOffset) // ���� ����� -> ���� ó��: ó�� ������� �����ǿ��� '����!'�� �־�� �ȵ�
    {
        cubes = new GameObject[width, height];
        //����
        float startX = transform.position.x;
        float startY = transform.position.y;

        Sprite[] previousLeft = new Sprite[height]; // ���� line block ( �ٷ� ���� ��� )
        Sprite previousBelow = null; // ���� block ( �ٷ� ���� ��� )

        for (int w = 0; w < width; w++)
        {
            for(int h  = 0; h < height; h++)
            {
                GameObject newCube = Instantiate(cube, new Vector3(startX + ((_xOffset) * w), startY + ((_yOffset) * h), 0), cube.transform.rotation);
                cubes[w, h] = newCube;
                newCube.transform.parent = this.transform;

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
