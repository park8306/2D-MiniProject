using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;     // 타겟과 카메라의 거리
    [SerializeField] private float cameraSpeed = 1f;    // 카메라 움직이는 속도 조절
    //[SerializeField] Vector2 mapSize;

    private void Start()
    {
        if (target == null)
            return;

        offset = transform.position - target.position; // 타겟에서 카메라의 거리를 계산
        Debug.Log(new Vector2(Screen.width, Screen.height));
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        // 부드러운 움직임을 위해 lerp
        pos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);
        transform.position = pos;


    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(Vector3.zero, mapSize * 2);
    //}
}
