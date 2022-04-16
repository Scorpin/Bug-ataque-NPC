using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDView : MonoBehaviour {

    [SerializeField] private UIHUDBar _uIHealthBar;
    [SerializeField] private UIHUDBar _uIEssenceBar;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void UpdateHealth(float modifier) {

        _uIHealthBar.UpdateHealthBar(modifier);

    }

    public void UpdateEssence(float modifier) {

        _uIEssenceBar.UpdateHealthBar(modifier);

    }

}