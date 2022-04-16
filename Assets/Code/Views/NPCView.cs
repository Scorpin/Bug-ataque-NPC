using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCView : MonoBehaviour {

    //Para pasar a modelos de datos para configurar, posiblemente ScriptedObjects.
    /*[SerializeField] private float _nPCSpeed;
    [SerializeField] private float _nPCAcceleration;*/

    [SerializeField] private Animator _childAnimator;
    [SerializeField] private SpriteRenderer _childSpriteRenderer;
    [SerializeField] private GameObject _attack1GOTrigger;
    [SerializeField] private GameObject _targetToFollow;

    //private NavMeshAgent _agent;
    private bool _isTouchingPlayer = false;
    private BoxCollider2D _attack1BoxCollider;

    // Start is called before the first frame update
    void Start() {

        /*_agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _agent.speed = _nPCSpeed;
        _agent.acceleration = _nPCAcceleration;*/

        _attack1BoxCollider = _attack1GOTrigger.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update() {

        //Debug.Log("Z: " + transform.position.z);
        //Arreglo del NavMeshAgent, que al parecer añade un "+1.1" en la Z desde el primer Update, sin razón aparente.
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //_agent.SetDestination(_targetToFollow.transform.position);

        //Debug.Log("Next path position x: " + _agent.destination.x + " y " + transform.position.x);

        //Flip o no del sprite animado del personaje.
        if (_targetToFollow.transform.position.x < transform.position.x) {

            _childSpriteRenderer.flipX = true;
            _attack1BoxCollider.offset = new Vector2(-1 * Mathf.Abs(_attack1BoxCollider.offset.x), _attack1BoxCollider.offset.y);

        }
        else if (_targetToFollow.transform.position.x > transform.position.x) {

            _childSpriteRenderer.flipX = false;
            _attack1BoxCollider.offset = new Vector2(Mathf.Abs(_attack1BoxCollider.offset.x), _attack1BoxCollider.offset.y);

        }

        /*if (_agent.velocity != Vector3.zero) {

            _childAnimator.SetBool("IsWalking", true);

        }
        else {

            _childAnimator.SetBool("IsWalking", false);

        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        switch (collision.tag) {
            case "Player":
                _isTouchingPlayer = true;
                AttackMode();
                break;
            case "PlayerAttack1":
                Debug.Log("NPC: attacked from player. NPC disabled.");
                //GetComponent<NavMeshAgent>().enabled = false;
                //Destroy(GetComponent<NavMeshAgent>());
                //_attack1BoxCollider.enabled = false;
                //Destroy(_attack1BoxCollider);
                //_attack1GOTrigger.layer = LayerMask.NameToLayer("Invisible");
                _attack1GOTrigger.SetActive(false);
                //gameObject.layer = LayerMask.NameToLayer("Invisible");
                gameObject.SetActive(false);
                //Bug: OnTriggerEnter se activa una segunda vez si es destruido mientras está activo.
                //Destroy(gameObject);
                //Destroy(_attack1GOCollider);
                break;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {

        switch (collision.tag) {
            case "Player":
                _isTouchingPlayer = false;
                break;
        }

    }

    private void AttackMode() {

        //_agent.isStopped = true;
        _childAnimator.SetTrigger("Attack");
        //Debug.Log("Gorgona: Se inicia modo de ataque.");
        //Invoke("RepeatAttackOrMove", 1.4f);

    }

    public void ActiveAttack() {

        Debug.Log("NPC: Attack activated.");
        _attack1GOTrigger.SetActive(true);

    }

    public void DisableAttack() {

        _attack1GOTrigger.SetActive(false);

    }

    public void RepeatAttackOrMove() {

        if (_isTouchingPlayer) {

            AttackMode();

        }
        else {

            MoveMode();

        }

    }

    private void MoveMode() {

        //_agent.isStopped = false;

    }

}