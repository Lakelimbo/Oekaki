namespace Oekaki.Core.Domains;

public class UserDto {
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Nickname { get; set; }
    public string? URISlug { get; set; }
}

public class UserProtectedDto : UserDto;