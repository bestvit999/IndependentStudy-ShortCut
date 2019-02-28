using UnityEngine;
using System.Collections.Generic;

public class CameraLogic : MonoBehaviour {

    public float x;
    public float y;
    public float sensitivityMouse = 200;
    public float distence; //camera與腳色之距離
    public float disSpeed = 100;//滾輪靈敏度
    public float minDistence = 1;
    public float maxDistence = 5;
    private Quaternion rotationEuler;
    private Vector3 cameraPosition;

    private Transform m_currentTarget;
    private float m_distance = 2f;
    private float m_height = 1;
    private float m_lookAtAroundAngle = 180;

    [SerializeField] private List<Transform> m_targets;
    private int m_currentIndex;

	private void Start () {
        if(m_targets.Count > 0)
        {
            m_currentIndex = 0;
            m_currentTarget = m_targets[m_currentIndex];
        }
	}

    private void SwitchTarget(int step)
    {
        if(m_targets.Count == 0) { return; }
        m_currentIndex+=step;
        if (m_currentIndex > m_targets.Count-1) { m_currentIndex = 0; }
        if (m_currentIndex < 0) { m_currentIndex = m_targets.Count - 1; }
        m_currentTarget = m_targets[m_currentIndex];
    }

    public void NextTarget() { SwitchTarget(1); }
    public void PreviousTarget() { SwitchTarget(-1); }

    private void Update () {
        if (m_targets.Count == 0) { return; }
    }

    private void LateUpdate()
    {
        if(m_currentTarget == null) { return; }

        float targetHeight = m_currentTarget.position.y + m_height;
        float currentRotationAngle = m_lookAtAroundAngle;

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        Vector3 position = m_currentTarget.position;
        position -= currentRotation * Vector3.forward * m_distance;
        position.y = targetHeight;

        transform.position = position;
        transform.LookAt(m_currentTarget.position + new Vector3(0, m_height, 0));

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
        cameraPosition = rotationEuler * new Vector3(0, 0, -distence) + m_currentTarget.position;

        transform.rotation = rotationEuler;
        transform.position = cameraPosition + new Vector3(0, 1.5f, 0);

    }
}
