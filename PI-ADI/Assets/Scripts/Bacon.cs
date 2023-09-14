using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacon : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] float _speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, _speed) * Time.deltaTime;
    }
}
