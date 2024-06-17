namespace NitroBoostConsoleService.Messaging.Messages;

public class UpdateBirthDateMessage
{
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}