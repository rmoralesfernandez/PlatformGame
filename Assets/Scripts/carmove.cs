using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carmove : MonoBehaviour
{

    public Transform _respawnTransform;
    public Animator _animator;
    public float _speed = 30;
    public Rigidbody2D _rigidBody;
    public float _force = 5;
    private bool _grounded;
    public BoxCollider2D _footcollider;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    // Use this for initialization
    private bool _isDead = false;
    public void Dead()
    {
        if(TakeItemManager.PowerF == true)
        {
            TakeItemManager.PowerF = false;
        } else
        {
            _isDead = true;
            _rigidBody.gravityScale = 0f;
            _rigidBody.velocity = Vector2.zero;
            _animator.SetTrigger("Death");
            deathSound.Play();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (_isDead)
        {
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);
            transform.localScale = Vector3.one;
            _animator.SetFloat("walk", 1f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("walk", 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * _speed * Time.deltaTime, Space.Self);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            _animator.SetFloat("walk", 1f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("walk", 0f);
        }
        if (Input.GetKeyDown(KeyCode.W) && _grounded)
        {
            jumpSound.Play();
            _rigidBody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _animator.SetTrigger("jump");
        }
        Collider2D[] collider2D = Physics2D.OverlapBoxAll((Vector2)_footcollider.transform.position + _footcollider.offset, _footcollider.size, 0f);
        _grounded = false;
        for (int i = 0; i < collider2D.Length && !_grounded; i++)
        {
            if (collider2D[i].tag != "Player")
            {
                _grounded = collider2D != null ? !collider2D[i].isTrigger : false;
            }
        }
        _animator.SetBool("grounded", _grounded);
        _animator.SetFloat("fall", _rigidBody.velocity.y);

    }




    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + col.gameObject.tag + " : " + Time.time);
        if (col.gameObject.tag == "Respawn")
        {
            this.transform.position = _respawnTransform.position;
        }
    }

}
