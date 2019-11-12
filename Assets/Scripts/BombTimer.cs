using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{

    public double timer;
    public PlayerController player;
    public BombTimer bomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        Debug.Log(timer);
        if(timer<=0) {
            player.bombPocket++;
            Object.Destroy(this.gameObject);
        }
    }
}
