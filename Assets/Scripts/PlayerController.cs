using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public BombTimer bomb;
    public int speed,bombPocket;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        float localSpeed = speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && bombPocket>0){
            bombPocket--;
            BombTimer clone=Instantiate<BombTimer>(bomb,transform.position,transform.rotation);
            clone.player=this;
            clone.bomb=clone;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * localSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * localSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * localSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * localSpeed);
        }
    }
}
