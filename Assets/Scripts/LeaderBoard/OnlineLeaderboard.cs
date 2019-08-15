using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineLeaderboard : MonoBehaviour
{

    public Transform rank;
    public Transform contentParent;


    // Use this for initialization
    void Start()
    {
        AdjustScrollBar();
        for (int i = 0; i < 1000; i++)
        {
            AddHighscore();
        }
        PerfomenceOptimizations(1);
    }

    public void PerfomenceOptimizations(float scrollY)
    {
        float upperScore = (contentParent.childCount * scrollY - contentParent.childCount) * -1 - (12.5f / 100 * (100 - scrollY * 100));

        for (int i = Mathf.FloorToInt(upperScore + 1); i < contentParent.childCount; i++)
        {
            if (i - Mathf.FloorToInt(upperScore + 1) < 16)
                contentParent.GetChild(i).gameObject.SetActive(true);
            else
                contentParent.GetChild(i).gameObject.SetActive(false);


        }

        for (int i = Mathf.FloorToInt(upperScore - 3) - 1; i >= 0; i--)
        {
            contentParent.GetChild(i).gameObject.SetActive(false);
        }

        contentParent.GetChild(0).gameObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AddHighscore();

    }

    void AddHighscore(string username = "hej", int score = 23, string date = "0")
    {
        Transform rankcopy = Instantiate(rank, new Vector3(0, 0), Quaternion.identity, contentParent) as Transform;
        rankcopy.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        rankcopy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(rankcopy.gameObject.GetComponent<RectTransform>().anchoredPosition.x, (contentParent.childCount - 1) * -50);
        AdjustScrollBar();
        SetRank(rankcopy.gameObject);
    }

    void AdjustScrollBar()
    {
        contentParent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(contentParent.gameObject.GetComponent<RectTransform>().sizeDelta.x, (contentParent.childCount) * 50);
    }

    void SetRank(GameObject rankcopy)
    {
        rankcopy.transform.GetChild(0).GetComponent<Text>().text = contentParent.childCount + ".";
    }
}
