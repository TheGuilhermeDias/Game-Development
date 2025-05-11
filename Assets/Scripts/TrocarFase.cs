using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarFase : MonoBehaviour
{
    [SerializeField] private string nomeCena; // Nome da próxima cena

    private void OnTriggerEnter2D(Collider2D cenas)
    {
        if (cenas.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}
