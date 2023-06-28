using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
