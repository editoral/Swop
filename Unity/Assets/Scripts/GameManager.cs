using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] _forms;
    public GameObject spawnArea1; 
    public GameObject spawnArea2;
    public GameObject[] enemyPrefabs;
    public int spawnInterval;
    public GameObject healthBar1;
    public GameObject healthBar2;

    private PlayerStats _player1;
    private PlayerStats _player2;
    private int _player1FormNumber;
    private int _player2FormNumber;
    private float timeStamp;

    private ArrayList _enemys1;
    private ArrayList _enemys2;

    private Vector3 _player1StartPosition = new Vector3(-3, 3, 0);
    private Vector3 _player2StartPosition = new Vector3(-3, -5, 0);

    // Use this for initialization
    void Start () {
        _enemys1 = new ArrayList();
        _enemys2 = new ArrayList();
        createPlayer();
    }
	
	// Update is called once per frame
	void Update () {
        spawn();
    }

    private void spawn()
    {
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + spawnInterval;
            spawnInArea1();
            spawnInArea2();
        }
    }

    private void spawnInArea1()
    {
        Player playerObject = _player1.getPlayer();
        spawnObjects(spawnArea1, playerObject.gameObject, _enemys1);
    }
    private void spawnInArea2()
    {
        Player playerObject = _player2.getPlayer();
        spawnObjects(spawnArea2, playerObject.gameObject, _enemys2);
    }

    private void spawnObjects(GameObject spawnArea, GameObject player, ArrayList arrayToAppend)
    {
        Vector2 position = getSpawnPosition(spawnArea);
        int nextNumber = getNextRandomNumber(-1, enemyPrefabs.Length);
        GameObject next = enemyPrefabs[nextNumber];
        GameObject enemyObject = Instantiate(next, position, Quaternion.identity) as GameObject;
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        Sound sound = enemyObject.GetComponent<Sound>();
        //sound.PlaySpawn();
        enemy.player = player;
        arrayToAppend.Add(enemy);

    }

    private void setEnemyTarget(int playerNumber)
    {
        GameObject playerObject = null;
        ArrayList enemyArray;
        if (playerNumber == 2) {
            Player p = _player2.getPlayer();
            playerObject = p.gameObject;
            enemyArray = _enemys2;
        } else
        {
            Player p = _player1.getPlayer();
            playerObject = p.gameObject;
            enemyArray = _enemys1;
        }

            
        foreach (Enemy enemy in enemyArray)
        {
            enemy.player = playerObject;
        }
    }
    private void createPlayer()
    {
        _player1 = new PlayerStats(10, new ShooterForm(), this, 1);
        _player2 = new PlayerStats(10, new ShooterForm(), this, 2);
        switchPlayer1();
        switchPlayer2();
    }

    private int getNextRandomNumber(int old, int max)
    {
        int newNumber = Random.Range(0, max);
        while (newNumber == old && max > 1)
        {
            newNumber = Random.Range(0, max);
        }
        return newNumber;
    }

    private PlayerForm getForm(string name)
    {
        PlayerForm result = null;
        switch (name)
        {
            case "Player_Shooter":
                result = new ShooterForm();
                break;
            case "Player_Hippie":
                result = new HippieForm();
                break;
            case "Player_Melee":
                result = new BeaverForm();
                break;
            default:
                result = new PassiveForm();
                break;
        }
        return result;
    }

    private Vector2 getSpawnPosition(GameObject area)
    {
        Collider2D collider = area.GetComponent<Collider2D>();
        Vector3 center = collider.bounds.center;
        float width = collider.bounds.size.x / 2;
        float height = collider.bounds.size.y / 2;
        float leftConst = center.x - width;
        float rightConst = center.x + width;
        float topConst = center.y - height;
        float bottomConst = center.y - height;
        return new Vector2(Random.Range(leftConst, rightConst), Random.Range(topConst, bottomConst));
    }

    public void setHealth(int health, int playerNumber)
    {
        HealthBar hp;
        if (playerNumber == 2)
        {
            hp = healthBar2.GetComponent<HealthBar>();
        }
        else
        {
            hp = healthBar1.GetComponent<HealthBar>();
        }
        hp.health = health * 10;
    }

    public void killDaGangstas(int playerNumber)
    {
        ArrayList enemyArray;
        if (playerNumber == 2)
        {
            enemyArray = _enemys2;
        }
        else
        {
            enemyArray = _enemys1;
        }

        ArrayList copyEnemyList = (ArrayList)enemyArray.Clone();
        foreach (Enemy enemy in copyEnemyList)
        {
            if(enemy.type.Equals("Gangster"))
            {
                Animator ani = enemy.GetComponent<Animator>();
                ani.SetBool("crying", true);
                Sound sound = enemy.GetComponent<Sound>();
                sound.PlayDeath();
                enemyArray.Remove(enemy);
                Destroy(enemy.gameObject, 4);
            }
        }
    }

    public void switchPlayer1()
    {
        switchPlayer(_player1, ref _player1FormNumber, 1, _player1StartPosition);
    }
    public void switchPlayer2()
    {
        switchPlayer(_player2, ref _player2FormNumber, 2, _player2StartPosition);
    }

    public void switchPlayer(PlayerStats player, ref int playerFormNumber, int playerNumber, Vector3 startPosition)
    {
        Player playerObject = player.getPlayer();
        Vector3 position = playerObject != null ? playerObject.transform.position : startPosition;

        int nextNumber = getNextRandomNumber(playerFormNumber, _forms.Length);
        playerFormNumber = nextNumber;
        GameObject next = _forms[nextNumber];
        GameObject nextGameObject = Instantiate(next, position, Quaternion.identity) as GameObject;
        if (playerObject != null)
        {
            Destroy(playerObject.gameObject);
        }
        Player newPlayerObject = nextGameObject.GetComponent<Player>();
        newPlayerObject.inputHandler = new InputHandler(playerNumber);
        player.setPlayer(newPlayerObject);
        newPlayerObject.setStats(player);
        player.setPlayerForm(getForm(newPlayerObject.tag));
        setEnemyTarget(playerNumber);
    }

}
