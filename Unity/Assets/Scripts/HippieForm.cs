using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippieForm : PlayerForm
{

    void PlayerForm.executeAbility(PlayerStats stats)
    {
        stats.stopTheGangsters();
    }

}
