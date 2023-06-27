using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponentOld : MonoBehaviour, IShootComponent
{

    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform outBullet;
    //private GameObject currentBullet;
    private Rigidbody currentBulletVelocity;

    //public GameObject Bullet;
    public float ShootDelay;
    private float shootTime = float.MinValue;
    //
    [SerializeField] private ParticleSystem gunParticle;//������� ������
    [SerializeField] private ParticleSystem gunExitParticle;//������� ������

    void IShootComponent.Shoot()
    {
        if (Time.time < shootTime + ShootDelay)
        {
            return;
        }
        else
        {
            shootTime = Time.time;
        }

        if (gunParticle != null & gunExitParticle != null)
        {

            currentBulletVelocity = Instantiate(bullet, outBullet.position, outBullet.rotation);
            currentBulletVelocity.AddForce(outBullet.up * bulletSpeed,ForceMode.Force);
            //


            gunParticle.Play();//��� ������� �������� ��������� ������� ������
            gunExitParticle.Play();
        }
        else
        {
            Debug.Log($"{gunParticle} � {gunExitParticle} �� ��������");
        }
    }


}
