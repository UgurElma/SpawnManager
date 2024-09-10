using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Spawn Settings")]
    public bool isSpawn;
    public float spawnTime;
    public Color spColor;
    [Header("Spawn Object Settings")]
    public Vector3 offsetPos;
    public Vector3 offsetRot;
    public Vector3 objectScale;
    [Header("Destroy Settings")]
    public bool withTime;
    public float destroyTime;
    GameObject spawnObjects, spawnObject, spawnTimer, spawnColor, spawnRotation;
    float spawnSpeed = 0;
    private void Start()
    {
        spawnObjects = transform.Find("Spawn Objects").gameObject;
        spawnObject = transform.Find("Spawn Object").gameObject;
        spawnTimer = transform.Find("Center").gameObject;
        spawnColor = transform.Find("Spawn Color").gameObject;
        spawnRotation = transform.Find("Spawn Rotation").gameObject;
        spawnColor.GetComponent<SpriteRenderer>().color = spColor;
    }

    private void Update()
    {
        if (isSpawn)
        {
            spawnSpeed += Time.deltaTime;
            spawnTimer.transform.localScale = new Vector3((1 - spawnSpeed / spawnTime), 0.2f, 1);
            if (spawnTime <= spawnSpeed)
            {
                GameObject go = Instantiate(spawnObject, spawnRotation.transform.position, spawnRotation.transform.rotation, spawnObjects.transform);
                go.SetActive(true);
                go.transform.localScale = objectScale;
                if (withTime)
                    Destroy(go, destroyTime);
                Debug.Log("Bitti");
                spawnSpeed = 0;
            }
        }
        else
        {
            spawnRotation.transform.localPosition = new Vector3(offsetPos.x, offsetPos.y, offsetPos.z);
            spawnRotation.transform.localRotation = Quaternion.Euler(offsetRot.x, offsetRot.y, offsetRot.z);
        }
    }
}
