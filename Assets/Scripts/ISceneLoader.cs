using System;

public interface ISceneLoader
{
    public void Load(string sceneName, Action onLoad = null);
}