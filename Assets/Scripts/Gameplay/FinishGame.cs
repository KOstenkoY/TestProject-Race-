using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public static event System.Action OnFinishGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            OnFinishGame?.Invoke();
        }
    }
}
