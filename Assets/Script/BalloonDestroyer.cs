using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    public float destroyY = 4.4f;
    public int pointValue = 0;
    public AudioClip popSound;
    public AudioClip riseSound;
    public GameObject popEffectPrefab;

    private AudioSource audioSource;
    private bool isDestroyed = false;

    void Start()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDestroyed) return;

        if (transform.position.y > destroyY)
        {
            if (riseSound != null)
            {
                audioSource.PlayOneShot(riseSound);
            }

            if (pointValue > 0)
            {
                ScoreManager.Instance.SubtractScore(1);
            }

            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        if (isDestroyed) return;

        if (pointValue < 0)
        {
            ScoreManager.Instance.SubtractScore(-pointValue);
        }
        else
        {
            ScoreManager.Instance.AddScore(pointValue, gameObject.name);
        }

        if (popSound != null)
        {
            audioSource.PlayOneShot(popSound);
        }

        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }

        isDestroyed = true;
        Destroy(gameObject);
    }
}