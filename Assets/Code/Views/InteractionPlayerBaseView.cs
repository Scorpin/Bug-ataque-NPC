using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayerBaseView : MonoBehaviour {

    [SerializeField] private PlayerView _playerViewContainer;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        //Debug.Log("Detecta PickableObject.");
        if (collision.tag == "PickableObject") {

            _playerViewContainer.ObjectPicked();

        }

    }

}