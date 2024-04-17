using System;
using UnityEngine.AddressableAssets;

public class SceneLoader : ISceneLoader
{
    private readonly ICoroutineRunner coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        this.coroutineRunner = coroutineRunner;
    }


    public async void Load(string sceneName, Action onLoad = null)
    {
        var loading = Addressables.LoadSceneAsync(sceneName);
        if (loading.Task != null) await loading.Task;
        onLoad?.Invoke();
    }
}