using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMedia : MonoBehaviour
{
    [SerializeField] private GameObject postPrefab;

    [SerializeField] private GameObject postParent;

    // temporary, npc day to day behaviour manager will run npc update loop, and if npcs have access to social media,
    // they will find this class and add a new post
    [SerializeField] private List<OnlinePostScriptableObject> posts;
    // Start is called before the first frame update
    void Start()
    {
        if (postPrefab == null)
            postPrefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Post");

        foreach (OnlinePostScriptableObject post in posts)
        {
            AddPost(post);
        }
    }

    public void AddPost(OnlinePostScriptableObject newPost)
    {
        var postInstance = Instantiate(postPrefab, parent: postParent.transform);

        var postGameObject = postInstance.GetComponent<SocialMediaPostGameObject>();
        postGameObject.SetPost(newPost);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }
}
