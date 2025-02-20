using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;     // 타겟과 카메라의 거리
    [SerializeField] private float cameraSpeed = 1f;    // 카메라 움직이는 속도 조절
    [SerializeField] Vector2 mapSize;

    float width;
    float height;

    private void Start()
    {
        if (target == null)
            return;

        offset = transform.position - target.position; // 타겟에서 카메라의 거리를 계산
        Debug.Log(new Vector2(Screen.width, Screen.height));
        //SetCameraRange();

        Debug.Log("height:" + height + "widht :" + width);
    }

    public void SetCameraRange()
    {
        // orthographicSize를 바탕으로 카메라 범위 구하기
        height = Camera.main.orthographicSize;
        //width = height * ((float)Screen.width / Screen.height);
        width = height * (1920.0f / 1080);
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        // 부드러운 움직임을 위해 lerp
        pos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);
        transform.position = pos;

        // 카메라 영역 제한

        float limitX = mapSize.x - width; // 카메라가 최대한 갈 수 있는 가로 거리
        float clampX = Mathf.Clamp(transform.position.x, -limitX, limitX);

        float limitY = mapSize.y - height; // 카메라가 최대한 갈 수 있는 세로 거리
        float clampY = Mathf.Clamp(transform.position.y, -limitY, limitY);

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, mapSize * 2);
    }
}
