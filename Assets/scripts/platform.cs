using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour {
	bool gameStart=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			gameStart = true; 
		}
		//用鼠标控制接球板位置 两者同步
		//		Input.GetMouseButton(0);  
		//		0:左键
		//		1：右键
		//		2：中键
		//		print(Input.mousePosition); 输出鼠标位置  左下角为坐标原点(0,0,0)

		if (gameStart) {
			//坐标转换 屏幕坐标--》游戏坐标
			//		方式1：新版有做改变 不建议用  5.4支持
			Vector3 gamePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//		print (gamePosition);
			// 设置Y轴不变 只需左右移动 Z轴为0;
			this.transform.position = new Vector3 (gamePosition.x, transform.position.y, 0);
		}



		
	}

//	void OnGUI(){
//		//		方式2：新版方法
//		Event e=Event.current; //当前事件
//		Vector2 mousePosition=new Vector2();
//		mousePosition.x = e.mousePosition.x;
//		mousePosition.y =Camera.main.pixelHeight-e.mousePosition.y;
//
//		Vector3 gamePosition = Camera.main.ScreenToWorldPoint (new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
//		print (gamePosition);
//	}


}
