using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public Transform Cubes;
    public GameObject Cube;
    GameObject[,] CubeArray = new GameObject[8,8];

    void Start()
    {
        MakeBoard();
    }

    void MakeBoard() // 보드 만들기 -> 예외 처리: 처음 만들어진 보드판에는 '빙고!'가 있어서는 안됨
    {
        //가로x세로 8x8
        int width = 8;
        int height = 8;
        //간격
        float Interval = 0.625f;
        for (int w = 0; w < width; w++)
        {
            for(int h  = 0; h < height; h++)
            {
                GameObject cube = Instantiate(Cube, Cubes);
                cube.transform.position += new Vector3(w * Interval, h * Interval, 0);
                //랜덤 색 입히기
                RandomColorPaint(cube.GetComponent<SpriteRenderer>());
                //배열에 저장
                CubeArray[w, h] = cube;
            }
        }

        //매치3가 있는지 검사 -> 있다면 색깔 바꿔주기
        if(isMatch3Exist(CubeArray))
        {
            Debug.Log("매치3가 존재합니다.");
        }
    }

    void RandomColorPaint(SpriteRenderer cube)
    {
        int rnd = Random.Range(0, 4);
        switch(rnd)
        {
            case 0:
                cube.color = Color.red;
                break;
            case 1:
                cube.color = Color.blue;
                break;
            case 2:
                cube.color = Color.green;
                break;
            case 3:
                cube.color = Color.yellow;
                break;
            case 4:
                cube.color = Color.cyan;
                break;
        }
    }

    bool isMatch3Exist(GameObject[,] cubearray) // 매치3가 존재하는지 판단하는 함수
    {
        for (int w = 0; w < cubearray.GetLength(0); w++)
        {
            for (int h = 0; h < cubearray.GetLength(1); h++)
            {
                //각 큐브가 매치3에 해당하는지 검사

                //자신의 가로 줄에 동일한 색상큐브 2개가 더 있는지 검사
                if(cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w+1, h].GetComponent<SpriteRenderer>().color)
                {
                    //현재 큐브와 오른쪽 1칸 옆의 큐브와 색이 같다.
                }
                if (cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w + 2, h].GetComponent<SpriteRenderer>().color)
                {
                    //현재 큐브와 오른쪽 2칸 옆의 큐브와 색이 같다.
                }
                if (cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w - 1, h].GetComponent<SpriteRenderer>().color)
                {
                    //현재 큐브와 왼쪽 1칸 옆의 큐브와 색이 같다.
                }
                if (cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w - 2, h].GetComponent<SpriteRenderer>().color)
                {
                    //현재 큐브와 왼쪽 2칸 옆의 큐브와 색이 같다.
                }

                //자신의 세로 줄에 동일한 색상큐브 2개가 더 있는지 검사
            }
        }
        return true;
    }
}
