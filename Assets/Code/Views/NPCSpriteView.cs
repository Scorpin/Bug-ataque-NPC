using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpriteView : MonoBehaviour {

    [SerializeField] private NPCView _nPCViewContainer;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ActiveAttack() {

        _nPCViewContainer.ActiveAttack();

    }

    public void DisableAttack() {

        _nPCViewContainer.DisableAttack();

    }

    public void AnimationFinished() {

        _nPCViewContainer.RepeatAttackOrMove();

    }

}