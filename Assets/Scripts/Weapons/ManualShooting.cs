using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ManualShooting : Shooting
{
    [SerializeField] private InputActionReference _shootAction;
    [SerializeField] private GunAmmo _gunAmmo;
    [SerializeField] private ReloadAmmo _reloadAmmo;
    [SerializeField] private float _cooldown = 0.5f; // Cooldown time between shots

    public UnityEvent OnShoot, OnEmpty;

    private float _lastShootTime = -Mathf.Infinity;

    private void Update()
    {
        if (_shootAction.action.triggered)
        {
            if (_reloadAmmo.IsReloading)
            {
                return;
            }


            if (Time.time - _lastShootTime >= _cooldown)
            {
                if (_gunAmmo.currentAmmo > 0)
                {
                    Shoot();
                }
                else
                {
                    Debug.Log("No ammo left!");
                    Empty();
                }
                _lastShootTime = Time.time;
            }
        }
    }

    private void Shoot() => OnShoot.Invoke();
    private void Empty() => OnEmpty.Invoke();
}
