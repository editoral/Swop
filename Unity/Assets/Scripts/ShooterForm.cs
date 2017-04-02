using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterForm : PlayerForm {

    void PlayerForm.executeAbility(PlayerStats stats)
    {
        Player player = stats.getPlayer();
        Sound sound = player.GetComponent<Sound>();
        sound.PlayAttack();
        Vector2 viewDirection = stats.getViewDirection();
        Vector3 origin = player.transform.position;
        GameObject bulletObj = player.bullet;
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.setMovement(viewDirection.normalized);
        GameObject.Instantiate(bulletObj, origin, Quaternion.identity);
    }

}
