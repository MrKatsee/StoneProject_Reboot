using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    Vector3 originPos;
    Player player;

    void Start()
    {
        originPos = transform.localPosition;
        player = FindObjectOfType<Player>();
    }

    //임시
    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;
    }

    //임시
    public GameObject hitEffectPrefab;
    public void HitEffect(Vector2 _position)
    {
        Instantiate(hitEffectPrefab, _position, Quaternion.identity);
    }

    private void Update()
    {
        Vector3 vec = player.transform.position;
        vec = new Vector3(vec.x, vec.y, transform.position.z);
        transform.position = vec;
    }
}

