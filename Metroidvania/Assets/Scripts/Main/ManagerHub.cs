public static class ManagerHub
{
    private static MapManager m_mapManager;
    private static PlayerSceneManager m_plscManager;
    private static ManagerSceneManager m_mnManager;

    public static MapManager GetMapManager() => m_mapManager;
    public static PlayerSceneManager GetPlayerSceneManager() => m_plscManager;
    public static ManagerSceneManager GetManagerSceneManager() => m_mnManager;

    public static void SetMapManager(MapManager manager) => m_mapManager = manager;
    public static void SetPlayerSceneManager(PlayerSceneManager manager) => m_plscManager = manager;
    public static void SetManagerSceneManager(ManagerSceneManager manager) => m_mnManager = manager;
}