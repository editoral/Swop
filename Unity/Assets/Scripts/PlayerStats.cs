using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats {
    private int _health;
    private PlayerForm _playerForm;
    private Vector3 _viewDirection;
    private Player _player;
    private GameManager _manager;
    private int _playerNumber;
    public PlayerStats(int health, PlayerForm playerForm, GameManager manager, int playerNumber)
    {
        _health = health;
        _playerForm = playerForm;
        _manager = manager;
        _playerNumber = playerNumber;
    }

    public void takeDamage(int dmg)
    {
        _health -= dmg;
        _manager.setHealth(_health ,_playerNumber);
        if (_health < 0)
        {
            GameObject.Destroy(_player.gameObject);
            Application.LoadLevel("GameOver");
        }
    }

    public void executeAbility(Vector2 viewDirection)
    {
        _viewDirection = viewDirection;
        _playerForm.executeAbility(this);
    }

    public void triggerSwitch()
    {
        if (_playerNumber == 2)
        {
            _manager.switchPlayer1();
        } else
        {
            _manager.switchPlayer2();
        }
    }

    public void stopTheGangsters()
    {
        Sound sound = _player.GetComponent<Sound>();
        sound.PlayAttack();
        Animator ani = _player.GetComponent<Animator>();
        ani.SetBool("attacking", true);
        _manager.killDaGangstas(_playerNumber);
    }

    public Vector2 getViewDirection()
    {
        return _viewDirection;
    }

    public void setPlayer(Player player)
    {
        _player = player;
    }

    public Player getPlayer()
    {
        return _player;
    }

    public void setPlayerForm(PlayerForm form)
    {
        _playerForm = form;
    } 
}
