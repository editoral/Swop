using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverForm : PlayerForm
{

    void PlayerForm.executeAbility(PlayerStats stats)
    {
        Player player = stats.getPlayer();
        Sound sound = player.GetComponent<Sound>();
        sound.PlayAttack();
        Collider2D coll = player.attackCollider.GetComponent<Collider2D>();
        coll.enabled = true;
        Animator ani = player.GetComponent<Animator>();
        ani.SetBool("attacking", true);
    }

}
