using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class InputManager
{
    private static Controls _gamecontrols;
    //this variable is for the game corntols
    public static void Init(Player myPlayer)
    {
        _gamecontrols = new Controls();

        _gamecontrols.Permanent.Enable();

        _gamecontrols.Game.Jump.performed += jeff => myPlayer.Jump();

        _gamecontrols.Game.Movement.performed += jeff =>
        {
            myPlayer.SetMovementDirection(jeff.ReadValue<Vector3>());

        };
        _gamecontrols.Game.Look.performed += jeff =>
        {
            myPlayer.SetLook(jeff.ReadValue<Vector2>());
        };

        _gamecontrols.Game.Shoot.performed += jeff =>
        {
            myPlayer.Shoot();
        };
        _gamecontrols.Game.Reload.performed += jeff =>
        {
            myPlayer.Reload();
        };
        

    }
    public static void SetGameControls()
    {
        _gamecontrols.Game.Enable();
        _gamecontrols.UI.Disable();
    }
    //this fucniton makes sure the game controls are differnt when in UI

    public static void SetUIControls()
    {
        _gamecontrols.UI.Enable();
        _gamecontrols.Game.Disable();


    }
}//this fucntion makes sure that the game crontols are different in the game