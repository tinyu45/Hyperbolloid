using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//创建砖块
public class game : MonoBehaviour {

	int row=10;
	int col=16;
	SpriteRenderer[] cubes;
	// Use this for initialization
	void Start () {
		cubes=new SpriteRenderer[row*col];

		string[] brickNames = new string[]{"blue","red","green","yellow","purple"};
		Vector2 startPoint = new Vector2 (-7.6f, 4.8f); //砖块起始坐标
		for(int j=0; j<row; j++){
			for(int i=0; i<col; i++){
				int index = Random.Range (0, brickNames.Length);
				GameObject cube = GameObject.Find (brickNames[index]);
				GameObject newCube = Instantiate (cube) as GameObject;
				newCube.transform.position = new Vector3 (startPoint.x + i, startPoint.y-j*0.5f, 0);
				cubes [j * col + i] = newCube.GetComponent<SpriteRenderer> ();
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		GameObject ball = GameObject.Find ("ball");
		SpriteRenderer b_render = ball.GetComponent<SpriteRenderer> ();
		Bounds b_bounds = b_render.bounds;
		for (int i = 0; i < cubes.Length; i++) {
			if (cubes [i] != null) {
				Bounds b = cubes [i].bounds;
				if (b.Intersects (b_bounds)) {
                    GetNearCubesOfsameColor(i, cubes[i].sprite.name);
                    if (cubes[i] != null) {
                        Destroy(cubes[i].gameObject); //销毁当前砖块
                        cubes[i]=null;
                    }
                    //Destroy (cubes [i].gameObject); //销毁当前砖块
                    //cubes[i]=null;
                    ball.GetComponent<ball>().ReverseY(); //调用其上脚本方法
				}
			}
		}
	}


    //获取周边同颜色成员
   // List<SpriteRenderer> GetNearCubesOfsameColor(int index)
    void GetNearCubesOfsameColor(int index, string name) {
        List<SpriteRenderer> cubesList = new List<SpriteRenderer>();
        int up = index - col<0 ? -1: index - col;
        int down = (index + col) >= cubes.Length ? -1 : index + col;
        int left = (index - 1) % col == 0 ? -1 : index - 1;
        int right = (index + 2) % col!=0 && index+1<cubes.Length ? index+1 : -1;

       // print(right);
        //print("up:" + up + ",down:" + down + ",left:" + left + ",right" + right);
        if (up != -1 && cubes[up] != null)
        {
            if (cubes[up].sprite.name == name)
            {
                GameObject.Destroy(cubes[up].gameObject);
                cubes[up] = null;
                GetNearCubesOfsameColor(up, name);
            }
        }



        if (down != -1 && cubes[down] != null)
        {
            if (cubes[down].sprite.name == name)
            {
                GameObject.Destroy(cubes[down].gameObject);
                cubes[down] = null;
                GetNearCubesOfsameColor(down, name);
            }
        }


        if (left != -1 && cubes[left] != null)
        {
            if (cubes[left].sprite.name == name)
            {
                Destroy(cubes[left].gameObject);
                cubes[left] = null;
                GetNearCubesOfsameColor(left, name);
            }
        }


        if (right != -1 && cubes[right] != null)
        {
            if (cubes[right].sprite.name == name)
            {
                GameObject.Destroy(cubes[right].gameObject);
                cubes[right] = null;
                GetNearCubesOfsameColor(right, name);
            }
        }


    }


}
