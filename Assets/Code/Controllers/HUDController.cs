using System.Collections;
using System.Collections.Generic;

public class HUDController {

    private HUDView _hUDView;

    public HUDController(HUDView hUDView) {

        _hUDView = hUDView;

    }

    public void UpdateHealth(float modifier) {

        _hUDView.UpdateHealth(modifier);

    }

    public void UpdateEssence(float modifier) {

        _hUDView.UpdateEssence(modifier);

    }

}