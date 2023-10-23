using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool IsOnGround = true;
    public bool GameOver;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;

    private Rigidbody _playerRb;
    private Animator _playeranimation;
    private AudioSource _playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playeranimation = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            _playeranimation.SetTrigger("Jump_trig");
            DirtParticle.Stop();
            _playerAudio.PlayOneShot(JumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            DirtParticle.Play();
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            GameOver = true;
            _playeranimation.SetBool("Death_b", true);
            _playeranimation.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            DirtParticle.Stop();
            _playerAudio.PlayOneShot(CrashSound, 1.0f);
        }
    }
}
