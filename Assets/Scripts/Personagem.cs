using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public TextMeshProUGUI vidaTexto;
    public AudioClip somDoPulo;
    public AudioClip somDano;
    private AudioSource audioSource;

    public int moedas = 0;
    public TextMeshProUGUI moedasTexto;
    public AudioClip somMoeda;

    public int vidaMaxima = 3;
    private int vidaAtual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        vidaAtual = vidaMaxima;
        vidaAtual = vidaMaxima;
        AtualizarVidaUI(); // já inicia com a vida atual mostrada
        audioSource = GetComponent<AudioSource>();
        moedas = 0;
        AtualizarMoedasUI();



    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioSource.PlayOneShot(somDoPulo);
        }

        // virar personagem
        if (moveInput != 0)
            sprite.flipX = moveInput < 0;

        // Animação 
        anim.SetBool("correndo", moveInput != 0);
        anim.SetBool("pulando", !isGrounded);
    }

    //visualizar o groundCheck
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }
    }

    // tomar dano
    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        AtualizarVidaUI();
        audioSource.PlayOneShot(somDano); // 🔊 aqui toca o som de dano

        Debug.Log("Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }
    void Morrer()
    {
        Debug.Log("Personagem morreu!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        //Debug.Log("isGrounded: " + isGrounded);

    }
    void AtualizarMoedasUI()
    {
        if (moedasTexto != null)
        {
            moedasTexto.text = "Moedas: " + moedas;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moeda"))
        {
            moedas++;
            AtualizarMoedasUI();

            if (somMoeda != null)
            {
                audioSource.PlayOneShot(somMoeda);
            }

            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        
    }



    void AtualizarVidaUI()
    {
        if (vidaTexto != null)
        {
            vidaTexto.text = "Vida: " + vidaAtual;
        }
    }
}
