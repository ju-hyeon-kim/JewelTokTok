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

    void MakeBoard() // ���� ����� -> ���� ó��: ó�� ������� �����ǿ��� '����!'�� �־�� �ȵ�
    {
        //����x���� 8x8
        int width = 8;
        int height = 8;
        //����
        float Interval = 0.625f;
        for (int w = 0; w < width; w++)
        {
            for(int h  = 0; h < height; h++)
            {
                GameObject cube = Instantiate(Cube, Cubes);
                cube.transform.position += new Vector3(w * Interval, h * Interval, 0);
                //���� �� ������
                RandomColorPaint(cube.GetComponent<SpriteRenderer>());
                //�迭�� ����
                CubeArray[w, h] = cube;
            }
        }

        //��ġ3�� �ִ��� �˻� -> �ִٸ� ���� �ٲ��ֱ�
        if(isMatch3Exist(CubeArray))
        {
            Debug.Log("��ġ3�� �����մϴ�.");
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

    bool isMatch3Exist(GameObject[,] cubearray) // ��ġ3�� �����ϴ��� �Ǵ��ϴ� �Լ�
    {
        for (int w = 0; w < cubearray.GetLength(0); w++)
        {
            for (int h = 0; h < cubearray.GetLength(1); h++)
            {
                //�� ť�갡 ��ġ3�� �ش��ϴ��� �˻�

                //�ڽ��� ���� �ٿ� ������ ����ť�� 2���� �� �ִ��� �˻�
                if(cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w+1, h].GetComponent<SpriteRenderer>().color)
                {
                    //���� ť��� ������ 1ĭ ���� ť��� ���� ����.
                }
                if (cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w + 2, h].GetComponent<SpriteRenderer>().color)
                {
                    //���� ť��� ������ 2ĭ ���� ť��� ���� ����.
                }
                if (cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w - 1, h].GetComponent<SpriteRenderer>().color)
                {
                    //���� ť��� ���� 1ĭ ���� ť��� ���� ����.
                }
                if (cubearray[w, h].GetComponent<SpriteRenderer>().color == cubearray[w - 2, h].GetComponent<SpriteRenderer>().color)
                {
                    //���� ť��� ���� 2ĭ ���� ť��� ���� ����.
                }

                //�ڽ��� ���� �ٿ� ������ ����ť�� 2���� �� �ִ��� �˻�
            }
        }
        return true;
    }
}
