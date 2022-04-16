using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameInstaller : MonoBehaviour {

    [SerializeField] private InputReceiver _inputReceiver;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private HUDView _hUDView;

    //private FadeFullscreenPresenter _presenterToFadeFullscreen;

    private void Awake() {

        /*var inputMapUIMainMenu = ServiceLocator.Instance.GetService<InputMap>().UIMainMenu;
            
        inputMapUIMainMenu.SetCallbacks(_viewMainMenu);

        var inputMapGameplayCity = ServiceLocator.Instance.GetService<InputMap>().GameplayCity;

        inputMapGameplayCity.SetCallbacks(_viewInputReceiverCity);

        var inputMapGameplayCombat = ServiceLocator.Instance.GetService<InputMap>().GameplayCombat;

        inputMapGameplayCombat.SetCallbacks(_viewInputReceiverCombat);

        var inputMapGameplayDialogue = ServiceLocator.Instance.GetService<InputMap>().GameplayDialogue;

        inputMapGameplayDialogue.SetCallbacks(_viewDialogue);*/

        //_presenterToFadeFullscreen = new FadeFullscreenPresenter(_viewToFadeFullscreen);
        //var presenterMainGame = new MainGamePresenter(_viewMainGame, _viewCity);

        /*var uCPlayerRepo = new PlayerRepo();

        var uCCreateNewGame = new CreateNewGame(uCPlayerRepo, presenterMainGame);*/

        //HUDController Configuration
        var hUDController = new HUDController(_hUDView);

        //PlayerController Configuration
        var playerController = new PlayerController(_playerView, hUDController);
        _inputReceiver.Configure(playerController);

        Init();

    }

    private void Init() {

        //For developing start
        //_presenterToFadeFullscreen.ShowView();
        //_viewMainMenu.Show();
        //For developing end
        //await _presenterToFadeFullscreen.FadeIn();
        //_viewMainMenu.EnableInputs();

    }

    private void OnDestroy() {

    }

}