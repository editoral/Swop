using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10.0F;
    public LayerMask obstacleLayer;
    public GameObject bullet;
    public InputHandler inputHandler;
    public GameObject attackCollider;

    private Vector2 _viewDirection;
    private PlayerStats _stats;
    private PlayerInput _input;
    private AnimationHandler _animationHandler;
    private float attackResetInterval = 0.5f;
    private float timeStamp;

    // Use this for initialization
    void Start () {
        Animator animator = GetComponent<Animator>();
        _animationHandler = new AnimationHandler(animator);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        inputHandler.updateValues();
        _input = inputHandler.getInput();
        move();
        ability();
        switchPlayer();
        resetAnimation();

    }

    public void setStats(PlayerStats stats)
    {
        _stats = stats;
    }

    public PlayerStats getStats()
    {
        return _stats;
    }

    private void ability()
    {
        if(_input.ability)
        {
            _stats.executeAbility(_viewDirection);
        }
    }

    private void switchPlayer()
    {
        if (_input.switchPlayer)
        {
            _stats.triggerSwitch();
        }
    }

    private void move()
    {
        float y = _input.y * speed * Time.fixedDeltaTime;
        float x = _input.x * speed * Time.fixedDeltaTime;
        Vector2 translation = new Vector2(x, y);
        if (translation.magnitude > 0)
        {
            _viewDirection = translation;
            _animationHandler.directionHandling(x, y);
        }

        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.MovePosition(rg.position + translation);
    }

    private void resetAnimation()
    {
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + attackResetInterval;
            Animator ani = GetComponent<Animator>();
            ani.SetBool("attacking", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Melee"))
        {
            other.enabled = false;
            _stats.takeDamage(1);
        }
    }

}
