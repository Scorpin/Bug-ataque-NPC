using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReceiver : MonoBehaviour {

    public bool _fixedVelocity;

    private PlayerController _playerController;
    private bool _movUp, _movRight, _movDown, _movLeft;
    private float _movX, _movY;

    void Start() {

    }

    public void Configure(PlayerController playerController) {

        _playerController = playerController;

    }

    void Update() {

        if (_fixedVelocity) {

            //3 factores necesarios en el if: si sólo hay 1 dirección pulsada se va hacia ahí; si está también la contraria se cancelan; y si hay de ambos vectores, se hacen al 70.71% ambos.

            _movUp = Input.GetButton("Up");
            _movRight = Input.GetButton("Right");
            _movDown = Input.GetButton("Down");
            _movLeft = Input.GetButton("Left");

            if (_movUp || _movRight || _movDown || _movLeft) {

                if (_movRight && _movLeft) {
                    _movX = 0;
                }
                else if (_movRight && !_movLeft) {
                    _movX = 1;
                }
                else if (!_movRight && _movLeft) {
                    _movX = -1;
                }
                if (_movUp && _movDown) {
                    _movY = 0;
                }
                else if (_movUp && !_movDown) {
                    _movY = 1;
                }
                else if (!_movUp && _movDown) {
                    _movY = -1;
                }

                //Excepciones para diagonales
                if (_movRight && _movUp) {
                    _movX = _movY = 0.7071f;
                }
                else if (_movRight && _movDown) {
                    _movX = 0.7071f;
                    _movY = -0.7071f;
                }
                else if (_movLeft && _movDown) {
                    _movX = _movY = -0.7071f;
                }
                else if (_movLeft && _movUp) {
                    _movX = -0.7071f;
                    _movY = 0.7071f;
                }

                if (!_movUp && !_movDown) {
                    _movY = 0;
                }
                if (!_movRight && !_movLeft) {
                    _movX = 0;
                }

            }
            else {

                _movX = 0;
                _movY = 0;

            }

        }
        else {

            _movX = Input.GetAxis("Horizontal");
            _movY = Input.GetAxis("Vertical");

        }

        if (Input.GetMouseButtonDown(0)) {

            _playerController.Attack1();

        }

        //Intentar optimizarlo utilizando propiedades y actualizándolo en el set.
        UpdatePlayerVelocity(_movX, _movY);

    }

    private void UpdatePlayerVelocity(float movX, float movY) {

        _playerController.UpdateVelocity(movX, movY);

    }

}