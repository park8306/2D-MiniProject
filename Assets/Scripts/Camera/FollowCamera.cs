using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;     // Ÿ�ٰ� ī�޶��� �Ÿ�
    [SerializeField] private float cameraSpeed = 1f;    // ī�޶� �����̴� �ӵ� ����
    [SerializeField] Vector2 mapSize;

    float width;
    float height;

    private void Start()
    {
        if (target == null)
            return;

        offset = transform.position - target.position; // Ÿ�ٿ��� ī�޶��� �Ÿ��� ���
        Debug.Log(new Vector2(Screen.width, Screen.height));
        //SetCameraRange();

        Debug.Log("height:" + height + "widht :" + width);
    }

    public void SetCameraRange()
    {
        // orthographicSize�� �������� ī�޶� ���� ���ϱ�
        height = Camera.main.orthographicSize;
        //width = height * ((float)Screen.width / Screen.height);
        width = height * (1920.0f / 1080);
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        // �ε巯�� �������� ���� lerp
        pos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSpeed);
        transform.position = pos;

        // ī�޶� ���� ����

        float limitX = mapSize.x - width; // ī�޶� �ִ��� �� �� �ִ� ���� �Ÿ�
        float clampX = Mathf.Clamp(transform.position.x, -limitX, limitX);

        float limitY = mapSize.y - height; // ī�޶� �ִ��� �� �� �ִ� ���� �Ÿ�
        float clampY = Mathf.Clamp(transform.position.y, -limitY, limitY);

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, mapSize * 2);
    }
}
