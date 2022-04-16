using System.Collections;
using System.Collections.Generic;

public class PlayerController {

    private PlayerView _playerView;
    private HUDController _hUDController;
    protected bool canAtkPrincipal;

    public PlayerController(PlayerView playerView, HUDController hUDController) {

        _playerView = playerView;
        _hUDController = hUDController;

    }

    public void UpdateVelocity(float movX, float movY) {

        _playerView.UpdateVelocity(movX, movY);

    }

    public void Attack1() {

        _playerView.EnableAttack(0.5f);

    }

    public void UpdateHealth(float modifier) {

        _hUDController.UpdateHealth(modifier);
        //TODO: Llevar el conteo de salud total, estado del juego, quizás en otro controller, etc.

    }

    public void UpdateEssence(float modifier) {

        _hUDController.UpdateEssence(modifier);
        //TODO: Llevar el conteo de esencia total, capacidad para utilizar ataque especial o no, quizás en otro controller, etc.

    }

}