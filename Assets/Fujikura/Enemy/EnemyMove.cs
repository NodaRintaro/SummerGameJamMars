using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed_X = 0f;
    [SerializeField] private float moveDistance_X = 0f;
    [SerializeField] private float moveSpeed_Y = 0f;
    [SerializeField] private float moveDistance_Y = 0f;
    [SerializeField] private BackgroundScroll _backgroundScroll;

    private Vector3 startPosition;
    
    private Vector3 _dir;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += _dir * _backgroundScroll.Speed * Time.deltaTime;
        
        float Xoffset = Mathf.PingPong(Time.time * moveSpeed_X, transform.position.x);

        float Yoffset = Mathf.PingPong(Time.time * moveSpeed_Y, transform.position.x);

        if (float.IsNaN(Yoffset)) { Yoffset = 0f; }
        if (float.IsNaN(Xoffset)) { Xoffset = 0f; }
        
        transform.position = startPosition + new Vector3(Xoffset, Yoffset, 0);
    }
}

