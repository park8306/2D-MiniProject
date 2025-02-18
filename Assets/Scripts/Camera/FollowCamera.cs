using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;     // Ÿ�ٰ� ī�޶��� �Ÿ�
    [SerializeField] private float cameraSpeed = 1f;    // ī�޶� �����̴� �ӵ� ����
    //[SerializeField] Vector2 mapSize;

    private void Start()
    {
        if (target == null)
            return;

        offset = transform.position - target.position; // Ÿ�ٿ��� ī�޶��� �Ÿ��� ���
        Debug.Log(new Vector2(Screen.width, Screen.height));
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        // �ε巯�� �������� ���� lerp
        pos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);
        transform.position = pos;


    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(Vector3.zero, mapSize * 2);
    //}
}
