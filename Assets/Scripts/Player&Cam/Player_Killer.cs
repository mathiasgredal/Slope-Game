using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Killer : MonoBehaviour
{
    public delegate void Retry();
    public Retry OnRetryMap;
    public bool godMode = false;
    public static bool dead = false;
    public static bool hitKillzone = false;
    public static bool fallenOutOfMap = false;
    bool fallenOutOfMapActivator = true;
    public float timeBetweenFallenOfMapAndDead;
    public GameObject deathParticle;

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            if (collision.contacts[i].otherCollider.gameObject.tag == "KillZone")
            {
                hitKillzone = true;
            }
        }
    }

    void Update()
    {
        if (!godMode)
        {
            if (hitKillzone)
            {
                StartCoroutine(HitKillzoneAnimation());
            }
        }
        if (fallenOutOfMap && fallenOutOfMapActivator)
        {
            StartCoroutine(FallenOutOfMapAnimation());
            //FallenOutOfMapAnimation();
        }

    }

    void MakeParticleEffect()
    {
        GameObject deathParticleCopy = Instantiate(deathParticle, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(deathParticleCopy, 2);
    }

    IEnumerator HitKillzoneAnimation()
    {
        hitKillzone = false;
        GameObject.Find("Player Graphic").GetComponent<MeshRenderer>().enabled = false;
        Rigidbody rb = this.GetComponent<Rigidbody>();// getting the rigidbody component
        rb.isKinematic = true;
        MakeParticleEffect();
        yield return new WaitForSeconds(1.5f);
        Death();
    }

    IEnumerator FallenOutOfMapAnimation()
    {
        fallenOutOfMapActivator = false;
        yield return new WaitForSeconds(timeBetweenFallenOfMapAndDead);
        fallenOutOfMap = false;
        fallenOutOfMapActivator = true;
        Death();
        yield return new WaitForSeconds(1);
        Rigidbody rb = this.GetComponent<Rigidbody>();// getting the rigidbody component
        rb.isKinematic = true;
    }

    void Death()
    {
        ApplyScore applyScore = FindObjectOfType<ApplyScore>();
        applyScore.SetScore();
        LeaderBoardData.leaderboard.SetScore();
        Killscreen_Manager.MakeKillscreen();
        if (LeaderBoardData.leaderboard.autoApplyToLeaderboard)
            LeaderBoardData.leaderboard.AddHighScoreAutonomus();
        transform.GetChild(0).gameObject.layer = 9;
    }

    void RetryMap()
    {
        if (OnRetryMap != null)
        {
            OnRetryMap();
        }
        Rigidbody rb = this.GetComponent<Rigidbody>();// getting the rigidbody component
        GameObject.Find("Player Graphic").GetComponent<MeshRenderer>().enabled = true;
        rb.isKinematic = false;
    }

}
