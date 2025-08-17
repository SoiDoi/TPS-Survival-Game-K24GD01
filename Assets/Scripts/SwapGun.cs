using UnityEngine;
using UnityEngine.InputSystem;

public class SwapGun : MonoBehaviour
{
    [SerializeField] private InputActionReference _switchPistol;
    [SerializeField] private InputActionReference _switchRifle;
    [SerializeField] private InputActionReference _switchMotar;

    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _rifle;
    [SerializeField] private GameObject _motar;

    [SerializeField] private GameObject _pistolSelect;
    [SerializeField] private GameObject _rifleSelect;
    [SerializeField] private GameObject _motarSelect;


    private void Start()
    {

    }


    private void OnEnable()
    {
        _switchPistol.action.Enable();
        _switchRifle.action.Enable();
        _switchMotar.action.Enable();
        _switchPistol.action.performed += SwitchToPistol;
        _switchRifle.action.performed += SwitchToRifle;
        _switchMotar.action.performed += SwitchToMotar;
    }
    private void OnDisable()
    {
        _switchPistol.action.Disable();
        _switchRifle.action.Disable();
        _switchMotar.action.Disable();
        _switchPistol.action.performed -= SwitchToPistol;
        _switchRifle.action.performed -= SwitchToRifle;
        _switchMotar.action.performed -= SwitchToMotar;
    }
    private void SwitchToPistol(InputAction.CallbackContext context) // Chuyển qua súng lục / Swap to pistol
    {
        _pistol.SetActive(true);
        _pistolSelect.SetActive(true);
        _rifle.SetActive(false);
        _rifleSelect.SetActive(false);
        _motar.SetActive(false);
        _motarSelect.SetActive(false);
    }
    private void SwitchToRifle(InputAction.CallbackContext context) // Chuyển qua súng trường / Swap to rifle
    {
        _pistol.SetActive(false);
        _pistolSelect.SetActive(false);
        _rifle.SetActive(true);
        _rifleSelect.SetActive(true);
        _motar.SetActive(false);
        _motarSelect.SetActive(false);
    }
    private void SwitchToMotar(InputAction.CallbackContext context) // Chuyển qua súng cối / Swap to motar
    {
        _pistol.SetActive(false);
        _pistolSelect.SetActive(false);
        _rifle.SetActive(false);
        _rifleSelect.SetActive(false);
        _motar.SetActive(true);
        _motarSelect.SetActive(true);
    }


}
