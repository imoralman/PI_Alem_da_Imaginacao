using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pato : MonoBehaviour
{


    [SerializeField] Transform _player;

    [SerializeField] float _segui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(_player.position.x, transform.position.y, _player.transform.position.z - 3);

    }
}
