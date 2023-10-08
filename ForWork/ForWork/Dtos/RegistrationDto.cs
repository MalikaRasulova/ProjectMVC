namespace ForWork.Dtos;

public class RegistrationDto
{
    public string Email  { get; set; }
    public string Password  { get; set; }
    public string FirstName  { get; set; }
    public string  LastName { get; set; }
    public string Mobil  { get; set; }
    public int CountryId { get; set; }
    public int AId { get; set; }
    public string SignUpIP  { get; set; }
}