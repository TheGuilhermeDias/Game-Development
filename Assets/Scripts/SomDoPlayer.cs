using UnityEngine;

public class SomDoPlayer : MonoBehaviour
{
    public AudioClip somDoPulo;
    public AudioClip somDano;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarSomPulo()
    {
        audioSource.PlayOneShot(somDoPulo);
    }

    public void TocarSomDano()
    {
        audioSource.PlayOneShot(somDano);
    }
}
