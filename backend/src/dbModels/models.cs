using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;


namespace backend.src.dbModels;

[Table("user_profile_info")]
public class UserProfileInfo : BaseModel
{
    [PrimaryKey("user_id")]
    public string? UserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("username")]
    public string? Username { get; set; }

    [Column("img")]
    public string? Img { get; set; }

    [Column("sp_access_token")]
    public string? SpAccessToken { get; set; }

    [Column("sp_refresh_token")]
    public string? SpRefreshToken { get; set; }

}
