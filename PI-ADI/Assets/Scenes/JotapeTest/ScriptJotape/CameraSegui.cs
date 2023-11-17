using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegui : MonoBehaviour
{
    [SerializeField] GameControl _gameControl;

    [SerializeField] Transform _player;
    public List<Transform> _iniPos;

    public float timer = 15;

    float oldTimer;
    bool isRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        _gameControl = Camera.main.GetComponent<GameControl>();
        oldTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Pagina();
        transform.position = new Vector3(35.42872f, 15.21441f, _player.position.z + 4f);
    }

    void Pagina()
    {
        GameObject bullet = PaginaPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            int number = Random.Range(0, _iniPos.Count);
            bullet.transform.position = _iniPos[number].position;
            // bullet.transform.rotation = turret.transform.rotation;
            bullet.transform.SetParent(_gameControl._paginas);
            bullet.SetActive(true);
        }
    }
}
