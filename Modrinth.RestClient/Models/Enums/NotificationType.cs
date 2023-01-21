using System.Text.Json.Serialization;

namespace Modrinth.RestClient.Models.Enums;

public enum NotificationType
{
    [JsonPropertyName("project_update")]
    ProjectUpdate,
    [JsonPropertyName("team_invite")]
    TeamInvite,
}