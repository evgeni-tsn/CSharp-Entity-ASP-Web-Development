namespace _03.CompanyHierarchy.Interfaces
{
    public interface IEmployee
    {
        Department Department { get; set; }
        decimal Salary { get; set; }

    }
}