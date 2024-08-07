using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private ClearTime _clear;
    [SerializeField] ParticleSystem fireWork;

    [SerializeField, Header("ゴールしたときに遷移させる時間")]
    private float _time = 2f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.gameObject.CompareTag("Player"))
        {
            GoalIn();
        }
    }
    private void GoalIn()
    {
        _clear.IsClear = true;
        fireWork.Play();
        Invoke(nameof(OpenResult), _time);
    }
    private void OpenResult()
    {
        SceneManager.LoadScene("Result");
    }
}
