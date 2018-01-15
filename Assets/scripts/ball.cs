using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour {

	bool move=false;

	float speed=0.14f; //速度；

	float speedX =0 ; //水平速度
	float speedY =0 ; //竖直速度

	// Use this for initialization
	void Start () {
		//获取当前游戏对象的渲染器组件
//		SpriteRenderer render=GetComponent<SpriteRenderer>();
//		Sprite sprite = render.sprite;
////		sprite.border;  //图片UI边框
////		print(sprite.border);
//		Bounds ballBounds=render.bounds; //边界
//
//		GameObject platform = GameObject.Find ("platform");
//		SpriteRenderer p_render = platform.GetComponent<SpriteRenderer> ();
//		Bounds p_bounds = p_render.bounds;
//		//判断碰撞
//		print (ballBounds.Intersects(p_bounds));
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        //碰撞改变速度方向
        if (CollideWith("platform") && move)
        {
            speedY = -speedY;
        }
    }


	public void ReverseY(){
		speedY = -speedY; //翻转Y坐标速度方向
	}


	//控制小球移动
	void Move(){
		if(Input.GetMouseButtonDown(0) && !move){
			move = true;
			//			float angle = Random.Range (30,150);
			//			float radians = angle * Mathf.PI / 180f;
			//			优化
			float radians=Random.Range(0.52f, 2.6f);
			speedX = speed * Mathf.Cos (radians);
			speedY = speed * Mathf.Sin (radians);
		}
		if (move) {
			//x (-8.5,8.5)
			//y(-4.8.4.8)
			//物体都带用transform组件，来控制大小，旋转.位置
			float nextX=this.transform.position.x+speedX;
			float nextY = this.transform.position.y + speedY;

			if ((speedX < 0 && nextX <= -8.5f) || (speedX > 0 && nextX >= 8.5f)) {
				speedX = -speedX;
			}

			if (speedY > 0 && nextY >= 4.8f) {
				speedY = -speedY;
			}


            if (speedY < 0 && nextY <= -4.8f) {
                if (move) {
                    print("game over !!!");
                    SceneManager.LoadScene("over");
                }
                move = false;
            }

            this.transform.position += new Vector3(speedX, speedY, 0);
        }
	}


	//判断碰撞
	bool CollideWith(string objName){
		GameObject obj = GameObject.Find (objName);
		if (obj == null || obj.GetComponent<SpriteRenderer> ()==null) {
			return false;
		}
		SpriteRenderer render = obj.GetComponent<SpriteRenderer> ();
		Bounds plat_bounds =render.bounds;
		Bounds ball_bounds=GetComponent<SpriteRenderer>().bounds;
		return ball_bounds.Intersects (plat_bounds);
	}   



	  
}
