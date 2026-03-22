using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MentalStateSystem.Instance.ReduceMental(15);
            Destroy(gameObject);
        }
    }
}