using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip click, hover;
    private AudioSource source;
    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
    }
    public void DoHover() {
        source.PlayOneShot(hover);
    }

    public void DoClick() {
        source.PlayOneShot(click);
    }
}
