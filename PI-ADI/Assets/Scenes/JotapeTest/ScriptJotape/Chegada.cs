using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;


public class Chegada : MonoBehaviour
{

    [SerializeField] Transform _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Chegada"))
        {
            Debug.Log("tocou no ponto");
            SceneManager.LoadScene("Run-teste");
        }
    }

}
