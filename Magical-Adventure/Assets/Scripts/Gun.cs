using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform firePoint;     // Точка, из которой вылетают пули
    public BulletData spellData;  // Текущий тип заклинания

    private InputAction shootAction;

    void Awake() //Связываем с Input System
    {
        shootAction = new InputAction("Shoot", binding: "<Mouse>/leftButton");
        shootAction.performed += context => Shoot();
    }

    void OnEnable()
    {
        shootAction.Enable();
    }

    void OnDisable()
    {
        shootAction.Disable();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(spellData.bullet, firePoint.position, firePoint.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.Initialize(spellData);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * spellData.speed;
    }
}
