using Core.Application;

public class CreateAutomovilCommand : IRequestCommand<string>
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Color { get; set; }
    public int Fabricacion { get; set; }
    public string NumeroMotor { get; set; }
    public string NumeroChasis { get; set; }
}