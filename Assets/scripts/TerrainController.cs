using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public float Velocity;
    public List<GameObject> terrains;

    public GameObject terrain;
    
    public int probabilty;
    private float randomNum;
    private float lastTerrain = 3f;
    private float position;
    private float secondposition;

    void Start()
    {
       for(int i=0;i<=6;i++){
           position = -3f+i;
           terrainGenerate(position);
        }
    }

    void Update()
    {
        for(int i = 0;i<terrains.Count;i++){
            move_map(i);
        }
    }

    void terrainGenerate(float position){
        if(terrains.Count <= 7){
            terrains.Add(Instantiate(terrain,new Vector2(position,-0.473f), Quaternion.identity));
        }
    }

    void move_map(int i){
        terrains[i].transform.position = terrains[i].transform.position + new Vector3(-Velocity* Time.deltaTime , 0,0);
        if(terrains[i].transform.position.x <= -3.6f){
            int m = i-1;
            if(m == -1){
                m = 6;
            }
            float l = separe_terrain();
            terrains[i].transform.position = terrains[m].transform.position + new Vector3(1f+l,0f,0f);
        }
    }

    float separe_terrain(){
        float s = 0;
        if(Random.Range(0,10) == 1){
            randomNum = Random.Range(50,175);
            s = randomNum * 0.01f;
        }
        return s;
    }
}
