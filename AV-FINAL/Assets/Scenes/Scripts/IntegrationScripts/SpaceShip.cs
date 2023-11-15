using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    //Se puede cambiar luego en GameObject
     public PlayerP player = new PlayerP();
     public  EnemyP enemy = new EnemyP();
     public ObjectP objectP = new ObjectP();
        
    //Se puede cambiar luego en GameObject
    public PlayerP[,] playerPosition;
    public EnemyP[,] enemyPosition;
    public ObjectP[,] objectPosition;

    private int[,] size;
    private int widht;
    private int height;
    private int room = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        CreatingSize(Random.Range(0, 10), Random.Range(0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        RoomClear();
    }

    public void CreatingSize(int height, int widht)
    {
        size = new int[height, widht];
        this.height = height;
        this.widht = widht;

        for (int i = 0; i < widht; i++)
        {
            for (int j = 0; j < height; j++)
            {
                size[i, j] = 0;
            }
        }
    }

    public bool RoomClear()
    {
        if (room == 0)
            return true;
        else
            return false;
    }

    public void EntityPosition(string entity, int positionX, int positionY)
    {
        if (entity == "Player")
        {
            playerPosition[positionX, positionY] = player;
            size[positionX, positionY] = 1;
        }
        else if(entity == "Enemy")
        {
            enemyPosition[positionX, positionY] = enemy;
            size[positionX, positionY] = 1;
        }
        else if (entity == "Object")
        {
            objectPosition[positionX, positionY] = objectP;
            size[positionX, positionY] = 1;
        }
    }

    public void SetEnemyPositions(EnemyP[,] enemies)
    {
        enemyPosition = enemies;
    }

    public void SetObjectPositions(ObjectP[,] objects)
    {
        objectPosition = objects;
    }
}
