using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// (박영준) 플레이시작시 board 생성 및 조정.
public class PlayManager : MonoBehaviour
{
    // 필요 컴퍼넌트
    public Transform Cubes; // block 오브젝트 모아둘 부모 트랜스폼.
    public GameObject Cube; // block 프리팹.
    Block[,] blocklist = null; // 모든 block들 list
    public List<Sprite> characters = new List<Sprite>();
    // 보드 크기 가로x세로 (8x8)
    [SerializeField] int width = 8;
    [SerializeField] int height = 8;

    public static PlayManager inst = null;

    public bool IsShifting { get; set; }

    void Start()
    {
        inst = GetComponent<PlayManager>();

        MakeBoard();
    }

    void MakeBoard() // 보드 만들기 -> 예외 처리: 처음 만들어진 보드판에는 '빙고!'가 있어서는 안됨
    {
        blocklist = new Block[width, height];
        //간격
        float Interval = 0.625f;

        Sprite[] previousLeft = new Sprite[height]; // 직전 line block ( 바로 왼쪽 블락 )
        Sprite previousBelow = null; // 직전 block ( 바로 밑의 블락 )

        for (int w = 0; w < width; w++)
        {
            for(int h  = 0; h < height; h++)
            {
                GameObject cube = Instantiate(Cube, Cubes);
                cube.transform.position += new Vector3(w * Interval, h * Interval, 0);
                blocklist[w, h] = cube.GetComponent<Block>();

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(characters);
                possibleCharacters.Remove(previousLeft[h]); // 첫 줄은 null, 두 번째 줄부터 check
                possibleCharacters.Remove(previousBelow); // 직전 block 확인.

                // 랜덤 sprite 입히기
                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
                cube.GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[h] = newSprite;
                previousBelow = newSprite;
            }
        }
    }
}
