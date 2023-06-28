using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{

    public override void Attack()
    {
        if (_currentShotCooldown <= 0 && _currentBulletCount > 0)
        {
            m_shootingSound.Play();
            var bullet = Instantiate(BulletPrefab, transform.position + transform.forward * 2, transform.rotation);
            bullet.GetComponent<Bullet>().SetOwner(this);
            _currentShotCooldown = ShotCooldown;
            _currentBulletCount--;
            hudBullet(_currentBulletCount, MaxBulletCount);
        }
    }

    public override void Reload() => base.Reload();
    
}

