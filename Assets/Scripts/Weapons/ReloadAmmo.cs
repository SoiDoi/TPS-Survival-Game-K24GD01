using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class ReloadAmmo : MonoBehaviour
{
    [SerializeField] private InputActionReference _reloadAction; // Reference to the reload action
    [SerializeField] private GunAmmo _gunAmmo;
    [SerializeField] private float _reloadTime = 2f; // Time taken to reload in seconds
    private bool _isReloading = false;
    public bool IsReloading => _isReloading;

    public UnityEvent OnReloading;

    private void OnEnable()
    {
        _reloadAction.action.Enable();
        _reloadAction.action.performed += OnReloadPerformed;
    }

    private void OnReloadPerformed(InputAction.CallbackContext context)
    {
        if ( _gunAmmo.currentAmmo == _gunAmmo.maxAmmo || _isReloading)
        {
            return; // No need to reload if already at max ammo or currently reloading
        }
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        Debug.Log("Reloading...");
        Reloading();
        yield return new WaitForSeconds(_reloadTime);

        _gunAmmo.ReloadAmmo();
        Debug.Log("Reload complete!");

        _isReloading = false;
    }

    private void Reloading() => OnReloading.Invoke();

    private void OnDisable()
    {
        _isReloading = false;
        _reloadAction.action.performed -= OnReloadPerformed;
        StopAllCoroutines();
    }
}
