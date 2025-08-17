
using TMPro;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private int _maxAmmo = 31;
    [SerializeField] private int _currentAmmo;

    [SerializeField] private TextMeshProUGUI  _ammoText;
    public int currentAmmo => _currentAmmo;
    public int maxAmmo => _maxAmmo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentAmmo = _maxAmmo -1;
        _ammoText.text = _currentAmmo.ToString() + " / " + (_maxAmmo -1 ).ToString();
    }

    public void UseAmmo()
    {
        if (_currentAmmo <= 0)
        {
            return;
        }
        else
        {
            _currentAmmo--;
            _ammoText.text = _currentAmmo.ToString() + " / " + (_maxAmmo - 1).ToString();
        }
    }
    public void ReloadAmmo()
    {
       if (_currentAmmo >= _maxAmmo)
        {
            return; // No need to reload if already at max ammo
        }
       if (_currentAmmo <= 0)
        {
            _currentAmmo = _maxAmmo - 1; // Reload to max ammo if current ammo is zero
        }
        else
        {
            _currentAmmo = _maxAmmo; // Reload to max ammo
        }
        _ammoText.text = _currentAmmo.ToString() + " / " + (_maxAmmo - 1).ToString();
    }
}
