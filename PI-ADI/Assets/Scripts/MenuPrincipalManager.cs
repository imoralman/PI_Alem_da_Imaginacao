using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomedoleveldejogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOp�oes;

    public void AbrirOp�oes()
    {
        painelMenuInicial.SetActive(false);
        painelOp�oes.SetActive(true); ;
    }

    public void fecharOp�oes()
    {
        painelOp�oes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void sairjogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

    public void ChamaJogo()
    {
        SceneManager.LoadScene("Run");
    }
}