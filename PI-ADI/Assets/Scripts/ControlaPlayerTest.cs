using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPlayerTest : MonoBehaviour
{
    [SerializeField] CharacterController _player;
    [SerializeField] float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _player.transform.position += new Vector3(0, 0, _speed) * Time.deltaTime;
    }
}
