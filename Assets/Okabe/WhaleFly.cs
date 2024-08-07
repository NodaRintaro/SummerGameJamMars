using UnityEngine;

public class WhaleFly : MonoBehaviour
{
    private Rigidbody2D rb;

    // 飛ばす力の強さを設定
    public Vector2 forceDirection = new(0, 5); // Y軸方向に上に飛ばす
    public float forceMultiplier = 10f;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        Debug.Log(rb);
    }

    // 他のオブジェクトと衝突したときに呼ばれる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("sss");
        // 力を加えてオブジェクトを飛ばす
        rb.AddForce(forceDirection * forceMultiplier, ForceMode2D.Impulse);
    }
}