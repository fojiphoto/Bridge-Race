using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTileSound : MonoBehaviour
{
    public AudioClip Set_step;
    public AudioSource audio_source;
        public void Bajao()
    {
        audio_source.PlayOneShot(Set_step);
    }

}
