namespace MonsterBall.Networking
{
    // Cts == Client to Server
    // Stc == Server to Client
    public enum RiptideMessages
    {
        CtsAbilityUsageRequest,
        StcMonsterSpawned,
        StcMonsterDespawned,
        StcAbilityUsageResponse,
        StcMonsterAbilityStateUpdated,
        StcLiveBallSpawned,
        StcLiveBallDespawned,
        StcBallOwnershipUpdated,
    }
}
