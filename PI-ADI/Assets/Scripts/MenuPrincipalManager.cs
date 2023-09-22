using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomedoleveldejogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpçoes;

    public void AbrirOpçoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpçoes.SetActive(true); ;
    }

    public void fecharOpçoes()
    {
        painelOpçoes.SetActive(false);
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