namespace FlippinRules;

using Godot;
using System.Collections.Generic;

public partial class SceneController : Node2D
{
    private List<Node> _loadedScenes;

    public override void _Ready()
    {
        _loadedScenes = new List<Node>();
    }

    public Node LoadScene(string scenePath)
    {
        PackedScene packedScene = GD.Load<PackedScene>(scenePath);

        if (packedScene == null)
        {
            return null;
        }

        Node instance = packedScene.Instantiate();
        AddChild(instance);
        _loadedScenes.Add(instance);

        return instance;
    }

    public void UnloadScene(Node sceneInstance)
    {
        if (sceneInstance == null)
        {
            return;
        }

        if (!sceneInstance.IsInsideTree() || sceneInstance.GetParent() != this)
        {
            return;
        }

        _loadedScenes.Remove(sceneInstance);
        sceneInstance.QueueFree();
    }
}
