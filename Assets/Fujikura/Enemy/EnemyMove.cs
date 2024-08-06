using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveDistance = 3f;

    [SerializeField]private GameObject startingPoint;
    private bool movingUp = true;


    void Update()
    {
        Vector3 currentPosition = transform.localPosition;

        if (movingUp)
        {
            currentPosition.y += moveSpeed * Time.deltaTime;
            if (currentPosition.y >= startingPoint.transform.position.y + moveDistance)
            {
                currentPosition.y = startingPoint.transform.position.y + moveDistance;
                movingUp = false;
            }
        }
        else 
        {
            currentPosition.y -= moveSpeed * Time.deltaTime;
            if (currentPosition.y <= startingPoint.transform.position.y)
            {
                currentPosition.y = startingPoint.transform.position.y;
                movingUp = true;
            }
        }

        transform.localPosition = currentPosition;
    }
}

