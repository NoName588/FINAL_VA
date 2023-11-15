using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerPlayerCounter : MonoBehaviour
{
    public TMP_Text uiText;
    private Player player;
    public GameObject playerT;
    private int powerLvl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = playerT.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerPower();
    }

    private void GetPlayerPower()
    {
        powerLvl = player.powerLvl;

        uiText.text = powerLvl.ToString();
    }
}
