using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int powerLvl;

    protected int widht;
    protected int height;
    protected int columns;
    protected int rows;

    public int startPositionX;
    public int startPositionY;

    protected int actualPositionX;
    protected int actualPositionY;

    public SpaceMovementGrid gridMovement;

    // Start is called before the first frame update
    void Start()
    {
        SetUpGridMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetUpGridMovement()
    {
        height = (int)Camera.main.orthographicSize;
        widht = height * (Screen.width / Screen.height);

        columns = widht * 2;
        rows = height * 2;
    }
}
