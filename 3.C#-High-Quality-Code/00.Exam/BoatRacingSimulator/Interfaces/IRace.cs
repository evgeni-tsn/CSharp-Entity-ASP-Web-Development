namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Gives conditions in which the race is performed.
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// Distance of the current race. Use to measure how long is the race to calculate speed of the boats.
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// Speed of the head-wind in the race. Use to measure head-wind speed to calculate speed of the boats.
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// Current ocean speed. Use to measure speed of the boats.
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// It trigers when the race is allowed for the Motorboats such as Yachts and PowerBoat. If true 
        /// it is allowed compete. If not only Row Boat and Sail Boat can compete this race.
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// Method that adds boats to the current race.
        /// </summary>
        /// <param name="boat"></param>
        void AddParticipant(IBoat boat);

        /// <summary>
        /// Method that get all current participants for the race.
        /// </summary>
        /// <returns></returns>
        IList<IBoat> GetParticipants();
    }
}