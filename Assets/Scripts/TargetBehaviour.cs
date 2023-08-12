using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] string[] _tags;
    [SerializeField] Sprite[] _sprites;

    private void Start()
    {
        int randIndex = Random.Range(0, _tags.Length);
        tag = _tags[randIndex];
        GetComponent<SpriteRenderer>().sprite = _sprites[randIndex];

        transform.Rotate(0,0,Random.Range(0,360));
    }
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime * GameManager.Single.Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            GameManager.Single.Score++;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            GameManager.Single.LostLive();
        }
    }
}
