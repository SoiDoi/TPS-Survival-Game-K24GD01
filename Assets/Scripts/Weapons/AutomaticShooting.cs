using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AutomaticShooting : Shooting
{
    [SerializeField] private InputActionReference _shootAction;
    [SerializeField] private float _cooldown;
    [SerializeField] private GunAmmo _gunAmmo;
    [SerializeField] private ReloadAmmo _reloadAmmo;

    private float _lastShotTime;

    public UnityEvent OnShoot, OnEmpty;

    private void Update()
    {
        if (_shootAction.action.IsPressed() && FinishCooldown() && (_gunAmmo.currentAmmo >0 ) &&(!_reloadAmmo.IsReloading))
        {
            Shoot();
            _lastShotTime = Time.time;
        }
        else
        {
            Empty();
        }
    }

    private bool FinishCooldown() => Time.time - _lastShotTime >= _cooldown;

    private void Shoot() => OnShoot.Invoke();
    private void Empty() => OnEmpty.Invoke();
}
