using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Storage[] storages;

    [SerializeField]
    private Transform[] idolSpawnPositions;
    [SerializeField]
    private IdolSpawnInformations[] idolInformations;
    [SerializeField]
    private float idolSpawnDelay = 3;
    [SerializeField]
    private float nextIdolSpawn;


    void Start()
    {
        this.nextIdolSpawn = Time.time;
    }

    void Update()
    {
        if(Time.time >= this.nextIdolSpawn)
        {
            this.Spawn();
        }
    }


    private void Spawn()
    {
        IdolSpawnInformations infos = this.idolInformations.GetWeightedRandom();
        GameObject obj = Object.Instantiate<GameObject>(infos.prefab);
        if (obj)
        {
            Idol idol = obj.GetComponent<Idol>();
            if (idol)
            {
                Transform spawnPosition = this.idolSpawnPositions.GetRandom();
                obj.transform.position = spawnPosition.position;
            }
            else
            {
                Object.Destroy(obj);
            }
        }
        this.nextIdolSpawn += this.idolSpawnDelay;
    }


    [System.Serializable]
    public class IdolSpawnInformations
    {
        public GameObject prefab;
        public int propabilityFactor;
    }
}


public static partial class ExtensionMethods
{
    public static Game.IdolSpawnInformations GetWeightedRandom(this Game.IdolSpawnInformations[] self)
    {
        if (self.Length > 0)
        {
            int total = 0;
            foreach (Game.IdolSpawnInformations infos in self)
            {
                total += infos.propabilityFactor;
            }

            int random = Random.Range(0, total);
            int current = 0;
            foreach (Game.IdolSpawnInformations infos in self)
            {
                Debug.Log("random: " + random + "; current: " + current + "; total: " + total + "; current factor: " + infos.propabilityFactor);
                if (random - current < infos.propabilityFactor)
                {
                    return infos;
                }
                else
                {
                    current += infos.propabilityFactor;
                }
            }
            return null;
        }
        else
        {
            return null;
        }
    }
}
