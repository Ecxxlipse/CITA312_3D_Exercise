using UnityEngine;
using UnityEngine.InputSystem;

public class StateFXPractice : MonoBehaviour
{
    [SerializeField] ParticleSystem practiceFX;
    [SerializeField] AudioClip Main;
    AudioSource audioSource;
    bool effectActive = false;
    public InputAction ParticlePlay;
    public InputAction ParticleStop;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void OnEnable()
    {
        ParticlePlay.Enable();
        ParticleStop.Enable();
    }

    void OnDisable()
    {
        ParticlePlay.Disable();
        ParticleStop.Disable();
    }
    void RespondToDebugKeys()
    {
        // P: start the effect only if it is not already active
        float p = ParticlePlay.ReadValue<float>();
        if (p > 0 && effectActive == false)
        {
            audioSource.PlayOneShot(Main);
            ActivateEffect();
        }
        
        // R: reset the practice state and stop the particles
        float r = ParticleStop.ReadValue<float>();
        if (r > 0 && effectActive == true)
        {
            ResetEffect();
        }
    }
    void ActivateEffect()
    {
        // set the state
        practiceFX.Play();

        // play the particles
        effectActive = true;

        // print a useful Console message
        Debug.Log("Particle effect is active");
    }
    void ResetEffect()
    {
        // reset the state
        practiceFX.Stop();

        // stop the particles
        effectActive = false;

        // print a useful Console message
        Debug.Log("Particle effect is deactivated");
    }
}