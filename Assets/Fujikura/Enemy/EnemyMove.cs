using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed_X = 0f;
    [SerializeField] private float moveDistance_X = 0f;

    [SerializeField] private float moveSpeed_Y = 0f;
    [SerializeField] private float moveDistance_Y = 0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float Xoffset = Mathf.PingPong(Time.time * moveSpeed_X, moveDistance_X);

        float Yoffset = Mathf.PingPong(Time.time * moveSpeed_Y, moveDistance_Y);

        if (float.IsNaN(Yoffset)) { Yoffset = 0f; }
        if (float.IsNaN(Xoffset)) { Xoffset = 0f; }


        transform.position = startPosition + new Vector3(Xoffset, Yoffset, 0);
    }
}

