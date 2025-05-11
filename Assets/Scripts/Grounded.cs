using UnityEngine;

public class Grounded : MonoBehaviour
{
    Personagem Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<Personagem>();
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.layer == 8)
        {
            Player.isGrounded = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisor)
    {
        if (collisor.gameObject.layer == 8)
        {
            Player.isGrounded = true;
        }
    }
}
