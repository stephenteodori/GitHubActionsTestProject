using System.Collections.Generic;

namespace DoctorWhoAndWhen
{
    public class Doctor
    {
        /// <summary>
        /// Get the actor's name who portrayed the doctor.
        /// </summary>
        public string ActorName { get; }

        /// <summary>
        /// Get the years the actor played the doctor.
        /// </summary>
        public HashSet<int> Years { get; }

        /// <summary>
        /// Creates a new regeneration of the Doctor.
        /// </summary>
        /// <param name="actorName">The name of the actor who portrayed the doctor.</param>
        /// <param name="years">The years the actor portrayed the doctor.</param>
        public Doctor(string actorName, IEnumerable<int> years)
        {
            ActorName = actorName;
            Years = new HashSet<int>(years);
        }

        /// <summary>
        /// Gets a string representation of the Doctor.
        /// </summary>
        /// <returns>A string representation of the Doctor.</returns>
        public override string ToString()
        {
            return $"{ActorName} - ({string.Join(", ", Years)})";
        }
    }
}
