using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMovement : MonoBehaviour {
    
        public Transform target;//跟隨目標,i.e.主角
        public float x;
        public float y;
        public float sensitivityMouse = 200;
        public float distence; //camera與腳色之距離
        public float disSpeed = 100;//滾輪靈敏度
        public float minDistence = 1;
        public float maxDistence = 5;

        private Quaternion rotationEuler;
        private Vector3 cameraPosition;

        private void LateUpdate()
        {
            //按着鼠标右键实现视角转动  
            if (Input.GetMouseButton(1))
                {
                //讀取滑鼠的X,Y軸移動訊息
                x += Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
                y -= Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;

                //保證X在360度以內
                if (x > 360)
                {
                    x -= 360;
                }
                else if (x < 0)
                {
                    x += 360;
                }
            }

            //讀取滑鼠滾輪的數值
            distence -= Input.GetAxis("Mouse ScrollWheel") * disSpeed * Time.deltaTime;
            //限制距離
            distence = Mathf.Clamp(distence, minDistence, maxDistence);

            rotationEuler = Quaternion.Euler(y, x, 0);
            cameraPosition = rotationEuler * new Vector3(0, 0, -distence) + target.position;

            transform.rotation = rotationEuler;
            transform.position = cameraPosition + new Vector3(0, 1, 0);

        }
    

}