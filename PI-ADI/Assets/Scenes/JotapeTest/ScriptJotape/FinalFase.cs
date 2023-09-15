using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalFase : MonoBehaviour
{

    [SerializeField] Transform _player;
    [SerializeField] Transform _final;
    [SerializeField] Slider _barraProgresso;


    [SerializeField] float distancia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(_final.transform.position, _player.position);
        _barraProgresso.value = distancia;

    }
}
