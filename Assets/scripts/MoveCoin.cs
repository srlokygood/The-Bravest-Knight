using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{

    public List<GameObject> coins;

    public TerrainController terraincontrol;
    public GameObject coin;

    private float coins_positions;
    /* = [
        {
            x: 2.846,
            y: -0.18,
        },
        {
            x: 3.846,
            y: -0.18,
        },
        {
            x: 4.846,
            y: -0.18,
        },
                {
            x: 2.846,
            y: 0.2,
        },
        {
            x: 2.846,
            y: 0.42,
        },
        {
            x: 2.846,
            y: 0.62,
        }
    ];*/
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i =0;coins.count < coins_position.length;i++){
            coins.Add(Instantiate(coin,new Vector2(coins_position[i].x,coins_position[i].y), Quaternion.identity));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(coins.Count>0){
            for (int i = 0;i<coins.Count;i++)
            {
                move_coins(i);
            }
        }
    }

    void move_coins(int i){
        coins[i].transform.position = coins[i].transform.position + new Vector3(-terraincontrol.Velocity* Time.deltaTime , 0,0);
        
    }
    
}
