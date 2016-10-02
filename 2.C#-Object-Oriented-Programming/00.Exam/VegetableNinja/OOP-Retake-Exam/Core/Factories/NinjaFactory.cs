namespace OOP_Retake_Exam.Core.Factories
{
    using Interfaces;
    using Models;

    public class NinjaFactory : INinjaFactory
    {
        public INinja CreateNinja(char charName, bool isFirst)
        {
            var ninja = new Ninja(charName, isFirst);

            return ninja;
        }
    }
}