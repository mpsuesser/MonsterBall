namespace MonsterBall.Networking
{
    // Cts == Client to Server
    // Stc == Server to Client
    public enum RiptideMessages
    {
        CtsAbilityUsageRequest,
        StcGameStateUpdated,
        StcPlayStateUpdated,
        StcMonsterSpawned,
        StcMonsterDespawned,
        StcAbilityUsageResponse,
        StcMonsterAbilityStateUpdated,
        StcLiveBallSpawned,
        StcLiveBallDespawned,
        StcBallOwnershipUpdated,
    }
}
