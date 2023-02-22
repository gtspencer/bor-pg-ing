using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/OnlinePost")]
public class OnlinePostScriptableObject : ScriptableObject
{
    public string title;
    public string body;

    public int likes;

    // used by Online NPCs to comment on this post
    public List<string> nicePossibleReponses;
    public List<string> neutralPossibleResponses;
    public List<string> meanPossibleResponses;

    // list of all used responses (currently displayed) including player responses
    public List<string> currentResponses;
}
