using UnityEngine;

public class DanoAoTocar : MonoBehaviour
{
    public int dano = 1;

    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Algo entrou em contato com o espinho: " + collision.name);

    if (collision.CompareTag("Player"))
    {
        collision.GetComponent<Personagem>().TomarDano(dano);
    }
}

    
}
