using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class IntroCameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 pos;

    [SceneName]
    public string nextLevel;
    private AudioSource mAudio;
    private AudioSource audio {
        get
        {
            if(this.mAudio == null)
            {
                this.mAudio = GetComponent<AudioSource>();
            }
            return this.mAudio;
        }
    }

    IEnumerator Start()
    {
        pos = transform.position;

        yield return new WaitForSeconds(audio.clip.length + 1);

        Application.LoadLevel(nextLevel);
    }

    void Update()
    {
        float newPosition = Mathf.SmoothStep(pos.x, target.position.x, Time.timeSinceLevelLoad / audio.clip.length);

        transform.position = new Vector3(newPosition, pos.y, pos.z);
    }
}
