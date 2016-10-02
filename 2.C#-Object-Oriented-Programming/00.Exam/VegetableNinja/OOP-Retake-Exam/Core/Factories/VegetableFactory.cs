namespace OOP_Retake_Exam.Core.Factories
{
    using Exceptions;

    using Interfaces;

    using Models.Vegetables;

    public class VegetableFactory : IVegetableFactory
    {
        public IVegetable CreateVegetable(char charName)
        {
            switch (charName)
            {
                case 'A':
                    return new Asparagus();
                case 'B':
                    return new Broccoli();
                case 'C':
                    return new CherryBerry();
                case 'R':
                    return new Royal();
                case 'M':
                    return new Mushroom();
                case '-':
                    return new BlankSpace();
                default:
                    throw new InvalidVegetableException(Messages.InvalidVegetable);
            }
        }
    }
}