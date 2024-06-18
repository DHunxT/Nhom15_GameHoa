using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>()) {
            GetComponent<PickupSpawner>().DropItems();
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.bushClip);
            Destroy(gameObject);
        }
    }
}
