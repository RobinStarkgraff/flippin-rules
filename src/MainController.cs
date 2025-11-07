namespace FlippinRules;

using Godot;

public partial class MainController : Node2D
{
    private const string IconScenePath = "res://scenes/icon.tscn";

    private Node _iconSceneInstance;

    public override void _Ready()
    {
        var iconScene = GD.Load<PackedScene>(IconScenePath);
        _iconSceneInstance = iconScene.Instantiate();
        AddChild(_iconSceneInstance);
    }

    public void RemoveIconScene()
    {
        if (_iconSceneInstance != null)
        {
            _iconSceneInstance.QueueFree();
            _iconSceneInstance = null;
        }
    }
}
