using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler {
    private PlayerInput _player1;
    private PlayerInput _player2;
    private int _playerNumber;

    public InputHandler(int playerNumber)
    {
        _playerNumber = playerNumber;
    }

	public void updateValues()
    {
        _player1 = new PlayerInput();
        _player1.y = Input.GetAxis("Vertical1");
        _player1.x = Input.GetAxis("Horizontal1");
        _player1.ability = Input.GetButtonDown("Ability1");
        _player1.switchPlayer = Input.GetButtonDown("Switch1");
        _player2 = new PlayerInput();
        _player2.y = Input.GetAxis("Vertical2");
        _player2.x = Input.GetAxis("Horizontal2");
        _player2.ability = Input.GetButtonDown("Ability2");
        _player2.switchPlayer = Input.GetButtonDown("Switch2");
    }

    public PlayerInput getInput()
    {
        if (_playerNumber == 1)
        {
            return _player1;
        }
        return (_playerNumber == 2) ? _player2 : _player1;
    }
}
