using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletData bulletData;

    public void Initialize(BulletData data)
    {
        bulletData = data;
    }

    void OnCollisionEnter(Collision collision)
    {
        Impact(collision);
    }

    void Impact(Collision collision)
    {
        // Уничтожить пулю
        Destroy(gameObject);
    }
}