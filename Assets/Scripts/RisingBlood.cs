using UnityEngine;

public class RisingBlood : MonoBehaviour
{
    [SerializeField] private float _raiseSpeed = 2.0f;
    [field: SerializeField] public bool Stopped { get; set; } = false;

    private void Update()
    {
        if (Stopped) return;

        transform.localScale += _raiseSpeed * Time.deltaTime * Vector3.up;
        transform.position += (_raiseSpeed * 0.5f) * Time.deltaTime * Vector3.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController))
            playerController.Die();
    }
}
