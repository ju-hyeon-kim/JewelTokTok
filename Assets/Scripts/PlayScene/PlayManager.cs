using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public Transform Cubes;
    public GameObject Cube;

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
            }
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
}
