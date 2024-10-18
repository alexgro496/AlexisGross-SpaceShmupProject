using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Inscribed")]
    public float rotationsPerSecond = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0;

    Material mat;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start(){
        mat = GetComponent<Renderer>().material;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);

        if(levelShown != currLevel){
            levelShown = currLevel;
            PlayDamageSound();

            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }

        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }

    private void PlayDamageSound() {
        if (audioSource != null) {
            // audioSource.clip = audioSource;
            audioSource.Play();
        }
    }
}
