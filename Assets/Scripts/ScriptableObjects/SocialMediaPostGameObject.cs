using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialMediaPostGameObject : MonoBehaviour
{
    private OnlinePostScriptableObject onlinePost;
    
    [SerializeField] private Text titleText;
    [SerializeField] private Text bodyText;

    public void SetPost(OnlinePostScriptableObject onlinePost)
    {
        this.onlinePost = onlinePost;

        titleText.text = onlinePost.title;
        bodyText.text = onlinePost.body;
    }
}
