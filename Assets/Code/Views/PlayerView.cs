using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private Animator _childAnimator;
    [SerializeField] private SpriteRenderer _childSpriteRenderer;
    [SerializeField] private GameObject _attack1GOTrigger;

        // Control de PV y SP
    //[SerializeField] private Text _hpText;
    //[SerializeField] private UIHUDBar uIHealthBar;

    private Rigidbody2D _rb2d;
    private float _movX, _movY;
    private BoxCollider2D _attack1BoxCollider;

    public int hp;



    /*protected Vector3 mousePosition, directionVector;
    protected Quaternion tempLookAt;*/

    private void Start() {

        _rb2d = GetComponent<Rigidbody2D>();

        //_childAnimator = GetComponentInChildren<Animator>();
        //_childSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _attack1BoxCollider = _attack1GOTrigger.GetComponent<BoxCollider2D>();

        hp = 100;

    }

    // Update is called once per frame
    protected virtual void Update() {

        //Flip o no del sprite animado del personaje.
        if (_movX < 0) {

            _childSpriteRenderer.flipX = true;
            _attack1BoxCollider.offset = new Vector2(-1 * Mathf.Abs(_attack1BoxCollider.offset.x), _attack1BoxCollider.offset.y);

        }
        else if (_movX > 0) {

            _childSpriteRenderer.flipX = false;
            _attack1BoxCollider.offset = new Vector2(Mathf.Abs(_attack1BoxCollider.offset.x), _attack1BoxCollider.offset.y);

        }

        //Transición de la animación Walking.
        if (_movX != 0 || _movY != 0) {

            /*_childAnimator.SetBool("IsWalking", true);
            _childAnimator.SetFloat("SpeedMultiplier", _rb2d.velocity.magnitude / _speed);*/

        }
        else {

            /*_childAnimator.SetBool("IsWalking", false);
            _childAnimator.SetFloat("SpeedMultiplier", 1f);*/

        }

        /*mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        directionVector = (mousePosition - transform.position).normalized;
        tempLookAt = Quaternion.LookRotation(directionVector, Vector3.back);
        transform.rotation = new Quaternion(0, 0, tempLookAt.z, tempLookAt.w);*/
        //Debug.Log("Posición del ratón: " + mousePosition + ". Normalizada: " + directionVector);


    }

    public void UpdateVelocity(float movX, float movY) {

        _movX = movX;
        _movY = movY;

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        //Debug.Log("Jugador: Colisión detectada por: " + collision.name + ", con ID: " + collision.GetInstanceID());
        Debug.Log("Player: " + collision.tag + " entered.");
        switch (collision.tag) {
            case "NPCAttack1":
                this.hp -= 10;
                Debug.Log("Player: attacked from NPC. Left " + hp.ToString() + " HP.");
                //Debug.Log("Jugador: Me ha atacado: " + collision.name + ", con ID: " + collision.GetInstanceID());
                //this._hpText.text = hp.ToString();
                //uIHealthBar.UpdateHealthBar((float)this.hp / 100);
                break;
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {

        if (collision.tag == "NPCAttack1") {
            //Debug.Log(collision.tag + " se mantiene.");
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {

        Debug.Log("Player: " + collision.tag + " is left.");

    }

    public void EnableAttack(float timeToDisable) {

        _attack1GOTrigger.SetActive(true);
        Invoke("DisableAttack", timeToDisable);

    }

    private void DisableAttack() {

        _attack1GOTrigger.SetActive(false);

    }

    private void FixedUpdate() {

        _rb2d.velocity = new Vector2(_movX * _speed, _movY * _speed);
        //Debug.Log("Se mueve a: X: " + movX + ", e Y: " + movY);

    }

    public void ObjectPicked() {

        Debug.Log("Objeto recogido.");

    }

}